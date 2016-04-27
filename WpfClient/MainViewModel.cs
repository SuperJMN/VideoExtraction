namespace WpfClient
{
    using System.Reactive.Linq;
    using ReactiveUI;
    using Recognition.FullFx;
    using System.Threading.Tasks;
    using DynamicData;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Threading.Tasks;
    using DynamicData.Binding;

    public class MainViewModel : ReactiveObject
    {
        private readonly IRecognitionService recognitionService;

        public MainViewModel(IFrameSource frameSource, IRecognitionService recognitionService)
        {
            this.recognitionService = recognitionService;

            var units = frameSource.Frames
                .SelectMany(source => RecognizeFrame(source).ToObservable());

            Frames = new ObservableCollectionExtended<RecognizedFrame>();
            units.Aggregate(new List<Guid>(),
                (guids, frame) =>
                {
                    IEnumerable<Guid> collection = frame.Faces.Select(face => face.Id);
                    guids.AddRange(collection);
                    return guids;
                }).TakeLast(1).Subscribe(guids => guids.ForEach(guid => Console.WriteLine(guid)));

            var incomingFrames = units.ToObservableChangeSet()
                .ObserveOnDispatcher();

            incomingFrames
                .Bind(Frames)
                .ObserveOnDispatcher()
                .DisposeMany()
                .Subscribe();
        }

        public ObservableCollectionExtended<RecognizedFrame> Frames { get; set; }

        private async Task<RecognizedFrame> RecognizeFrame(Frame source)
        {            
            var recognition = await recognitionService.RecognizeFaces(source.Bitmap);
            return new RecognizedFrame(source, recognition);
        }       
    }
}