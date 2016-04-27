namespace Recognition.FullFx
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class FaceGroup : Collection<Face>
    {
        public FaceGroup(IEnumerable<Face> enumerable) : base(enumerable.ToList())
        {
        }

        public bool IsMessy { get; set; }
    }
}