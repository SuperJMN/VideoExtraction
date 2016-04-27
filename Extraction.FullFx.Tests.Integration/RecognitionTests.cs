using System;
using System.Linq;

namespace Recognition.FullFx.Tests.Integration
{
    using System.Windows.Media.Imaging;
    using Properties;
    using Xunit;

    public class RecognitionTests
    {
        private readonly RecognitionService sut;

        public RecognitionTests()
        {
            sut = new RecognitionService(Settings.Default.ApiKey);
        }

        [Fact]
        public async void RecognitionTest()
        {
            var faces = await sut.RecognizeFaces(new BitmapImage(new Uri("Resources\\faces.jpg", UriKind.Relative)));
            Assert.True(faces.Any());
        }

        [Fact]
        public async void GroupingTest()
        {
            var bitmapImage = new BitmapImage(new Uri("Resources\\faces.jpg", UriKind.Relative));
            bitmapImage.Freeze();
            var faces = await sut.RecognizeFaces(bitmapImage);
            var groups = await sut.Group(faces);
            Assert.True(groups.Any());
        }
    }
}
