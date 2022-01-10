﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace Exposito
{
    public static class Exposition
    {
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == mimeType);
        }

        public static int GetCommonHeight(Row row, int newWidth)
        {
            int initialHeight = row.frames[0].height;
            Console.WriteLine(initialHeight);

            int newFrameWidth;
            int totalFramesWidth = 0;

            foreach (Frame f in row.frames)
            {
                newFrameWidth = initialHeight * f.width / f.height;
                totalFramesWidth += newFrameWidth;
                Console.WriteLine("newWidth: " + totalFramesWidth.ToString());
            }


            //Console.WriteLine("totalNewWidth: " + galleryWidth.ToString());

            float totalRatio = (float)initialHeight / totalFramesWidth;
            int commonHeight = (int)Math.Round(totalRatio * newWidth, 0);


            Console.WriteLine(totalRatio.ToString());
            Console.WriteLine(commonHeight.ToString());

            //Console.WriteLine("newHeight: " + galleryHight.ToString() + ", newWidth: " + adjWidth.ToString());

            return commonHeight;
        }

        public static void Draw(Row row, int galleryWidth, string savePath)
        {
            int galleryHeight = GetCommonHeight(row, galleryWidth);
            Console.WriteLine(galleryHeight);

            var newImage = new Bitmap(galleryWidth, (int)galleryHeight, PixelFormat.Format24bppRgb);
            var currentWidth = 0;

            using (var newGraphics = Graphics.FromImage(newImage))
            {
                newGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                newGraphics.SmoothingMode = SmoothingMode.HighQuality;
                newGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                newGraphics.CompositingQuality = CompositingQuality.HighQuality;

                foreach (var frame in row.frames)
                {
                    int newWidth = (int)Math.Round(galleryHeight * frame.GetRatio(), 0);

                    newGraphics.DrawImage(frame.GetBitmap(), currentWidth, 0, newWidth, galleryHeight);
                    currentWidth += newWidth;
                }

                var qualityParam = new EncoderParameter(Encoder.Quality, 100L);
                var jpegCodec = Exposition.GetEncoderInfo("image/jpeg");
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;

                newImage.Save(savePath, jpegCodec, encoderParams);
                //newImage.Save(@"E:\CShartProjects\Exposito\222.jpg", jpegCodec, encoderParams);


            }
        }
    }
}
