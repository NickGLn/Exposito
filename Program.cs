using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Exposito;

namespace iLigner
{
    class Program
    {
        static void Main(string[] args)
        {
            Row row = new Row();
            row.Add(new Frame(@"E:\CShartProjects\Exposito\1.jpg"));
            row.Add(new Frame(@"E:\CShartProjects\Exposito\2.jpg"));
            row.Add(new Frame(@"E:\CShartProjects\Exposito\3.jpg"));
            //row.Add(new Frame(@"E:\CShartProjects\Exposito\4.jpg"));
            //row.Add(new Frame(@"E:\CShartProjects\Exposito\5.jpg"));
            //row.Add(new Frame(@"E:\CShartProjects\Exposito\6.jpg"));
            //row.Add(new Frame(@"E:\CShartProjects\Exposito\7.jpg"));


            Exposition.Draw(row, 4000, @"E:\CShartProjects\Exposito\222.jpg");
        }
    }
}
