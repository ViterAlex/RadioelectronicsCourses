using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace XmlTypes
{
    public static class Helper
    {
        private const string BASE64_PREFIX = "data:image/PNG;base64,";
        /// <summary>
        /// Перевод строки base64 в изображение
        /// </summary>
        public static Image Base64ToImage(this string base64string)
        {
            if (base64string.StartsWith(BASE64_PREFIX) || base64string.StartsWith(BASE64_PREFIX.ToLower()))
            {
                base64string = base64string.Substring(BASE64_PREFIX.Length);
            }
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64string);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        /// <summary>
        /// Перевод изображения в строку base64
        /// </summary>
        public static string ImageToBase64(this Image image, bool appendPrefix = true)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return string.Format("{0}{1}", appendPrefix ? BASE64_PREFIX : string.Empty, Convert.ToBase64String(ms.ToArray()));
            }
        }
    }
}
