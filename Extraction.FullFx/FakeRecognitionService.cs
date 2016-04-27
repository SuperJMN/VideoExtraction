namespace Recognition.FullFx
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Media.Imaging;

    public class FakeRecognitionService : IRecognitionService
    {
        public Task<IEnumerable<Face>> RecognizeFaces(BitmapSource image)
        {
            var recognizeFaces = Task.FromResult<IEnumerable<Face>>(new Collection<Face>());
            return recognizeFaces;
        }
    }
}