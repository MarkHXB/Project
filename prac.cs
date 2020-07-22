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
    public class prac
    {
        public bool kezdStart = false;
        private bool clickable = false;
        public void ButtonChecker_to_click(Button button,ConsoleColor color)
        {
            if (clickable)
            {
                button.BackColor = color;
            }
            else
            {
                MessageBox.Show("There is no chance to choose this");
            }
        }
    }
}
