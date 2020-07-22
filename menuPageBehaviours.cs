using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public class menuPageBehaviours
    {

    }
    public class recommendedSession : menuPageBehaviours
    {
        public bool panelVisible = false;
        public int o = 2;
        public void function(Panel panel)
        {
            panel.Visible = panelVisible;
        }
    }
}
