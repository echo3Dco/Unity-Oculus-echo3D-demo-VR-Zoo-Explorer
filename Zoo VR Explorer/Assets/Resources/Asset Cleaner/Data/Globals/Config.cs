namespace Asset_Cleaner {
    class Config {
        // serialized
        public bool MarkRed;
        public string IgnorePathContainsCombined;
        public bool ShowInfoBox;
        public bool RebuildCacheOnDemand;

        // todo make type array
        public bool IgnoreMaterial;
        public bool IgnoreScriptable;

        // serialized only while window is opened
        public bool Locked;

        // non-serialized
        public string[] IgnorePathContains;
        public string InitializationTime;
    }
}