using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vanara.PInvoke;

namespace RuhuyagayBemkaijearfear
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : PerformanceDesktopTransparentWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var edge = Process.Start(new ProcessStartInfo
            {
                FileName = "msedge",
                UseShellExecute = true,
            });

            var handle = new WindowInteropHelper(this).EnsureHandle();
            // 增加 Child Style
            var style = (User32.GetWindowLong(handle, User32.WindowLongFlags.GWL_STYLE)
                | (int)User32.WindowStyles.WS_CHILD);
            User32.SetWindowLong(handle, User32.WindowLongFlags.GWL_STYLE, style);

            // 等待宿主父窗口 edge 完全启动
            Thread.Sleep(3000);
            var proc = Process.GetProcessesByName("msedge").FirstOrDefault(proc => proc.MainWindowHandle != IntPtr.Zero);
            nint edgeHandle = proc.MainWindowHandle;

            // HACK：如果是 net9，那么会正常显示透明的子窗口
            // 如果是 net48，layerd 没有被正常添加，透明显示为黑色
            User32.SetParent(handle, edgeHandle);

            User32.GetClientRect(edgeHandle, out var rectClient);
            User32.SetWindowPos(handle, IntPtr.Zero, 0, 0, rectClient.Width, rectClient.Height, User32.SetWindowPosFlags.SWP_NOZORDER);
        }

        private void SetTransparentHitThroughButton_OnClick(object sender, RoutedEventArgs e)
        {
            SetTransparentHitThrough();
        }
    }
}
