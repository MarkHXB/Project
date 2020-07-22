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
    public class DateHelpClass
    {
       public void datetimechecker(DateTime date,List<Button>lstButton)
        {
            int zu = 0;
            for (int i = 0; i < lstButton.Count; i++)
            {
                Button button = lstButton[i];
                button.Text = (i + 1).ToString();
                string btn = button.Text.ToString();
                string dateString = date.Day.ToString();
                int dateInt = int.Parse(dateString);
                if (i > 31)
                {
                    zu++;
                    button.Text = zu.ToString();
                    button.BackColor = Color.LightGray;
                    button.ForeColor = Color.White;
                }
                if (i >= 10)
                {
                    if (int.Parse(btn) < dateInt)
                    {
                        button.BackColor = Color.LightGray;
                        button.ForeColor = Color.White;

                    }
                }
                else if (i < 10)
                {
                    if (int.Parse(btn.Substring(0, 1)) < dateInt)
                    {
                        button.BackColor = Color.LightGray;
                        button.ForeColor = Color.White;
                    }
                }
            }
        }
    }
}
