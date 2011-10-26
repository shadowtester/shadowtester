namespace ShadowTester
{
    public class RecordConfiguration
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Period { get; set; }

        public string StoragePath
        {
            get { return Path + "/" + Name + "/"; }
        }

    }
}