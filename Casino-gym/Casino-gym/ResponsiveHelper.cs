using System;
using System.Windows.Forms;
using System.Drawing;

namespace Casino_gym
{
    public static class ResponsiveHelper
    {
        public static void MakeResponsive(Form form)
        {
            // Ensure background stretches if present
            if (form.BackgroundImage != null)
            {
                form.BackgroundImageLayout = ImageLayout.Stretch;
            }

            ApplyResponsiveLayout(form, form.ClientSize.Width, form.ClientSize.Height);
        }

        private static void ApplyResponsiveLayout(Control container, int parentWidth, int parentHeight)
        {
            foreach (Control c in container.Controls)
            {
                // Skip if it is a StatusStrip or MenuStrip as they handle themselves usually, but checking won't hurt

                // Horizontal Analysis
                AnchorStyles hAnchor = AnchorStyles.None;

                int cCenterX = c.Left + c.Width / 2;
                double hRatio = (double)c.Left / parentWidth;
                double hRightRatio = (double)c.Right / parentWidth;

                bool isCenterH = Math.Abs(cCenterX - parentWidth / 2.0) < (parentWidth * 0.15); // 15% tolerance
                bool spansH = (c.Left < parentWidth * 0.2) && (c.Right > parentWidth * 0.8);
                bool isLeft = c.Right < parentWidth * 0.5; // Strictly left half
                bool isRight = c.Left > parentWidth * 0.5; // Strictly right half

                // Refined Logic
                if (spansH)
                {
                    hAnchor = AnchorStyles.Left | AnchorStyles.Right;
                }
                else if (isCenterH)
                {
                    // Keep Center
                    hAnchor = AnchorStyles.None;
                }
                else if (isLeft)
                {
                    hAnchor = AnchorStyles.Left;
                }
                else if (isRight)
                {
                    hAnchor = AnchorStyles.Right;
                }
                else
                {
                    // Fallback to Left if ambiguous (e.g. crossing center but not "Centered")
                    hAnchor = AnchorStyles.Left;
                }

                // Vertical Analysis
                AnchorStyles vAnchor = AnchorStyles.None;

                int cCenterY = c.Top + c.Height / 2;
                bool isCenterV = Math.Abs(cCenterY - parentHeight / 2.0) < (parentHeight * 0.15);
                bool spansV = (c.Top < parentHeight * 0.2) && (c.Bottom > parentHeight * 0.8);
                bool isTop = c.Bottom < parentHeight * 0.5;
                bool isBottom = c.Top > parentHeight * 0.5;

                if (spansV)
                {
                    vAnchor = AnchorStyles.Top | AnchorStyles.Bottom;
                }
                else if (isCenterV)
                {
                    vAnchor = AnchorStyles.None;
                }
                else if (isTop)
                {
                    vAnchor = AnchorStyles.Top;
                }
                else if (isBottom)
                {
                    vAnchor = AnchorStyles.Bottom;
                }
                else
                {
                    vAnchor = AnchorStyles.Top;
                }

                // Combine
                AnchorStyles final = AnchorStyles.None;

                // If we want "None" (Center) for one axis, we rely on the absence of flags for that axis.
                // AnchorStyles.Left = 1, Top = 2, Right = 4, Bottom = 8.

                if (hAnchor == AnchorStyles.Left) final |= AnchorStyles.Left;
                if (hAnchor == AnchorStyles.Right) final |= AnchorStyles.Right;
                if (hAnchor == (AnchorStyles.Left | AnchorStyles.Right)) final |= (AnchorStyles.Left | AnchorStyles.Right);

                if (vAnchor == AnchorStyles.Top) final |= AnchorStyles.Top;
                if (vAnchor == AnchorStyles.Bottom) final |= AnchorStyles.Bottom;
                if (vAnchor == (AnchorStyles.Top | AnchorStyles.Bottom)) final |= (AnchorStyles.Top | AnchorStyles.Bottom);

                c.Anchor = final;

                // Debug line (commented out)
                // Console.WriteLine($"Control {c.Name}: {c.Left},{c.Top} [{parentWidth}x{parentHeight}] -> {c.Anchor}");

                // Recursion for Panels/GroupBoxes
                if (c.HasChildren && (c is Panel || c is GroupBox || c is TabControl))
                {
                    ApplyResponsiveLayout(c, c.ClientSize.Width, c.ClientSize.Height);
                }
            }
        }
    }
}
