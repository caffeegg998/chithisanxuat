using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductionDirectives.Models
{
    public class ProgressProgram
    {
        public class LineInfo
        {
            [JsonPropertyName("lineName")]
            public string LineName { get; set; }

            [JsonPropertyName("machine")]
            public List<MachineInfo> Machine { get; set; }
        }

        public class MachineInfo
        {
            [JsonPropertyName("machineName")]
            public string MachineName { get; set; }

            [JsonPropertyName("machineType")]
            public string MachineType { get; set; }

            [JsonPropertyName("isTwoSide")]
            public bool IsTwoSide { get; set; }

            [JsonPropertyName("numberOfModule")]
            public int NumberOfModule { get; set; }

            [JsonPropertyName("currentProgram")]
            public List<ProgramInfo> CurrentProgram { get; set; }
        }

        public class ProgramInfo
        {
            [JsonPropertyName("sideName")]
            public string SideName { get; set; }

            [JsonPropertyName("programName")]
            public string ProgramName { get; set; }
        }
    }
}
