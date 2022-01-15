using System.Drawing;

namespace Exposito
{
    public class Frame : IFrame
    {
        public Bitmap Bitmap { get; set; }
        public string Path { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Frame(string path)
        {

            Bitmap bitmap = new Bitmap(path);
            this.Bitmap = bitmap;
            this.Path = path;
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;
        }

        public float GetRatio()
        {
            return (float)this.Width / this.Height;
        }
    }
}
