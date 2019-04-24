using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace overlay
{
    /// <summary>
    /// Overlay.xaml の相互作用ロジック
    /// </summary>
    public partial class Overlay : Window
    {
        public Overlay()
        {
            InitializeComponent();

            Activated += Overlay_Activated;
        }

        public Window OwnerWindow { get; internal set; }

        private void Overlay_Activated(object sender, EventArgs e)
        {
            OwnerWindow.Topmost = true;
            OwnerWindow.Topmost = false;
            this.Topmost = true;
            this.Topmost = false;

        }
    }
}
