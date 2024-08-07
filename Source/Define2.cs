﻿namespace LeagueAI.Libraries
{
    public sealed partial class DEFINE
    {
        #region GameCfg Template
        public static string GameCfgTemplate { get; set; } = @"
[FloatingText]
Special_Enabled=1
Score_Enabled=1
QuestReceived_Enabled=1
ManaDamage_Enabled=1
Level_Enabled=1
Invulnerable_Enabled=1
Heal_Enabled=1
Gold_Enabled=1
Experience_Enabled=0
EnemyDamage_Enabled=1
Dodge_Enabled=1
Damage_Enabled=1

[General]
ClampCastTargetLocationWithinMaxRange=0
SystemMouseSpeed=0
Height=1080
Width=1920
TargetChampionsOnlyAsToggle=0
MinimizeCameraMotion=0
EnableScreenShake=1
EnableLeftMouseButtonAttackMove=0
EnableLightFx=0
EnableCustomAnnouncer=1
AlwaysShowExtendedTooltip=1
CfgVersion=13.13.518.539
WindowMode=1
WaitForVerticalSync=0
ThemeMusic=0
SnapCameraOnRespawn=0
ShowTurretRangeIndicators=1
ShowGodray=1
ShowCursorLocator=0
RelativeTeamColors=1
RecommendJunglePaths=1
PreferOpenGLLegacyMode=0
PreferDX9LegacyMode=0
PredictMovement=1
OSXMouseAcceleration=0
HideEyeCandy=0
GameMouseSpeed=10
EnableTargetedAttackMove=1
EnableAudio=1
CursorScale=0.5000
CursorOverride=0
BindSysKeys=0
AutoAcquireTarget=0
UserSetResolution=1

[HUD]
ObjectiveVoteScale=1.0000
ShopScale=0.4444
PracticeToolScale=1.0000
MiddleMouseScrollSpeed=0.5000
DeathRecapScale=1.0000
NameTagDisplay=1
ChatChannelVisibility=1
ShowStatsPanel_StatStones=0
ShowPlayerStats=1
ShowPlayerPerks=0
ShowFPSAndLatency=1
ShowSpellRecommendation=1
ShowHealthBarShake=1
ShowChampionIndicator=0
ShowAllChannelChatSpectator=0
HideEnemySummonerEmotes=0
SmartCastWithIndicator_CastWhenNewSpellSelected=1
SmartCastOnKeyRelease=0
ShowTimestamps=0
ShowTeamFramesOnLeft=1
ShowSummonerNamesInScoreboard=0
ShowSummonerNames=1
ShowSpellRecommendations=1
ShowSpellCosts=0
ShowOffScreenPointsOfInterest=1
ShowNeutralCamps=1
ShowAttackRadius=1
ShowAlliedChat=1
ShowAllChannelChat=0
ScrollSmoothingEnabled=0
NumericCooldownFormat=1
MirroredScoreboard=1
MinimapScale=1.0000
MinimapMoveSelf=1
MiddleClickDragScrollEnabled=0
MapScrollSpeed=0.5000
KeyboardScrollSpeed=0.6600
GlobalScale=0.0000
FlipMiniMap=0
FlashScreenWhenStunned=1
FlashScreenWhenDamaged=1
EternalsMilestoneDisplayMode=0
EnableLineMissileVis=1
EmoteSize=0
EmotePopupUIDisplayMode=0
DrawHealthBars=1
DisableHudSpellClick=0
ChatScale=36
CameraLockMode=0
AutoDisplayTarget=1

[LossOfControl]
ShowSlows=0
LossOfControlEnabled=1

[Performance]
ShadowQuality=4
FrameCapType=2
EnvironmentQuality=4
EffectsQuality=4
CharacterQuality=4
EnableGrassSwaying=1
EnableFXAA=1
EnableHUDAnimations=0
AutoPerformanceSettings=0

[Voice]
InputDevice=Default System Device
InputVolume=0.5000
ActivationSensitivity=0.6500
InputMode=0
ShowVoicePanelWithScoreboard=1
ShowVoiceChatHalos=1

[Volume]
VoiceVolume=0.7500
VoiceMute=0
SfxVolume=0.7500
SfxMute=0
PingsVolume=0.7500
PingsMute=0
MusicVolume=0.3000
MusicMute=0
MasterVolume=0.4800
MasterMute=0
AnnouncerVolume=0.7500
AnnouncerMute=0
AmbienceVolume=0.7500
AmbienceMute=0

[ColorPalette]
ColorPalette=0

[MapSkinOptions]
MapSkinOptionDisableWorlds=0
MapSkinOptionDisableURF=0
MapSkinOptionDisableStarGuardian=0
MapSkinOptionDisableSnowdown=0
MapSkinOptionDisableProject=0
MapSkinOptionDisablePopstar=0
MapSkinOptionDisablePoolParty=0
MapSkinOptionDisableOdyssey=0
MapSkinOptionDisableMSI=0
MapSkinOptionDisableLunarRevel=0
MapSkinOptionDisableArcade=0

[Chat]
ReplayNativeOffsetY=0.0000
ReplayNativeOffsetX=0.0000
NativeOffsetY=0.0000
NativeOffsetX=0.0000
EnableChatFilter=1

[TFTHUD]
EnableChat=1

[ItemShop]
NativeOffsetY=0.0046
NativeOffsetX=-0.0021
CurrentTab=1
InvertDisplayOrder=0
InventoryPanelPinned=0
ConsumablesPanelPinned=0
BootsPanelPinned=0

[Replay]
EnableDirectedCamera=1

[Mobile]
LastTickerTime=
AppRegion=
SelectedQueue=1090
iOSMetalUserId=-1
iOSMetalPercentEnabled=0
Camera Height=0
OfferedTutorial=0

[Highlights]
VideoQuality=0
VideoFrameRate=60
ScaleVideo=720
AudioQuality=1

[TFTChat]
NativeOffsetY=0.0000
NativeOffsetX=0.0000

[Accessibility]
ColorLevel=0.5000
ColorGamma=0.5000
ColorContrast=0.5000
ColorBrightness=0.5000


[Ftux]
SenOffscreenPing=1
";
        #endregion
        #region InputINI Template
        public static string InputINITemplate { get; set; } = @"
[GameEvents]
evtToggleReplayTimeControls=[<Unbound>]
evtPracticeToolTurretInv=null
evtPracticeToolToggleTurrets=null
evtPracticeToolToggleMinions=null
evtPracticeToolTeleport=null
evtPracticeToolSpawnJunglePlants=null
evtPracticeToolSpawnJungle=null
evtPracticeToolSpawnDragonOcean=null
evtPracticeToolSpawnDragonEarth=null
evtPracticeToolSpawnDragonFire=null
evtPracticeToolSpawnDragonElder=null
evtPracticeToolSpawnDragonAir=null
evtPracticeToolRemoveTargetDummy=null
evtPracticeToolSpawnEnemyTargetDummy=null
evtPracticeToolSpawnAlliedTargetDummy=null
evtPracticeToolRevive=null
evtPracticeToolResetPAR=null
evtPracticeToolResetHP=null
evtPracticeToolResetGame=null
evtPracticeToolResetCooldown=null
evtPracticeToolLockLevel=null
evtPracticeToolIncLevel=null
evtPracticeToolIncGold=null
evtPracticeToolIncGameClock=null
evtToggleReplayPause=[<Unbound>]
evtUseVisionItem=[4]
evtUseItem7=[b]
evtUseItem6=[7]
evtUseItem5=[6]
evtUseItem4=[5]
evtUseItem3=[3]
evtUseItem2=[2]
evtUseItem1=[1]
evtToggleMinionHealthBars=
evtSysMenu=[Esc]
evtSmartPlusSelfCastWithIndicatorVisionItem=
evtSmartPlusSelfCastWithIndicatorSpell4=
evtSmartPlusSelfCastWithIndicatorSpell3=
evtSmartPlusSelfCastWithIndicatorSpell2=
evtSmartPlusSelfCastWithIndicatorSpell1=
evtSmartPlusSelfCastWithIndicatorItem6=
evtSmartPlusSelfCastWithIndicatorItem5=
evtSmartPlusSelfCastWithIndicatorItem4=
evtSmartPlusSelfCastWithIndicatorItem3=
evtSmartPlusSelfCastWithIndicatorItem2=
evtSmartPlusSelfCastWithIndicatorItem1=
evtSmartPlusSelfCastWithIndicatorAvatarSpell2=
evtSmartPlusSelfCastWithIndicatorAvatarSpell1=
evtSmartPlusSelfCastVisionItem=
evtSmartPlusSelfCastSpell4=
evtSmartPlusSelfCastSpell3=
evtSmartPlusSelfCastSpell2=
evtSmartPlusSelfCastSpell1=
evtSmartPlusSelfCastItem6=
evtSmartPlusSelfCastItem5=
evtSmartPlusSelfCastItem4=
evtSmartPlusSelfCastItem3=
evtSmartPlusSelfCastItem2=
evtSmartPlusSelfCastItem1=
evtSmartPlusSelfCastAvatarSpell2=
evtSmartPlusSelfCastAvatarSpell1=
evtSmartCastWithIndicatorVisionItem=
evtSmartCastWithIndicatorSpell4=
evtSmartCastWithIndicatorSpell3=
evtSmartCastWithIndicatorSpell2=
evtSmartCastWithIndicatorSpell1=
evtSmartCastWithIndicatorItem6=
evtSmartCastWithIndicatorItem5=
evtSmartCastWithIndicatorItem4=
evtSmartCastWithIndicatorItem3=
evtSmartCastWithIndicatorItem2=
evtSmartCastWithIndicatorItem1=
evtSmartCastWithIndicatorAvatarSpell2=
evtSmartCastWithIndicatorAvatarSpell1=
evtSmartCastVisionItem=[Shift][4]
evtSmartCastSpell4=[Shift][r]
evtSmartCastSpell3=[Shift][e]
evtSmartCastSpell2=[Shift][w]
evtSmartCastSpell1=[Shift][q]
evtSmartCastItem6=[Shift][7]
evtSmartCastItem5=[Shift][6]
evtSmartCastItem4=[Shift][5]
evtSmartCastItem3=[Shift][3]
evtSmartCastItem2=[Shift][2]
evtSmartCastItem1=[Shift][1]
evtSmartCastAvatarSpell2=[Shift][f]
evtSmartCastAvatarSpell1=[Shift][d]
evtShowVoicePanel=[m]
evtShowSummonerNames=
evtShowScoreBoard=[<Unbound>]
evtShowHealthBars=
evtShowCharacterMenu=[c]
evtSelfCastVisionItem=[Alt][4]
evtSelfCastSpell4=[Alt][r],
evtSelfCastSpell3=[Alt][e],
evtSelfCastSpell2=[Alt][w],
evtSelfCastSpell1=[Alt][q],
evtSelfCastItem6=[Alt][7]
evtSelfCastItem5=[Alt][6]
evtSelfCastItem4=[Alt][5]
evtSelfCastItem3=[Alt][3]
evtSelfCastItem2=[Alt][2]
evtSelfCastItem1=[Alt][1]
evtSelfCastAvatarSpell2=[Alt][f],
evtSelfCastAvatarSpell1=[Alt][d],
evtSelectSelf=[F1]
evtSelectAlly4=[F5]
evtSelectAlly3=[F4]
evtSelectAlly2=[F3]
evtSelectAlly1=[F2]
evtScrollUp=[Up Arrow]
evtScrollRight=[Right Arrow]
evtScrollLeft=[Left Arrow]
evtScrollDown=[Down Arrow]
evtRadialEmotePlaySlot4=
evtRadialEmotePlaySlot3=
evtRadialEmotePlaySlot2=
evtRadialEmotePlaySlot1=
evtRadialEmotePlaySlot0=
evtRadialEmoteOpen=
evtRadialEmoteInstantOpen=[t]
evtPushToTalk=[<Unbound>]
evtPlayerStopPosition=[s]
evtPlayerPingVisionNeeded=
evtPlayerPingVisionCleared=
evtPlayerPingRadialDanger=
evtPlayerPingPush=
evtPlayerPingOMW=
evtPlayerPingMIA=
evtPlayerPingHold=
evtPlayerPingComeHere=
evtPlayerPingBait=
evtPlayerPingAreaIsWarded=[h]
evtPlayerPingAllIn=
evtPlayerMoveClick=[Button 2]
evtPlayerHoldPosition=[h]
evtPlayerCursorPingAreaIsWarded=[u]
evtPlayerAttackOnlyClick=
evtPlayerAttackMoveClick=[Shift][Button 2]
evtPlayerAttackMove=[a],[x]
evtPetMoveClick=[Alt][Button 2],[Ctrl][Button 2]
evtOpenShop=[p],[o]
evtOnUIMouse4Pan=[Button 3]
evtNormalCastVisionItem=
evtNormalCastSpell4=
evtNormalCastSpell3=
evtNormalCastSpell2=
evtNormalCastSpell1=
evtNormalCastItem6=
evtNormalCastItem5=
evtNormalCastItem4=
evtNormalCastItem3=
evtNormalCastItem2=
evtNormalCastItem1=
evtNormalCastAvatarSpell2=
evtNormalCastAvatarSpell1=
evtLevelSpell4=[Ctrl][r]
evtLevelSpell3=[Ctrl][e]
evtLevelSpell2=[Ctrl][w]
evtLevelSpell1=[Ctrl][q]
evtEmoteToggle=[Ctrl][5]
evtEmoteTaunt=[Ctrl][2]
evtEmoteLaugh=[Ctrl][4]
evtEmoteJoke=[Ctrl][1]
evtEmoteDance=[Ctrl][3]
evtDrawHud=
evtDragScrollLock=
evtChatHistory=[z]
evtChampionOnly=[`]
evtChampMasteryDisplay=[Ctrl][6]
evtCastSpell4=[r]
evtCastSpell3=[e]
evtCastSpell2=[w]
evtCastSpell1=[q]
evtCastAvatarSpell2=[f]
evtCastAvatarSpell1=[d]
evtCameraSnap=[Space]
evtCameraLockToggle=[y]
evntPlayerPingDanger=[Ctrl][Button 1]
evntPlayerPingCursorDanger=[v]
evntPlayerPingCursor=[g]
evntPlayerPing=[Alt][Button 1]

[HUDEvents]
evtTogglePlayerStats=[Ctrl][c]
evtToggleMouseClip=[F9]
evtToggleFPSAndLatency=[Ctrl][f]
evtToggleDeathRecapShowcase=[n]
evtHoldShowScoreBoard=[Tab]

[Quickbinds]
evtUseVisionItemsmart=1
evtUseItem6smart=1
evtUseItem5smart=1
evtUseItem4smart=1
evtUseItem3smart=1
evtUseItem2smart=1
evtUseItem1smart=1
evtCastSpell4smart=1
evtCastSpell3smart=1
evtCastSpell2smart=1
evtCastSpell1smart=1
evtCastAvatarSpell2smart=1
evtCastAvatarSpell1smart=1

[ShopEvents]
evtShopSwitchTabs=[Ctrl][Tab]
evtShopFocusSearch=[Ctrl][l],[Ctrl][Return]
";
        #endregion
    }
}
