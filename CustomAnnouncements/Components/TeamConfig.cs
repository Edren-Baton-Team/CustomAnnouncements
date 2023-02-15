using PlayerRoles;
using Respawning;

namespace CustomAnnouncements.Components
{
    public class TeamConfig
    {
        public SpawnableTeamType team { get; set; }
        public string CassieScp { get; set; }
        public string CassieScps { get; set; }
        public bool Subtitles { get; set; }
        public bool GlitchCassieEnabled { get; set; } 
        public string GlitchCassieScp { get; set; }
        public string GlitchCassieScps { get; set; }
        public bool isSubtitlesGlitch { get; set; } 
    }
    public class SCPTermination
    {
        public RoleTypeId SCP { get; set; }
        public string Cassie { get; set; }
        public bool Subtitles { get; set; }
        public bool GlitchCassieEnabled { get; set; }
        public string GlitchCassie { get; set; }
        public bool isSubtitlesGlitch { get; set; } 
    }
    public class GeneratorActivated
    {
        public string Cassie { get; set; }
        public bool Subtitles { get; set; }
        public string CassieAllGenerated { get; set; }
        public bool isSubtitlesAllGenerated { get; set; }
        public bool GlitchCassieEnabled { get; set; } 
        public string GlitchCassie { get; set; }
        public string GlitchCassieAllGenerated { get; set; }
        public bool isSubtitlesGlitch { get; set; }
    }
}
