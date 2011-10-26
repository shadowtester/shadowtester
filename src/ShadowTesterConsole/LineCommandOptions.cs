using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace ShadowTesterConsole
{
    public class LineCommandOptions
    {
        [Option("n", "name", Required = true)]
        public string RecordName;

        [OptionList(null, "processes", Required = true, Separator = ',')]
        public IList<string> Processes;

        [Option(null, "path")]
        public string Path = ".";

        [HelpOption]
        public string GetUsage()
        {
            return "Sintax:\nshadowtester --name=name --processes=\"process1, process2, processN\" [--path=path]";
        }

        public void Trim()
        {
            RecordName = RecordName.Trim();
            Path = Path.Trim();
            Processes = (from p in Processes
                         select p.Trim()).ToList();
        }
    }
}