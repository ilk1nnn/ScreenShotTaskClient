using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamViewer.AdditionalClasses
{
    public class ImageHelper
    {
        public string GetImagePath(byte[] buffer, int counter)
        {
            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(buffer);
            Bitmap bitmap1 = new Bitmap(img);
            bitmap1.Save($@"C:\Users\Documents\source\repos\TeamViewer\TeamViewer\bin\Debug\Images\image{counter}.png");
            var imagepath = $@"C:\Users\Documents\source\repos\TeamViewer\TeamViewer\bin\Debug\Images\image{counter}.png";
            return imagepath;
        }


        public string GetImagePathJpeg(byte[] buffer, int counter)
        {
            ImageConverter ic = new ImageConverter();
            //Bitmap bmp1 = new Bitmap(@"c:\TestPhoto.jpg");
            //ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            //// Create an Encoder object based on the GUID 
            //// for the Quality parameter category.
            //System.Drawing.Imaging.Encoder myEncoder =
            //    System.Drawing.Imaging.Encoder.Quality;

            //// Create an EncoderParameters object. 
            //// An EncoderParameters object has an array of EncoderParameter 
            //// objects. In this case, there is only one 
            //// EncoderParameter object in the array.
            //EncoderParameters myEncoderParameters = new EncoderParameters(1);

            //myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            //myEncoderParameters.Param[0] = myEncoderParameter;
            //bmp1.Save(@"c:\TestPhotoQualityHundred.jpg", jgpEncoder, myEncoderParameters);
            Image img = (Image)ic.ConvertFrom(buffer);
            // Assumes myImage is the PNG you are converting
            using (var b = new Bitmap(img.Width, img.Height))
            {
                b.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                using (var g = Graphics.FromImage(b))
                {
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(img, 0, 0);
                }

                // Now save b as a JPEG like you normally would
                b.Save($@"C:\Users\Documents\source\repos\TeamViewer\TeamViewer\bin\Debug\Images\image{counter}.jpeg");
                var imagepath = $@"C:\Users\Documents\source\repos\TeamViewer\TeamViewer\bin\Debug\Images\image{counter}.jpeg";
                return imagepath;
            }
        }
        public byte[] GetBytesOfImage(string path)
        {
            var image = new Bitmap(path);
            ImageConverter imageconverter = new ImageConverter();
            var imagebytes = ((byte[])imageconverter.ConvertTo(image, typeof(byte[])));
            return imagebytes;
        }

        public byte[] GetBytesOfImageJpeg(string path)
        {
            var image = new Bitmap(path);
            // Assumes myImage is the PNG you are converting
            ImageConverter imageconverter = new ImageConverter();
            using (var b = new Bitmap(image.Width, image.Height))
            {
                b.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var g = Graphics.FromImage(b))
                {
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(image, 0, 0);
                }
                // Now save b as a JPEG like you normally would
                var imagebytes = ((byte[])imageconverter.ConvertTo(b, typeof(byte[])));
                return imagebytes;
            }
        }

    }
}
