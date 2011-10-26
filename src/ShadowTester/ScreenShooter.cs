using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ShadowTester
{
    public class ScreenShooter : IScreenShooter
    {
        public void Capture(string filename)
        {
            Rectangle screenBounds = Screen.GetBounds(Point.Empty);
            using (Image image = new Bitmap(screenBounds.Width, screenBounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(Point.Empty, Point.Empty, screenBounds.Size);
                    if (Cursor.Current != null)
                    {
                        Rectangle cursorBounds = new Rectangle(Cursor.Position, Cursor.Current.Size);
                        Cursors.Default.Draw(graphics, cursorBounds);
                    }
                }
                image.Save(filename, ImageFormat.Jpeg);
            }
        }

    }
}
