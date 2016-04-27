namespace Recognition.FullFx
{
    using System;
    using System.Windows.Media.Imaging;

    public interface IFrameSource
    {
        IObservable<Frame> Frames { get; }
    }

    public class Frame
    {
        public Frame(int id, BitmapSource bmp)
        {
            Bitmap = bmp;
            Id = id;
        }

        public BitmapSource Bitmap { get; set; }
        public long Id { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}