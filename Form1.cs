using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class MainForm : Form
    {
        RegisterForm registerForm = new RegisterForm();
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bakon\source\repos\Project\Login.mdf;Integrated Security = True";
        public MainForm()
        {       
            MainStyle();
        }
        private void MainStyle()
        {
            InitializeComponent();

            MenuPage menuPage = new MenuPage();
            menuPage.Show();

            panel1.Location = new Point(
              this.ClientSize.Width / 2 - panel1.Size.Width / 2,
              this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;

            FadeThings(panel1, true, null, false, null, false);
            FadeThings(null,false, label1, true, null, false);
            FadeThings(null, false, label2, true, null, false);
            FadeThings(null, false, label3, true, null, false);
            FadeThings(null, false, null, false, button1, true);
        }
        private void FadeThings(Panel panel,bool Panel,Label label,bool Label,Button button,bool Button)
        {
            if (Panel)
            {
                panel.BackColor = Color.White;
                panel.BackColor = Color.FromArgb(25, Color.White);
            }
            else if (Label)
            {
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
                linkLabel1.BackColor = Color.Transparent;
                linkLabel1.ForeColor = Color.Blue;
                linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
            }
            else if (Button)
            {
                button.BackColor = Color.White;
                button.BackColor = Color.FromArgb(25, Color.White);
                button.ForeColor = Color.Black;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LogCheck()
        {

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            using(SqlDataAdapter adapter=new SqlDataAdapter("Select * from LoginTable where Username = '"+txtUsername.Text.Trim()+"'and Password ='"+txtPassword.Text.Trim()+"'", connection))
            {
                try
                {
                    connection.Open();

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 1)
                    {
                        this.Hide();
                        MenuPage menuPage = new MenuPage();
                        menuPage.Show();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogCheck();
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                LogCheck();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            registerForm.Show();
        }
    }
}
