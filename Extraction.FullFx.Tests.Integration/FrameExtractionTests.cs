namespace Recognition.FullFx.Tests.Integration
{
    using System.Reactive.Linq;
    using Xunit;

    public class FrameExtractionTests
    {
        private readonly VideoBitmapOrigin sut;

        public FrameExtractionTests()
        {
            sut = new VideoBitmapOrigin(@"D:\Downloads\Torrents\300[MKV.AC3.HDRip][Torrentmas.com]\300[MKV.AC3.HDRip][Torrentmas.com].mkv");
        }

        [Fact]
        public async void RecognitionTest()
        {
            var f = await sut.Images.FirstAsync();

        }
    }
}