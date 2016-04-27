namespace Recognition.FullFx
{
    using System.Collections.Generic;
    using ReactiveUI;

    public class RecognizedFrame : ReactiveObject
    {
        private Frame frame;

        public RecognizedFrame(Frame frame, IEnumerable<Face> faces)
        {
            Frame = frame;
            Faces = faces;
        }

        public Frame Frame
        {
            get { return frame; }
            set { this.RaiseAndSetIfChanged(ref frame, value); }
        }

        public IEnumerable<Face> Faces { get; set; }

        public override string ToString()
        {
            return $"Frame: {Frame}";
        }
    }
}