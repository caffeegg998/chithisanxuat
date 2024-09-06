using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Utils
{
    public class CustomToolTip : ToolTip
    {
        private Padding _margin = new Padding(5);
        private Point _offset = new Point(0, 0);

        public Padding Margin
        {
            get { return _margin; }
            set { _margin = value; }
        }

        public Point Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        public CustomToolTip()
        {
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(OnPopup);
            this.Draw += new DrawToolTipEventHandler(OnDraw);
        }

        private void OnPopup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(
                e.ToolTipSize.Width + Margin.Left + Margin.Right,
                e.ToolTipSize.Height + Margin.Top + Margin.Bottom
            );
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            Graphics g = e.Graphics;

            // Vẽ nền
            g.FillRectangle(Brushes.LightYellow, e.Bounds);
            g.DrawRectangle(Pens.Black, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));

            // Vẽ text với margin
            g.DrawString(e.ToolTipText, e.Font, Brushes.Black,
                new PointF(e.Bounds.X + Margin.Left, e.Bounds.Y + Margin.Top));
        }

        public void ShowWithOffset(IWin32Window window, string text, Point position)
        {
            Point adjustedPosition = new Point(position.X + Offset.X, position.Y + Offset.Y);
            this.Show(text, window, adjustedPosition);
        }
    }

}
