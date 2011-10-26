using System.IO;

namespace ShadowTester
{
    public class RecordStorageManager
    {
        public void SetRecordDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
