using System.Timers;

namespace ShadowTester
{
    public class ProcessRecorder
    {

        private Timer timer;
        private IScreenShooter screenShooter;
        private ProcessCaptureValidator validator;

        public int Period { get; private set; }
        public int NumCaptures { get; private set; }
        public string RecordName { get; private set; }
        public string Path { get; private set; }

        public ProcessRecorder(RecordConfiguration configuration, ProcessCaptureValidator validator, IScreenShooter screenShooter)
        {
            Period = configuration.Period;
            RecordName = configuration.Name;
            Path = configuration.StoragePath;
            NumCaptures = 0;
            this.validator = validator;
            this.screenShooter = screenShooter;
            
            initTimer();
        }

        private void initTimer()
        {
            timer = new Timer();
            timer.Elapsed += (object source, ElapsedEventArgs e) => Capture();
            timer.Interval = Period;
            timer.Enabled = true;
        }

        public void Capture()
        {
            if (validator.CanCapture())
            {
                screenShooter.Capture(Path + NumCaptures.ToString() + ".jpg");
                ++NumCaptures;
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}