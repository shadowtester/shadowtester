using NUnit.Framework;
using ShadowTester;

namespace ShadowTesterIntegrationTests
{
    [TestFixture]
    public class ProcessHandlerTests
    {

        [Test]
        public void CurrentProcessIsNotNull()
        {
            ProcessHandler processHandler = new ProcessHandler();
            Assert.IsNotNull(processHandler.GetCurrentProcess());
        }
    }
}