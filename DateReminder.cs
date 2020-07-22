using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class DateReminder : Form
    {

        DateHelpClass @class = new DateHelpClass();
        DateTime date = DateTime.Now;

        public DateReminder()
        {
            MainStyle();
        }
        public void MainStyle()
        {
            InitializeComponent();

            

        }
        public string DateCheck(DateTime date,Label label,int c)
        {
            string result = label.Text;
            result = date.Day.ToString();
            string piece = result.Substring(1, 1);
            string firstpiece = result.Substring(0, 1);
            string finalPiece =firstpiece +""+c.ToString();
            return finalPiece;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
            
        }
        private void DateUpload()
        {
            List<Button> lstButton = new List<Button>
            {
                button1,button2,button3,button4,button5,button6,button7,
                button8,button9,button10,button11,button12,button13,button14,
                button15,button16,button17,button18,button19,button20,button21,
                 button22,button23,button24,button25,button26,button27,button28,
                 button29,button30,button31,button32,button33,button34,button35
            };

            @class.datetimechecker(date, lstButton);
            
        }
        private void DateReminder_Load(object sender, EventArgs e)
        {
            DateUpload();   
        }

        private void button35_MouseEnter(object sender, EventArgs e)
        {
            btnDeletedate.UseVisualStyleBackColor = false;
            btnDeletedate.BackColor = Color.Transparent;
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {
            btnDeletedate.UseVisualStyleBackColor = false;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPage menuPage = new MenuPage();
            menuPage.Show();
        }
    }
}
