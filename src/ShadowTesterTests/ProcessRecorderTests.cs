using NUnit.Framework;
using Rhino.Mocks;
using ShadowTester;

namespace ShadowTesterTests
{
    [TestFixture]
    public class ProcessRecorderTests
    {
        private IScreenShooter screenShooterMock;
        private IProcessHandler processHandlerStub;
        private ProcessCaptureValidator validator;
        private ProcessRecorder processRecorder;

        [SetUp]
        public void SetUp()
        {
            screenShooterMock = MockRepository.GenerateStrictMock<IScreenShooter>();
            screenShooterMock.Expect(m => m.Capture("")).IgnoreArguments().Repeat.Once();
            processHandlerStub = MockRepository.GenerateStub<IProcessHandler>();
            processHandlerStub.Expect(m => m.GetCurrentProcess()).Return("process");
            validator = new ProcessCaptureValidator(processHandlerStub, new string[] { "process" });
            processRecorder = new ProcessRecorder(
                new RecordConfiguration() { Name = "", Path = "", Period = 1000 }, validator, screenShooterMock);
        }

        [Test]
        public void FirstTimeNumCapturesIsZero()
        {
            Assert.AreEqual(0, processRecorder.NumCaptures);
        }

        [Test]
        public void ProcessRecorderCallsScreenShooterWhenCanCapture()
        {
            processRecorder.Capture();

            screenShooterMock.VerifyAllExpectations();
        }

        [Test]
        public void IncrementNumberOfCapturesWhenScreenShotIsTaken()
        {
            int initialNumCaptures = processRecorder.NumCaptures;

            processRecorder.Capture();

            screenShooterMock.VerifyAllExpectations();
            Assert.Greater(processRecorder.NumCaptures, initialNumCaptures);

        }
    }
}