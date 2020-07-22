using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class RegisterForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bakon\source\repos\Project\Login.mdf;Integrated Security = True";
        bool userJo = false;
        bool passJo = false;
        bool emailJo = false;
        bool jo = false;
        bool insert = false;
        public RegisterForm()
        {
            MainStyle();
        }
        private void MainStyle()
        {
            InitializeComponent();
            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jo=checker(txtUsername1, txtPassword1, txtPasswordRe, txtMail);
            onFocus();
            InsertToDataBase(insert);
        }
        private void onFocus()
        {
            if (jo)
            {
                /*string query = "select * from RegisterTable where Username='" + txtUsername1.Text.Trim() + "' and Password='" + txtPassword1.Text.Trim() + "' and MailAddress='" + txtMail.Text.Trim() + "'";
                using(SqlConnection connection=new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    try
                    {
                        connection.Open();

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataTable.
                    }
                    catch (Exception e)
                    {
                        
                    }
                }*/
                    MessageBox.Show("A regisztráció sikeres volt.\nAz adatokat mentve lettek!");
                insert = true;
            }
            else if (!userJo)
            {
                txtUsername1.Text = "";
                txtUsername1.Focus();
            }
            else if (!passJo)
            {
                txtPassword1.Text = "";
                txtPasswordRe.Text = "";
                txtPassword1.Focus();
            }
            else if (!emailJo)
            {
                txtMail.Text = "";
                txtMail.Focus();
            }
        }
        private void InsertToDataBase(bool insert)
        {

            string query = "Insert into RegisterTable values(@Username,@Password,@MailAddress)";

            if (insert)
            {
                using(SqlConnection connection=new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        command.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 20)).Value = txtUsername1.Text;
                        command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 20)).Value = txtPassword1.Text;
                        command.Parameters.Add(new SqlParameter("@MailAddress", SqlDbType.NVarChar, 35)).Value = txtMail.Text;

                        command.ExecuteNonQuery();

                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
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
        }
        private bool checker(TextBox username,TextBox password,TextBox passwordRe, TextBox mail)
        {
            bool joo = false;
            userJo = false;
            passJo = false;
            emailJo = false;

            string user = username.Text;
            string pass = password.Text;
            string passre = passwordRe.Text;
            string email = mail.Text;

            if (user.Length > 3 && user.Length < 10)
            {
                userJo = true;
            }
            if (!userJo)
                MessageBox.Show("Nem jó a Username");

            if(pass==passre&& pass.Length > 3 && pass.Length < 10)
            {
                passJo = true;
            }
            if (!passJo)
                MessageBox.Show("Nem jó a Password");

            bool vanbennekukac = email.Contains('@');
            bool vanbennepont = email.Contains('.');
            bool vanbennehu = email.Contains("hu");
            bool vanbennecom = email.Contains("com");

            if (email.Length > 6 && vanbennekukac && (vanbennehu || vanbennecom) && vanbennepont)
            {
                emailJo = true;
            }
            if (!emailJo)
                MessageBox.Show("Nem jó a mail");

            if (userJo && emailJo && passJo)
            {
                joo = true;
            }

            return joo;
        }
    }
}
