using NUnit.Framework;
using ShadowTester;

namespace ShadowTesterTests
{
    [TestFixture]
    public class RecordConfigurationTests
    {
        private RecordConfiguration configuration;

        [SetUp]
        public void SetUp()
        {
            configuration = new RecordConfiguration()
            {
                Name = "Name",
                Path = "Path",
                Period = 1000
            };
        }

        [Test]
        public void GetAndSetProperties()
        {
            Assert.AreEqual("Name", configuration.Name);
            Assert.AreEqual("Path", configuration.Path);
            Assert.AreEqual(1000, configuration.Period);
        }

        [Test]
        public void StoragePathIsComposedByPathAndName()
        {
            string storagePath = configuration.Path + "/" + configuration.Name + "/";
            Assert.AreEqual(storagePath, configuration.StoragePath);
        }
    }
}