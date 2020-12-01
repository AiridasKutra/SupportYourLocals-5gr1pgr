using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    public interface IPanel
    {
        public void Reload();
        public Panel GetPanel();
        public void SetMainRef(UiMain main);
    }
}
