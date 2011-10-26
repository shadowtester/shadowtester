using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using ShadowTester;

namespace ShadowTesterTests
{
    [TestFixture]
    public class ProcessCapturerValidatorTests
    {
        [Test]
        public void CanCaptureWhenCurrentProcessIsExpected()
        {
            IList<string> expectedProcesses = new string[] { "process" };
            IProcessHandler processHandlerStub = MockRepository.GenerateStub<IProcessHandler>();
            processHandlerStub.Expect(s => s.GetCurrentProcess()).Return("process");
            ProcessCaptureValidator validator = new ProcessCaptureValidator(processHandlerStub, expectedProcesses);

            bool result = validator.CanCapture();

            Assert.True(result);
        }

        [Test]
        public void CannotCaptureWhenCurrentProcessIsNotExpected()
        {
            IList<string> expectedProcesses = new string[] { "process" };
            IProcessHandler processHandlerStub = MockRepository.GenerateStub<IProcessHandler>();
            processHandlerStub.Expect(s => s.GetCurrentProcess()).Return("processNotFound");
            ProcessCaptureValidator validator = new ProcessCaptureValidator(processHandlerStub, expectedProcesses);

            bool result = validator.CanCapture();

            Assert.False(result);
        }
    }
}