using System.Windows;

namespace WpfClient
{
    using Recognition.FullFx;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var sut = new VideoFrameSource(@"D:\OneDrive\Exchange\Simpsons Game of thrones(720p_H.264-AAC).mp4");

            var fakeRecognitionService = new FakeRecognitionService();
            var vm = new MainViewModel(sut, fakeRecognitionService);
            var view = new MainWindow { DataContext = vm };
            view.Show();
        }
    }
}
