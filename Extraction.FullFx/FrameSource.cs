using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Media.Imaging;

namespace Recognition.FullFx
{
    using System.Collections.Generic;

    public class FrameSource : IFrameSource
    {
        public IObservable<Frame> Frames =>
            GetFiles()
                .Select((file, i) => new Frame(i, new BitmapImage(new Uri(file, UriKind.Relative))))
                .ToObservable()
                .Do(frame => frame.Bitmap.Freeze());

        private static IEnumerable<string> GetFiles()
        {
            var enumerateFiles = Directory
                .EnumerateFiles("Sample");
            return enumerateFiles;
        }
    }
}
