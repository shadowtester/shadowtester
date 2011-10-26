using System.IO;
using System.Runtime.InteropServices;
using NUnit.Framework;
using ShadowTester;

namespace ShadowTesterIntegrationTests
{
    [TestFixture]
    public class ScreenShooterTests
    {
        private string path = "screenshot.jpg";
        private string notFoundPath = @"C:\NON_EXISTING_DIRECTORY\screenshot.jpg";
        private ScreenShooter screenShooter;

        [SetUp]
        public void SetUp()
        {
            screenShooter = new ScreenShooter();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteFileIfExists(path);
            DeleteFileIfExists(notFoundPath);
        }

        [Test]
        public void CreateScreenShot()
        {
            screenShooter.Capture(path);
            if(!File.Exists(path))
            {
                Assert.Fail("Screenshot should have been created");
            }
        }

        [Test]
        public void CreateScreenShotWithWrongPath()
        {
            try
            {
                screenShooter.Capture(notFoundPath);
                Assert.Fail("Exception should have been thrown");
            }
            catch (ExternalException) { }
        }

        private void DeleteFileIfExists(string path)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }

    }
}
