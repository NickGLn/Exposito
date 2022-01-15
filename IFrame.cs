using System.Drawing;

namespace Exposito
{
    public interface IFrame
    {
        public Bitmap Bitmap { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float GetRatio();
    }
}
