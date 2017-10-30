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

namespace GCC_App
{
    public partial class AdminForm : Form
    {
        /* Reusable constants */
        private string empty_box_msg = "Please make sure all fields are filled.";
        private string caption = "Missing Fields";
        private MessageBoxButtons buttons = MessageBoxButtons.OK;
        private MessageBoxIcon icon = MessageBoxIcon.Error;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            /* TODO Add children with keys */

            /* Make sure we have full fields */
            if((pinText.Text =="") || (pNameText.Text ==""))
            {
                MessageBox.Show(empty_box_msg, caption, buttons, icon);
                return;
            }

            string existing_pin_msg = "You have selected a pin already assigned to someone else, please try again.";
            string pCaption = "Invalid Pin";
            MessageBoxButtons pButtons = MessageBoxButtons.OK;
            MessageBoxIcon pIcon = MessageBoxIcon.Exclamation;
            string checkUser = "SELECT Parent FROM pTable WHERE Pin = " + pinText.Text + ";";
            string addUser = "INSERT INTO pTable(Pin, Parent) VALUES (" +
                pinText.Text +
                ", '" +
                pNameText.Text + "');";

            SQLiteCommand checkUserCmd = new SQLiteCommand(checkUser, Database.db_conn);
            SQLiteCommand addUserCmd = new SQLiteCommand(addUser, Database.db_conn);
            SQLiteDataReader reader;

            reader = checkUserCmd.ExecuteReader();

            if (reader.HasRows)
            {
                MessageBox.Show(existing_pin_msg, pCaption, pButtons, pIcon);
                pinText.Text = "";
                return;
            }
            else
                MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);

            pinText.Text = "";
            pNameText.Text = "";
            cNameText.Text = "";

            addUserCmd.ExecuteNonQuery();
        }

        private void remUserBtn_Click(object sender, EventArgs e)
        {
            /* Make sure we have full fields */
            if ((pNameText.Text == ""))
            {
                MessageBox.Show(empty_box_msg, caption, buttons, icon);
                return;
            }
            
            string remUser = "DELETE FROM pTable WHERE Parent = '" + pNameText.Text + "';";
            string checkUser = "SELECT Parent FROM pTable WHERE Parent = '" + pNameText.Text + "';";

            SQLiteCommand checkUserCmd = new SQLiteCommand(checkUser, Database.db_conn);
            SQLiteCommand remUserCmd = new SQLiteCommand(remUser, Database.db_conn);

            SQLiteDataReader reader;

            reader = checkUserCmd.ExecuteReader();

            if(reader.HasRows)
            {
                remUserCmd.ExecuteNonQuery();
                MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
                MessageBox.Show("No parent by that name.", "Unknown Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            pNameText.Text = "";
            pinText.Text = "";
            cNameText.Text = "";
            
        }
    }
}
