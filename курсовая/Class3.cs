using System;
using System.Drawing;

namespace Test
{
    public class ImageManager
    {
        public Image LoadImage(string imageName)
        {
            try
            {
                return Image.FromFile($"pics/{imageName}.png");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}



