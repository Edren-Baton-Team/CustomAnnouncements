# CustomAnnouncements
Plugin to change default CASSIE lines when certain event happens. 

```yml
CustomAnnouncements:
  is_enabled: true
  debug: true
  team:
  - team: NineTailedFox
    cassie_scp: MtfUnit Epsilon 11 Designated %unitname% . HasEntered . AllRemaining . AwaitingRecontainment %count% ScpSubject
    cassie_scps: MtfUnit Epsilon 11 Designated %unitname% . HasEntered . AllRemaining . AwaitingRecontainment %count% ScpSubjects
    subtitles: true
    glitch_cassie_enabled: false
    glitch_cassie_scp: MtfUnit
    glitch_cassie_scps: MtfUnit
    is_subtitles_glitch: true
  s_c_p_termination:
  - s_c_p: Scp173
    cassie: SCP 1 7 3 successfully terminated. %attacker%
    subtitles: true
    glitch_cassie_enabled: false
    glitch_cassie: ''
    is_subtitles_glitch: true
  generator_activated:
  - cassie: '%count% out of 3 generators activated'
    subtitles: true
    cassie_all_generated: '%count% out of 3 generators activated. All generators have been successfully engaged'
    is_subtitles_all_generated: true
    glitch_cassie_enabled: false
    glitch_cassie: ''
    glitch_cassie_all_generated: ''
    is_subtitles_glitch: true
```
