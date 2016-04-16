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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChangeMouseSpeed
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// <see cref="http://program.station.ez-net.jp/special/vcs/mouse/speed.asp"/>
    public partial class MainWindow : Window
    {
        int DefaultMaximumSpeed { get; } = MouseSpeed.Max;
        int RestrictedMaximumSpeed;

        public MainWindow() {
            InitializeComponent();
            InitSpeed();
        }

        void InitSpeed() {
            var current = slider.Value;
            RestrictedMaximumSpeed = (int)current;
            try {
                current = MouseSpeed.Get();
                slider.Value = current;
                RestrictedMaximumSpeed = (int)current;
                slider.Maximum = current;
            }
            catch { /* nop */ }
        }

        void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            try {
                MouseSpeed.Set((int)slider.Value);
            }
            catch { /* nop */ }
        }

        void checkBox_Checked(object sender, RoutedEventArgs e) {
            /* slider.Value set to Maximum if above RestrictedMaximumSpeed automatically  */
            slider.Maximum = RestrictedMaximumSpeed;
        }

        void checkBox_Unchecked(object sender, RoutedEventArgs e) {
            slider.Maximum = DefaultMaximumSpeed;
        }
    }
}
