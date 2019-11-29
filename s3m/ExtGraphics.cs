using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

/// <summary>
/// ExtGraphics
/// D. de Haas
/// 28 november 2003
/// </summary>
public class ExtGraphics
{
    private Bitmap bmp1,bmp2;
    private Color bc1,bc2;

    public ExtGraphics(Bitmap b1, Bitmap b2)
    {
        this.bmp1 = b1;
        this.bmp2 = b2;
    }

    public bool FloodFill(int X, int Y)
    {
        if ((X < 0) || (X >= bmp1.Width) || (Y < 0) || (Y >= bmp1.Height)) 
            return false;

        bc1 = bmp1.GetPixel(X, Y);
        bc2 = bmp2.GetPixel(X, Y);
        if (bc1.ToArgb() != bc2.ToArgb())
            return false;

        Stack points = new Stack();

        points.Push(new Point(X, Y));
        do
        {
            Point p = (Point)points.Pop();
            bmp1.SetPixel(p.X, p.Y, Color.FromArgb(128, 255, 0, 0));

            if (this.CanUp(p.X, p.Y)) 
                points.Push(new Point(p.X, p.Y - 1));
            if (this.CanRight(p.X, p.Y)) 
                points.Push(new Point(p.X + 1, p.Y));
            if (this.CanDown(p.X, p.Y)) 
                points.Push(new Point(p.X, p.Y + 1));
            if (this.CanLeft(p.X, p.Y)) 
                points.Push(new Point(p.X - 1, p.Y));
        }
        while (points.Count > 0);

        return true;
    }


    private bool CanUp(int X, int Y)
    {
        return ((Y > 0)  && bmp2.GetPixel(X, Y - 1) == bmp1.GetPixel(X, Y - 1));
    }

    private bool CanRight(int X, int Y)
    {
        return ((X < bmp1.Width - 1)  && bmp2.GetPixel(X+1, Y) == bmp1.GetPixel(X+1, Y));
    }

    private bool CanDown(int X, int Y)
    {
        return ((Y < bmp1.Height - 1)  && bmp2.GetPixel(X, Y + 1) == bmp1.GetPixel(X, Y + 1));
    }

    private bool CanLeft(int X, int Y)
    {
        return ((X > 0)  && bmp2.GetPixel(X-1, Y) == bmp1.GetPixel(X-1, Y ));
    }

}
