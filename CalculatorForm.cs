using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class CalculatorForm : Form
    {
        //kell a fő érték, mint Double
        Double result = 0;

        //kell ez az operandusok miatt
        String operationPerformed = "";

        //ha operandus button volt
        bool isOperationPerformed = false;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //látni is, hogy 15 referens van rá, tehát a gombok java , ami nem operandus
        //erre van beállítva( egy event )
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0"||isOperationPerformed)
            {
                txtBox.Clear();
            }
            Button button = (Button)sender;
            isOperationPerformed = false;
            if (button.Text == ",")
            {
                if(!txtBox.Text.Contains(','))
                    txtBox.Text = txtBox.Text + button.Text;
            }
            else if (button.Text == "x*x")
            {
                isOperationPerformed = true;
            }
            else
                txtBox.Text = txtBox.Text + button.Text;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Resultlbl.Visible = false;
            txtBox.Text = "0";
            result = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtBox.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                buttonResult.PerformClick();
                operationPerformed = button.Text;
                Resultlbl.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
                Resultlbl.Visible = true;
            }
            else
            {
                operationPerformed = button.Text;
                result = Double.Parse(txtBox.Text);
                Resultlbl.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
                Resultlbl.Visible = true;
            }    
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    txtBox.Text = (result + Double.Parse(txtBox.Text)).ToString();
                        break;
                case "-":
                    txtBox.Text = (result + Double.Parse(txtBox.Text)).ToString();
                    break;
                case "*":
                    txtBox.Text = (result + Double.Parse(txtBox.Text)).ToString();
                    break;
                case "/":
                    txtBox.Text = (result + Double.Parse(txtBox.Text)).ToString();
                    break;
                case "x*x":
                    txtBox.Text = (result + Double.Parse(txtBox.Text)).ToString();
                        break;
                default:
                    break;
            }
            result = Double.Parse(txtBox.Text);
            Resultlbl.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }
        private void CalculatorForm_Closing(object sender, FormClosingEventArgs e)
        {
            var calculatorClass = new CalculatorBehaviours();
            calculatorClass.calculatorIsOn = false;
            MenuPage menu = new MenuPage();
            menu.Show();
        }

        private void CalculatorForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
