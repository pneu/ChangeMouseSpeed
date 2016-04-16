using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMouseSpeed
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// <see cref="http://program.station.ez-net.jp/special/vcs/mouse/speed.asp"/>
    public static class MouseSpeed
    {
        [System.Runtime.InteropServices.DllImport("user32", SetLastError = true)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        public static int Min = 0;
        public static int Max = 20;
        const uint SPI_GETMOUSESPEED = 0x70;
        const uint SPI_SETMOUSESPEED = 0x71;

        public static void Set(int speed) {
            if (!SystemParametersInfo(SPI_SETMOUSESPEED, 0, new IntPtr(speed), 0)) {
                throw new Exception("マウスカーソルの速度を設定できませんでした。");
            }
        }

        unsafe public static int Get() {
            int result;

            if (!SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr((void*)&result), 0)) {
                throw new Exception("マウスカーソルの速度を取得できませんでした。");
            }

            return result;
        }
    }
}
