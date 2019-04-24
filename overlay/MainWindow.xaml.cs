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
        private void MoveOverlay()
        {
            overlay.Height = this.ActualHeight;
            overlay.Width = this.ActualWidth;
            overlay.Top = this.Top; 
            overlay.Left = this.Left;
            overlay.Topmost = true;
            overlay.Topmost = false;
        }
        public MainWindow()
        {
            InitializeComponent();
            overlay.OwnerWindow = this;

            Closed += MainWindow_Closed;
            Activated += MainWindow_Activated;
            SizeChanged += MainWindow_SizeChanged;
            Loaded += MainWindow_Loaded;
            LocationChanged += MainWindow_LocationChanged;

        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            overlay.Close();
        }

        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            MoveOverlay();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            MoveOverlay();
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MoveOverlay();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MoveOverlay();
            overlay.Show();
        }
    }
}
