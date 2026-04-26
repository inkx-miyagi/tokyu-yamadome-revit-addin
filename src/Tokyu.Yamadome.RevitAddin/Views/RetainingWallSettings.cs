namespace Tokyu.Yamadome.RevitAddin.Views
{
    public sealed class RetainingWallSettings
    {
        public string InputSource { get; set; }
        public string WallKind { get; set; }
        public string FamilyType { get; set; }
        public string TopLevel { get; set; }
        public int TopOffsetMillimeters { get; set; }
        public string BottomLevel { get; set; }
        public int BottomOffsetMillimeters { get; set; }
        public string SpecSource { get; set; }
        public bool UpdateExistingWalls { get; set; }
        public bool WarnMissingFamilies { get; set; }
        public bool ApplyViewAfterCreate { get; set; }
    }
}

