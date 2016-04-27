namespace Recognition.FullFx
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Media.Imaging;

    public interface IRecognitionService
    {
        Task<IEnumerable<Face>> RecognizeFaces(BitmapSource image);
    }
}