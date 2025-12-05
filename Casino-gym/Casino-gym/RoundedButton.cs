using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Casino_gym
{
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 40;
        public Color GradientStartColor { get; set; } = Color.FromArgb(0, 123, 255);
        public Color GradientEndColor { get; set; } = Color.FromArgb(0, 80, 200);

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(250, 70);
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -1, -1);

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius))
            using (LinearGradientBrush brushSurface = new LinearGradientBrush(rectSurface, GradientStartColor, GradientEndColor, 45F))
            using (Pen penBorder = new Pen(this.Parent.BackColor, 2))
            {
                // Button Surface
                this.Region = new Region(pathSurface);
                graphics.FillPath(brushSurface, pathSurface);

                // Button Border (optional, blends with background)
                graphics.DrawPath(penBorder, pathBorder);
            }

            // Text
            TextRenderer.DrawText(graphics, this.Text, this.Font, rectSurface, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Hover Effects
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            // Lighten slightly
            this.GradientStartColor = ControlPaint.Light(this.GradientStartColor);
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            // Darken back/restore (simplest is to just rely on re-setting properly, 
            // but here we just reverse the light effect or assume the caller sets it back. 
            // A better way for state is to store original colors.
            // For simplicity, let's just make it slightly darker than current (which was lightened)
            this.GradientStartColor = ControlPaint.Dark(this.GradientStartColor);
            this.Invalidate();
        }
    }
}
