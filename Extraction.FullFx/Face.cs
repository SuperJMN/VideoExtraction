namespace Recognition.FullFx
{
    using System;
    using System.Windows;
    using System.Windows.Media.Imaging;

    public class Face
    {
        public Guid Id { get; set; }
        public BitmapSource Bitmap { get; set; }
        public Rect Bounds { get; set; }
    }
}