using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Exposito
{
    //public interface IPictureItem
    //{

    //}

    //public class Gallery
    //{
    //    public List<IPictureItem> pictureItems { get; set; }
    //}
    

    public class Row
    {
        public List<Frame> frames { get; set; }
        public Row()
        {
            frames = new List<Frame>();
        }

        public void Add(Frame frame)
        {
            frames.Add(frame);
        }

        public void ShowItems()
        {
            foreach (Frame f in frames)
            {
                Console.WriteLine("frame  width:" + f.width.ToString() + ", height: " + f.height.ToString());
            }
        }
    }
}
