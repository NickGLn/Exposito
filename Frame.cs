using System.Drawing;

namespace Exposito
{
    public class Frame
    {
        public Bitmap bitmap { get; set; }
        public string Path { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Frame(string path)
        {

            Bitmap bitmap = new Bitmap(path);
            this.bitmap = bitmap;
            this.Path = path;
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;
        }

        public Bitmap GetBitmap()
        {
            Bitmap bitmap = new Bitmap(this.Path);
            return bitmap;
        }

        public float GetRatio()
        {
            return (float)this.Width / this.Height;
        }
    }
}
