using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace TeamViewer.AdditionalClasses
{
    public class ScreenShot
    {
        public string GetScreenShotPath(int count)
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            string path;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                path = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "Images");


                System.IO.Directory.CreateDirectory(path);
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                bmp.Save(path + "\\screenshot" + count.ToString() + ".png");  // saves the image
            }
            var source = path + "\\screenshot" + count.ToString() + ".png";
            return source;
        }


        public string GetScreenShotJpeg(int count)
        {


            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            string path;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                path = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "Images");


                System.IO.Directory.CreateDirectory(path);
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                //bmp.Save(path + "\\screenshot" + count.ToString() + ".png");  // saves the image
                // Assumes myImage is the PNG you are converting
                using (var b = new Bitmap(bmp.Width, bmp.Height))
                {
                    b.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

                    using (var gr = Graphics.FromImage(b))
                    {
                        gr.Clear(Color.White);
                        gr.DrawImageUnscaled(bmp, 0, 0);
                    }

                    // Now save b as a JPEG like you normally would
                    b.Save(path + "\\screenshot" + count.ToString() + ".jpeg");  // saves the image
                    var source = path + "\\screenshot" + count.ToString() + ".jpeg";
                    return source;
                }
            }

        }

    }
}
