using CustomAnnouncements.Components;
using Exiled.API.Interfaces;
using PlayerRoles;
using Respawning;
using System.Collections.Generic;

namespace CustomAnnouncements
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
        public List<TeamConfig> Team { get; set; } = new List<TeamConfig>()
        {
            new TeamConfig()
            {
                team = SpawnableTeamType.NineTailedFox,
                CassieScp = "MtfUnit Epsilon 11 Designated %unitname% . HasEntered . AllRemaining . AwaitingRecontainment %count% ScpSubject",
                CassieScps = "MtfUnit Epsilon 11 Designated %unitname% . HasEntered . AllRemaining . AwaitingRecontainment %count% ScpSubjects",
                Subtitles = true,
                GlitchCassieEnabled = false,
                GlitchCassieScp = "",
                GlitchCassieScps = "",
                isSubtitlesGlitch = true,
            }
        }; 
        public List<SCPTermination> SCPTermination { get; set; } = new List<SCPTermination>()
        {
            new SCPTermination()
            {
                SCP = RoleTypeId.Scp173,
                Cassie = "SCP 1 7 3 successfully terminated. %attacker%",
                Subtitles = true,
                GlitchCassieEnabled = false,
                GlitchCassie = "",
                isSubtitlesGlitch = true,
            }
        }; 
        public List<GeneratorActivated> GeneratorActivated { get; set; } = new List<GeneratorActivated>()
        {
            new GeneratorActivated()
            {
                Cassie = "%count% out of 3 generators activated",
                Subtitles = true,
                CassieAllGenerated = "%count% out of 3 generators activated. All generators have been successfully engaged",
                isSubtitlesAllGenerated = true,
                GlitchCassieEnabled = false,
                GlitchCassie = "",
                GlitchCassieAllGenerated = "",
                isSubtitlesGlitch = true,
            }
        };
    }
}
