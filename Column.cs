using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Exposito
{
    public class Column : IFrame
    {
        public Bitmap Bitmap { get { return GetBitmap(this.Height); } set { Bitmap = value; } }
        public int Height { get; set; } = 0;
        public int Width { get; set; } = 0;
        public List<IFrame> Frames { get; set; }
        public Column()
        {
            Frames = new List<IFrame>();
        }

        public void Add(IFrame frame)
        {
            Frames.Add(frame);

            if (this.Width == 0)
            {
                this.Width = frame.Width;
            }

            this.Height = CalculateHeight();

        }

        public float GetRatio()
        {
            return (float)this.Width / this.Height;
        }

        public void DrawStoryBoard(int galleryWidth, string savePath)
        {
            Bitmap board = GetBitmap(galleryWidth);
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 100L);
            var jpegCodec = Exposition.GetEncoderInfo("image/jpeg");
            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            board.Save(savePath, jpegCodec, encoderParams);
        }

        private Bitmap GetBitmap(int galleryHeight)
        {
            int galleryWidth = (int)(this.Width * galleryHeight / (float)this.Height);
            var newImage = new Bitmap(galleryWidth, galleryHeight, PixelFormat.Format24bppRgb);
            var currentHeight = 0;

            using (var newGraphics = Graphics.FromImage(newImage))
            {
                newGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                newGraphics.SmoothingMode = SmoothingMode.HighQuality;
                newGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                newGraphics.CompositingQuality = CompositingQuality.HighQuality;

                foreach (var frame in Frames)
                {
                    int newHeight = (int)Math.Round(galleryWidth / (float)frame.Width * frame.Height, 0);

                    newGraphics.DrawImage(frame.Bitmap, 0 , currentHeight, galleryWidth, newHeight);
                    currentHeight += newHeight;

                }

                return newImage;
            }
        }


        private int CalculateHeight()
        {
            int width = this.Width;
            int columnHeight = 0;
            int newFrameHight;

            foreach (IFrame frame in Frames)
            {
                float ratio = frame.GetRatio();
                newFrameHight = (int)(width / ratio);
                columnHeight += newFrameHight;
            }

            return columnHeight;
        }
    }
}
