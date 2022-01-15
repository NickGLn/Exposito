using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Exposito
{
    class Program
    {
        static void Main(string[] args)
        {
            // Draw a column with several rows inside
            Row row= new Row();
            row.Add(new Frame(@"E:\CShartProjects\Exposito\7.jpg"));
            row.Add(new Frame(@"E:\CShartProjects\Exposito\2.jpg"));

            Column column = new Column();
            column.Add(new Frame(@"E:\CShartProjects\Exposito\1.jpg"));
            column.Add(new Frame(@"E:\CShartProjects\Exposito\3.jpg"));
            column.Add(row);

            Row row2 = new Row();
            row2.Add(new Frame(@"E:\CShartProjects\Exposito\3.jpg"));
            row2.Add(new Frame(@"E:\CShartProjects\Exposito\5.jpg"));
            row2.Add(column);

            Column column2 = new Column();
            column2.Add(new Frame(@"E:\CShartProjects\Exposito\4.jpg"));
            column2.Add(new Frame(@"E:\CShartProjects\Exposito\6.jpg"));
            column2.Add(row2);

            column2.DrawStoryBoard(1000, @"E:\CShartProjects\Exposito\ColumnStoryBoard.jpg");

            row2.DrawStoryBoard(1000, @"E:\CShartProjects\Exposito\RowStoryBoard.jpg");

        }
    }
}
