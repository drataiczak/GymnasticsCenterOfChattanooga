using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite; /* SQLite */
using System.IO; /* File.Exists() */

namespace GCC_App
{
    public partial class pinForm : Form
    {

        public pinForm()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            pinTextBox.Text += "0";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            /* Clears the text box */
            pinTextBox.Text = "";
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            uint pinLength = (uint) pinTextBox.Text.Length;

            if (pinLength == 0)
                /* Avoids errors when pinLength is 0 */
                return;
            else
                /* Removes the last character from the pinTextBox */
                pinTextBox.Text = pinTextBox.Text.Remove((int) pinLength - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string uninit_db_msg = "No database exists for the currently signed in user. Creating new database.";
            string db_path = @"C:\Users\" + Environment.UserName + @"\Documents\GCC\";
            string db_name = "gcc.db";
            string caption = "Uninitialized Database";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            /* Check if the database exist at C:\Users\<User>\GCC\gcc.db
             * If not, create it
             * Open the database for use
             */
            if (!File.Exists(db_path + @"\" + db_name))
            {
                MessageBox.Show(uninit_db_msg, caption, buttons, icon);
                System.IO.Directory.CreateDirectory(db_path);
                SQLiteConnection.CreateFile(db_path + db_name);

                Database.db_conn = new SQLiteConnection("Data Source = " + db_path + db_name + "; Version = 3;");
                Database.db_conn.Open();

                /* Initialize the database with appropriate tables */
                init_db(db_name);
            }
            else {
                Database.db_conn = new SQLiteConnection("Data Source = " + db_path + db_name + "; Version = 3;");
                Database.db_conn.Open();
            }
        }

        private void init_db(string db_name)
        {
            /* We want two tables:
             *  ----------------------------
             *  | Parent | Pin  | Children |
             *  ----------------------------
             *  | Name   | #### | cName    |
             *  ----------------------------
             *  
             *  -----------------------
             *  | Child | Checked In? |
             *  -----------------------
             *  | cName | Yes/No      |
             *  -----------------------
             */

            string pTable = "CREATE TABLE pTable(" +
                                "Pin INTEGER PRIMARY KEY, " +
                                "Parent TEXT NOT NULL);";
            string cTable = "CREATE TABLE cTable(" +
                                "Child TEXT NOT NULL, " +
                                "isCheckedIn TEXT);";
            string admin = "INSERT INTO pTable(Pin, Parent) VALUES (1234, 'Admin')";
            string caption = "Database Created";
            string msg = "Database created. Admin password is: 1234. Please change it immediately for security.";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            /* Compile our commands */
            SQLiteCommand pTableCmd = new SQLiteCommand(pTable, Database.db_conn);
            SQLiteCommand cTableCmd = new SQLiteCommand(cTable, Database.db_conn);
            SQLiteCommand adminCmd = new SQLiteCommand(admin, Database.db_conn);

            /* Execute our commands */
            pTableCmd.ExecuteNonQuery();
            cTableCmd.ExecuteNonQuery();
            adminCmd.ExecuteNonQuery();

            /* Make sure admin knows pin */
            MessageBox.Show(msg, caption, buttons, icon);

        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            string pin_msg = "Please enter a valid pin.";

            string caption = "Invalid pin";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;

            /* Make sure pinTextBox contains something */
            if (pinTextBox.Text == "") {
                MessageBox.Show(pin_msg, caption, buttons, icon);
                return;
            }

            string pCheck = "SELECT Parent FROM pTable where Pin = " + pinTextBox.Text + ";";
            GymnastMonitor gm;
            AdminForm af;
            SQLiteDataReader reader;

            SQLiteCommand pCheckCmd = new SQLiteCommand(pCheck, Database.db_conn);

            reader = pCheckCmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                if ((string)reader["Parent"] == "Admin")
                {
                    /* If it is the admin signing in, show admin landing page */
                    af = new AdminForm();
                    /* Save off pin */
                    Database.pin = Convert.ToInt64(pinTextBox.Text);
                    af.Show();
                    pinTextBox.Text = "";
                }
                else
                {
                    /* Show the check in screen and clear the pinTextBox */
                    gm = new GymnastMonitor((string)reader["Parent"]);
                    /* Save off pin */ 
                    Database.pin = Convert.ToInt64(pinTextBox.Text);
                    gm.Show();
                    pinTextBox.Text = "";
                }
                
            }
            else
            {
                /* Display error and clear the pinTextBox */
                MessageBox.Show(pin_msg, caption, buttons, icon);
                pinTextBox.Text = "";
            }
                    
        }

        private void pinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string caption = "Closing";
            string closing_msg = "Are you sure you wish to exit the application?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Exclamation;
            DialogResult result;

            /* Make sure we're closing it on purpose (we want as few accidental closes as possible) */
            /* TODO Enable in release */
            // result = MessageBox.Show(closing_msg, caption, buttons, icon);

            /* If it was not intentional, cancel closing */
            // if (result == System.Windows.Forms.DialogResult.No)
            //    e.Cancel = true;

            /* If it was intentional, close the database and exit */
            Database.db_conn.Close();
        }
    }
}
