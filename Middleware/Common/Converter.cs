using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Middleware.Common
{
    public class Converter
    {
        //public static string ConvertImageToString(string path)
        //{
        //    using (Image image = Image.FromFile(path))
        //    {
        //        using (MemoryStream m = new MemoryStream())
        //        {
        //            image.Save(m, image.RawFormat);
        //            byte[] imageBytes = m.ToArray();

        //            // Convert byte[] to Base64 String
        //            string base64String = Convert.ToBase64String(imageBytes);
        //            return base64String;
        //        }
        //    }
        //}

        //public static string GetStringFromImage(Image image)
        //{
        //    if (image == null) return null;
        //    var ic = new ImageConverter();
        //    var buffer = (byte[])ic.ConvertTo(image, typeof(byte[]));
        //    return Convert.ToBase64String(buffer, Base64FormattingOptions.InsertLineBreaks);
        //}

        //public static Image GetImageFromString(string base64String)
        //{
        //    byte[] buffer = Convert.FromBase64String(base64String);
        //    var ic = new ImageConverter();
        //    return ic.ConvertFrom(buffer) as Image;
        //}
    }
}
