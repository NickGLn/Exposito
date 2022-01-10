using System.Drawing;

namespace Exposito
{
    public class Frame
    {
        public string path { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public Frame(string path)
        {

            Bitmap bitmap = new Bitmap(path);
            this.path = path;
            this.width = bitmap.Width;
            this.height = bitmap.Height;
        }

        public Bitmap GetBitmap()
        {
            Bitmap bitmap = new Bitmap(this.path);
            return bitmap;
        }

        public float GetRatio()
        {
            return (float)this.width / this.height;
        }
    }
}
