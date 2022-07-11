////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    public class ProjectJsonDumpModel
    {
        public DateTime Created { get; set; } = DateTime.Now;

        public string Version { get; set; }

        public object Dump { get; set; }
    }
}
