using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Server;
using MEC;
using PlayerRoles;
using System;
using System.Linq;
using Cassie = Exiled.API.Features.Cassie;
using Player = Exiled.API.Features.Player;

namespace CustomAnnouncements
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "CustomAnnouncements";
        public override string Name => "CustomAnnoun";
        public override string Author => "Rysik5318";
        public override Version Version { get; } = new Version(1, 0, 0);
        public static Plugin plugin;
        public int GeneratorState = 0;
        public override void OnEnabled()
        {
            plugin = this;
            GeneratorState = 0;
            Exiled.Events.Handlers.Server.RespawningTeam += OnRespawningTeam;
            Exiled.Events.Handlers.Map.AnnouncingScpTermination += OnAnnouncingScpTermination;
            Exiled.Events.Handlers.Map.GeneratorActivated += OnGeneratorActivated;
        }
        public override void OnDisabled()
        {
            plugin = null;

            base.OnDisabled();
        }
        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            foreach (var cfg in plugin.Config.GeneratorActivated)
            {
                if (cfg.Cassie != string.Empty)
                {
                    var glitch = cfg.GlitchCassieEnabled;
                    GeneratorState++;
                    Timing.CallDelayed(0.1f, () =>
                    {
                        Cassie.Clear();
                        if (GeneratorState == 3 && !glitch)
                            Cassie.Message(cfg.CassieAllGenerated.Replace("%count%", $"{GeneratorState}"), isSubtitles: cfg.Subtitles);
                        else if (!glitch)
                            Cassie.Message(cfg.Cassie.Replace("%count%", $"{GeneratorState}"), isSubtitles: cfg.Subtitles);
                        else if (GeneratorState == 3 && glitch)
                            Cassie.Message(cfg.GlitchCassieAllGenerated.Replace("%count%", $"{GeneratorState}"), isSubtitles: cfg.isSubtitlesGlitch);
                        else if (glitch)
                            Cassie.Message(cfg.GlitchCassie.Replace("%count%", $"{GeneratorState}"), isSubtitles: cfg.isSubtitlesGlitch);
                    });
                }
            }
        }

        public void OnAnnouncingScpTermination(AnnouncingScpTerminationEventArgs ev)
        {
            foreach (var cfg in plugin.Config.SCPTermination)
            {
                if (ev.Role == cfg.SCP && cfg.Cassie != string.Empty)
                {
                    Timing.CallDelayed(0.2f, () =>
                    {
                        Cassie.Clear();
                        if (cfg.GlitchCassieEnabled && Player.List.Any(x => x.Role.Type is RoleTypeId.Scp079))
                            Cassie.Message(cfg.GlitchCassie.Replace("%attacker%", $"{ev.TerminationCause}"), isSubtitles: cfg.isSubtitlesGlitch);
                        else
                            Cassie.Message(cfg.Cassie.Replace("%attacker%", $"{ev.TerminationCause}"), isSubtitles: cfg.Subtitles);
                    });
                }
            }
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            foreach (var cfg in plugin.Config.Team)
            {
                if (ev.NextKnownTeam == cfg.team && (cfg.CassieScp != string.Empty || cfg.CassieScps != string.Empty))
                {
                    var count = Player.List.Count(x => x.IsScp);
                    var glitch = cfg.GlitchCassieEnabled;
                    var s079 = Player.List.Any(x => x.Role.Type is RoleTypeId.Scp079);
                    Timing.CallDelayed(0.1f, () =>
                    {
                        foreach (Player ply in ev.Players.Where(x => x.IsAlive))
                        {
                            Cassie.Clear();
                            if (count == 1 && !glitch)
                                Cassie.Message(cfg.CassieScp.Replace("%playerspawn%", $"{ev.Players.Count}").Replace("%count%", $"{count}").Replace("%unitname%", $"{ply.UnitName.Replace("-", "")}"), isSubtitles: cfg.Subtitles);
                            else if (count != 1 && !glitch)
                                Cassie.Message(cfg.CassieScps.Replace("%playerspawn%", $"{ev.Players.Count}").Replace("%count%", $"{count}").Replace("%unitname%", $"{ply.UnitName.Replace("-", "")}"), isSubtitles: cfg.Subtitles);
                            else if (glitch && s079 && count == 1)
                                Cassie.Message(cfg.GlitchCassieScp.Replace("%playerspawn%", $"{ev.Players.Count}").Replace("%count%", $"{count}").Replace("%unitname%", $"{ply.UnitName.Replace("-", "")}"), isSubtitles: cfg.isSubtitlesGlitch);
                            else if (glitch && s079 && count != 1)
                                Cassie.Message(cfg.GlitchCassieScps.Replace("%playerspawn%", $"{ev.Players.Count}").Replace("%count%", $"{count}").Replace("%unitname%", $"{ply.UnitName.Replace("-", "")}"), isSubtitles: cfg.isSubtitlesGlitch);
                        }
                    });
                }
            }
        }
    }
}
