using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public class DirectBitmap : IDisposable // Thanks SaxxonPike
{
    public Bitmap Bitmap { get; private set; }
    public Int32[,] Bits { get; private set; }
    public bool Disposed { get; private set; }
    public int Height { get { return Bits.GetLength(0); } }
    public int Width  { get { return Bits.GetLength(1); } }
    public Size Size  { get { return new Size(Width, Height); } }

    protected GCHandle BitsHandle { get; private set; }

    public DirectBitmap(Size size) : this(size.Width, size.Height) { }
    public DirectBitmap(int width, int height)
    {
        Bits = new Int32[height, width];
        BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
        Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
    }

    public void Dispose()
    {
        if (Disposed) return;
        Disposed = true;
        Bitmap.Dispose();
        Bitmap = null;
        BitsHandle.Free();
    }

    public void SetPixel(int x, int y, Color color) { Bits[y, x] = color.ToArgb(); }
    public void SetPixel(int x, int y, Int32 color) { Bits[y, x] = color; }
}
