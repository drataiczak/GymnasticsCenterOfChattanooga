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
    public partial class GymnastMonitor : Form
    {
        public GymnastMonitor(string pName)
        {
            InitializeComponent();
            
            /* Set our database connection so that it is public to this class */

            /* Morning   - 00:00:00 to 11:59:59
            * Afternoon - 12:00:00 to 16:59:59 
            * Evening   - 17:00:00 to 23:59:59 */
            TimeSpan begin_morning = new TimeSpan(0, 0, 0);
            TimeSpan end_morning = new TimeSpan(11, 59, 59);
            TimeSpan begin_afternoon = new TimeSpan(12, 0, 0);
            TimeSpan end_afternoon = new TimeSpan(16, 59, 59);
            TimeSpan begin_evening = new TimeSpan(17, 0, 0);
            TimeSpan end_evening = new TimeSpan(23, 59, 59);
            TimeSpan current = DateTime.Now.TimeOfDay;

            lbl_hello.Text = "Good ";

            if ((current >= begin_morning) && (current <= end_morning))
                lbl_hello.Text += "morning, ";
            else
                if ((current >= begin_afternoon) && (current <= end_afternoon))
                lbl_hello.Text += "afternoon, ";
            else
                if ((current >= begin_evening) && (current <= end_evening))
                lbl_hello.Text += "evening, ";

            lbl_hello.Text += pName;
        }

        private void GymnastMonitor_Load(object sender, EventArgs e)
        {
            /* Load in default drop offs/pickups */
            string getChildrenCmd = "SELECT Child FROM cTable WHERE isCheckedIn = ";
            getChildrenCmd += Database.pin.ToString();

            SQLiteCommand getChildrenSQL = new SQLiteCommand(getChildrenCmd, Database.db_conn);
            SQLiteDataReader reader;

            reader = getChildrenSQL.ExecuteReader();

            /* Read all signed in children under users pin */
            while(reader.Read())
            {
               gymnastList.Items.Add(reader.GetString(0));
            }


        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (addBtn.Text == "")
                return;

            string addChildCmd = "INSERT INTO cTable('Child') VALUES ('";
            addChildCmd += newChildTextBox.Text;
            addChildCmd += "');";

            string checkChildCmd = "SELECT * FROM cTable WHERE Child = '";
            checkChildCmd += newChildTextBox.Text;
            checkChildCmd += "';";

            /* Make sure child is not already in database */
            SQLiteCommand checkChildSQL = new SQLiteCommand(checkChildCmd, Database.db_conn);
            SQLiteDataReader reader;

            reader = checkChildSQL.ExecuteReader();
            if (!reader.HasRows)
            {
                /* Add child to database */
                SQLiteCommand addChildSQL = new SQLiteCommand(addChildCmd, Database.db_conn);
                addChildSQL.ExecuteNonQuery();
            }

            /* Make sure it the listbox doesn't already contain the name */
            bool exists = false;
            for (int i = 0; i < gymnastList.Items.Count; i++)
                if (gymnastList.Items[i].ToString() == newChildTextBox.Text)
                {
                    exists = true;
                    break;
                }
                
            if(!exists)
            {
                gymnastList.Items.Add(newChildTextBox.Text);
                gymnastList.Sorted = true;
            }
        }

        private void dropOffBtn_Click(object sender, EventArgs e)
        {
            List<string> gymnasts = new List<string>();
            string dropOffCmd = "UPDATE cTable SET isCheckedIn = '";
            dropOffCmd += Database.pin.ToString();
            dropOffCmd += "' WHERE Child = '";

            /* Get a list of all selected gymansts */
            foreach(int i in gymnastList.SelectedIndices)
                    gymnasts.Add((string) gymnastList.Items[i]);

            foreach(string name in gymnasts)
            {
                /* Add the student's name to the command */
                dropOffCmd += name;
                dropOffCmd += "';";

                /* Compile and execute */
                SQLiteCommand dropOffSQL = new SQLiteCommand(dropOffCmd, Database.db_conn);
                dropOffSQL.ExecuteNonQuery();

                /* Remove student's name */
                dropOffCmd = dropOffCmd.Replace(name + "';", "");
            }    
        }

        private void pickUpBtn_Click(object sender, EventArgs e)
        {
            List<string> gymnasts = new List<string>();
            string pickUpCmd = "UPDATE cTable SET isCheckedIn = '' WHERE Child = '";

            foreach (int i in gymnastList.SelectedIndices)
                gymnasts.Add((string)gymnastList.Items[i]);

            foreach(string name in gymnasts)
            {
                pickUpCmd += name;
                pickUpCmd += "';";

                SQLiteCommand pickUpSQL = new SQLiteCommand(pickUpCmd, Database.db_conn);
                pickUpSQL.ExecuteNonQuery();

                pickUpCmd = pickUpCmd.Replace(name + "';", "");

                gymnastList.Items.Remove(name);
            }
        }
    }
}
