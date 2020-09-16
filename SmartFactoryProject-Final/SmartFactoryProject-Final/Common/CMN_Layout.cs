using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFactoryProject_Final.Common
{
    class ControlLayout
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);
        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        public void MakeCurvedBorder(Control cnt, int curveAmount_X, int curveAmount_Y)
        {
            IntPtr ip = CreateRoundRectRgn(0, 0, cnt.Width, cnt.Height, curveAmount_X, curveAmount_Y);
            int i = SetWindowRgn(cnt.Handle, ip, true);
        }

        /// <summary>
        /// 화면의 x비율, y비율에 맞춰서 컨트롤의 크기를 조정하는 함수
        /// </summary>
        /// <param name="control">크기를 조정할 컨트롤 컨트롤</param>
        /// <param name="formSize">화면의 크기</param>
        /// <param name="xPosRatio">화면에서 컨트롤이 차지할 x축 길이의 비율(0~1)</param>
        /// <param name="yPosRatio">화면에서 컨트롤이 차지할 y축 길이의 비율(0~1)</param>
        public void Control_Sizing(Control control, Size formSize,
                                          float xPosRatio, float yPosRatio)
        {
            if (IsInRange(xPosRatio, 0, 1) &&
                IsInRange(yPosRatio, 0, 1))
            {
                int width = (int)(formSize.Width * xPosRatio);
                int height = (int)(formSize.Height * yPosRatio);

                control.Size = new Size(width, height);
            }
        }

        public enum HorizontalSiding { Left, Center, Right }
        /// <summary>
        /// 화면의 x비율, y비율에 맞춰서 컨트롤의 위치를 옮기는 함수
        /// </summary>
        /// <param name="control">위치를 옮길 컨트롤</param>
        /// <param name="formSize">화면의 크기</param>
        /// <param name="xPosRatio">화면에서 컨트롤이 위치할 x좌표의 비율(0~1)</param>
        /// <param name="yPosRatio">화면에서 컨트롤이 위치할 y좌표의 비율(0~1)</param>
        /// <param name="horizontalSiding">x,y좌표를 컨트롤의 좌측, 중앙, 우측 어느곳을 기준으로 맞추는가를 나타냄</param>
        public void Control_Positioning(Control control, Size formSize,
                                        float xPosRatio, float yPosRatio,
                                        HorizontalSiding horizontalSiding = HorizontalSiding.Center)
        {
            if (IsInRange(xPosRatio, 0, 1) &&
                IsInRange(yPosRatio, 0, 1))
            {
                int xCenter = (int)(formSize.Width * xPosRatio);
                int yCenter = (int)(formSize.Height * yPosRatio);

                int controlXHalf = control.Size.Width / 2;
                int controlYHalf = control.Size.Height / 2;

                switch (horizontalSiding)
                {
                    case HorizontalSiding.Left:
                        control.Location = new Point(xCenter, yCenter - controlYHalf);
                        break;
                    case HorizontalSiding.Center:
                        control.Location = new Point(xCenter - controlXHalf,
                                                     yCenter - controlYHalf);
                        break;
                    case HorizontalSiding.Right:
                        control.Location = new Point(xCenter - (controlXHalf * 2),
                                                     yCenter - controlYHalf);
                        break;
                }
            }
        }
        
        private bool IsInRange(float num, int min, int max)
        {
            return num >= min && num <= max;
        }
    }

    class FormLayout
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);
        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        public void MakeCurvedBorder(Form frm, int curveAmount_X, int curveAmount_Y)
        {
            IntPtr ip = CreateRoundRectRgn(0, 0, frm.Width, frm.Height, curveAmount_X, curveAmount_Y);
            frm.Region = Region.FromHrgn(ip);
        }
    }
}
