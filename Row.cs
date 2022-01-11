using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Exposito
{  

    public class Row
    {
        public List<Frame> Frames { get; set; }
        public Row()
        {
            Frames = new List<Frame>();
        }

        public void Add(Frame frame)
        {
            Frames.Add(frame);
        }

        public void ShowItems()
        {
            foreach (Frame f in Frames)
            {
                Console.WriteLine("frame  width:" + f.Width.ToString() + ", height: " + f.Height.ToString());
            }
        }
    }



    public class Column
    {
        public List<Frame> Frames { get; set; }
        public Column()
        {
            Frames = new List<Frame>();
        }

        public void Add(Frame frame)
        {
            Frames.Add(frame);
        }

        public void ShowItems()
        {
            foreach (Frame f in Frames)
            {
                Console.WriteLine("frame  width:" + f.Width.ToString() + ", height: " + f.Height.ToString());
            }
        }
    }
}
