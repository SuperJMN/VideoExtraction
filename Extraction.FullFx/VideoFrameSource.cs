namespace Recognition.FullFx
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Windows.Media.Imaging;
    using DotImaging;
    using FileCapture = DotImaging.FileCapture;

    public class VideoFrameSource : IFrameSource
    {
        private readonly string path;

        public VideoFrameSource(string path)
        {
            this.path = path;
        }

        private IEnumerable<Frame> GetEnumerable(int pos, int length, int skip)
        {
            using (var capture = new FileCapture(path))
            {
                capture.Seek(pos, SeekOrigin.Begin);

                for (var i = 0; i < length; i++)
                {
                    var bmp = GetCurrentFrame(capture);
                    capture.Seek(skip);

                    yield return new Frame(i, bmp);
                }
            }
        }

        private BitmapSource GetCurrentFrame(FileCapture capture)
        {
            using (var r = capture.ReadAs<Bgr<byte>>())
            {
                using (var img = new Image<Bgr<byte>>(r.ImageData, r.Width, r.Height, r.Stride))
                {
                    var bgrs = img.ToBgr();

                    var bmp = bgrs.ToBitmapSource();
                    bmp.Freeze();

                    return bmp;

                }
            }
        }

        public IObservable<Frame> Frames => GetEnumerable(0, 100, 10).ToObservable(new EventLoopScheduler());
    }
}