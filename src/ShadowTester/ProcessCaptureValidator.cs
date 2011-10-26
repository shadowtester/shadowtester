using System.Collections.Generic;


namespace ShadowTester
{
    public class ProcessCaptureValidator
    {
        private IProcessHandler processHandler;
        private IList<string> validProcesses;

        public ProcessCaptureValidator(IProcessHandler processHandler, IList<string> processes)
        {
            this.processHandler = processHandler;
            this.validProcesses = processes;
        }

        public bool CanCapture()
        {
            return validProcesses.Contains(processHandler.GetCurrentProcess());
        }
    }
}