using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Project
{

    public partial class MenuPage : Form
    {
        CalculatorBehaviours calculatorClass = new CalculatorBehaviours();
        recommendedSession recommended = new recommendedSession();


        public MenuPage()
        {
            MainStyle();
        }
        private void MainStyle()
        {
            InitializeComponent();

            panel5.Visible = false;

        }

        private void recommended_Click(object sender, EventArgs e)
        {
            var count = recommended.o++;

            if (count % 2 == 0)
            {
                recommended.panelVisible = true;
                recommended.function(panel5);
            }
            else
            {
                recommended.panelVisible = false;
                recommended.function(panel5);
            }
        }

        private void calculatorPlay_click(object sender, EventArgs e)
        {
            if (!calculatorClass.calculatorIsOn)
            {
                calculatorClass.calculatorIsOn = true;
                var calculatorForm = new CalculatorForm();
                calculatorForm.Show();
                this.Close();
            }
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.realPlay_icon));
        }

        private void textEditor_Click(object sender, EventArgs e)
        {
            this.Hide();
            TextEditor textEditor = new TextEditor();
            textEditor.Show();
        }

        private void btnReminder_Click(object sender, EventArgs e)
        {
            this.Hide();
            DateReminder dateReminder = new DateReminder();
            dateReminder.Show();
        }
    }
}
