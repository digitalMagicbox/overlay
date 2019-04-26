using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace overlay
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        Overlay overlay = new Overlay();
        private void MoveOverlay(object sender, EventArgs e)
        {
            var point = this.browser.PointToScreen(new Point());

            overlay.Height = this.browser.ActualHeight;
            overlay.Width = this.browser.ActualWidth;
            overlay.Top = point.Y; 
            overlay.Left = point.X;
            overlay.Topmost = true;
            overlay.Topmost = false;
        }
        public MainWindow()
        {
            InitializeComponent();
            overlay.OwnerWindow = this;
            overlay.Show();

            Closed += MainWindow_Closed;
            Activated += MoveOverlay;
            SizeChanged += MoveOverlay;
            Loaded += MoveOverlay;
            LocationChanged += MoveOverlay;

        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            overlay.Close();
        }

    }
}
