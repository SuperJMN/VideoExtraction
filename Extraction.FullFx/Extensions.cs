namespace Recognition.FullFx
{
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using Microsoft.ProjectOxford.Face.Contract;

    public static class Extensions
    {
        public static Rect ToRect(this FaceRectangle face)
        {
            return new Rect(face.Left, face.Top, face.Width, face.Height);
        }

        public static Stream ToStream(this System.Windows.Media.Imaging.BitmapSource image)
        {
            var memoryStream = new MemoryStream();
            var encore = new JpegBitmapEncoder();
            encore.Frames.Add(BitmapFrame.Create(image));
            encore.Save(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

        public static byte[]  ToByteArray(this Stream stream)
        {
            var lenght = stream.Length;
            var bytes = new byte[lenght];
            stream.Write(bytes, 0, (int) lenght);
            return bytes;            
        }
    }
}