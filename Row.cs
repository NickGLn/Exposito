using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Exposito
{   
    public class Row : IFrame
    {
        public Bitmap Bitmap { get { return GetBitmap(this.Width); } set { Bitmap = value; } }
        public int Height { get; set; } = 0;
        public int Width { get; set; } = 0;
        public List<IFrame> Frames { get; set; } = new List<IFrame>();

        public void Add(IFrame frame)
        {
            Frames.Add(frame);
            if (this.Height == 0)
            {
                this.Height = frame.Height;
            }

            this.Width = CalculateWidth();
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

        private Bitmap GetBitmap(int galleryWidth)
        {
            int galleryHeight = (int)(this.Height * galleryWidth / (float)this.Width);
            var newImage = new Bitmap(galleryWidth, galleryHeight, PixelFormat.Format24bppRgb);
            var currentWidth = 0;

            using (var newGraphics = Graphics.FromImage(newImage))
            {
                newGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                newGraphics.SmoothingMode = SmoothingMode.HighQuality;
                newGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                newGraphics.CompositingQuality = CompositingQuality.HighQuality;

                foreach (var frame in Frames)
                {
                    float coeff = galleryWidth / (float)frame.Width;
                    int newWidth = (int)Math.Round(galleryHeight / (float)frame.Height * frame.Width, 0);

                    newGraphics.DrawImage(frame.Bitmap, currentWidth, 0, newWidth, galleryHeight);
                    currentWidth += newWidth;
                }

                return newImage;
            }
        }

        private int CalculateWidth()
        {
            int height = this.Height;
            int rowWidth = 0;
            int newFrameWidth;

            foreach (IFrame frame in Frames)
            {
                float ratio = frame.GetRatio();
                newFrameWidth = (int)(height * ratio);
                rowWidth += newFrameWidth;
            }

            return rowWidth;
        }
    }
}
