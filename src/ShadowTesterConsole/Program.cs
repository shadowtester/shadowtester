using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using ShadowTester;

namespace ShadowTesterConsole
{

    public class Program
    {
        public static void Main(string[] args)
        {
            ICommandLineParser parser = new CommandLineParser();
            LineCommandOptions options = new LineCommandOptions();
            if (parser.ParseArguments(args, options))
            {
                if (ValidateOptions(options))
                {
                    int second = 1000;
                    int fps = 12;
                    IList<string> processes = options.Processes;

                    RecordConfiguration configuration = new RecordConfiguration()
                    {
                        Name = options.RecordName,
                        Path = options.Path,
                        Period = second / fps
                    };

                    RecordStorageManager storageManager = new RecordStorageManager();
                    storageManager.SetRecordDirectory(configuration.StoragePath);
                    IProcessHandler processHandler = new ProcessHandler();
                    IScreenShooter screenShooter = new ScreenShooter();
                    ProcessCaptureValidator validator = new ProcessCaptureValidator(processHandler, processes);
                    ProcessRecorder processRecorder = new ProcessRecorder(configuration, validator, screenShooter);

                    processRecorder.Start();
                    Console.WriteLine("Recording...");
                    Console.WriteLine("Press the Enter to stop recording.");
                    Console.ReadLine();
                    processRecorder.Stop();
                }
            }
            else
            {
                Console.WriteLine(options.GetUsage());
            }
        }

        private static bool ValidateOptions(LineCommandOptions options)
        {
            options.Trim();
            if (!Directory.Exists(options.Path))
            {
                Console.WriteLine("Path not exists");
                return false;
            }
            return true;
        }
    }
}