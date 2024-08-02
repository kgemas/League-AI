using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueAI.Libraries.Entities
{
    public sealed class LobbySession
    {
        [JsonProperty("actions")]
        public List<List<ActionGame>> actions { get; set; }

        [JsonProperty("allowBattleBoost")]
        public bool? allowBattleBoost { get; set; }

        [JsonProperty("allowDuplicatePicks")]
        public bool? allowDuplicatePicks { get; set; }

        [JsonProperty("allowLockedEvents")]
        public bool? allowLockedEvents { get; set; }

        [JsonProperty("allowRerolling")]
        public bool? allowRerolling { get; set; }

        [JsonProperty("allowSkinSelection")]
        public bool? allowSkinSelection { get; set; }

        [JsonProperty("bans")]
        public Bans bans { get; set; }

        [JsonProperty("benchChampionIds")]
        public List<object> benchChampionIds { get; set; }

        [JsonProperty("benchEnabled")]
        public bool? benchEnabled { get; set; }

        [JsonProperty("boostableSkinCount")]
        public double? boostableSkinCount { get; set; }

        [JsonProperty("chatDetails")]
        public ChatDetails chatDetails { get; set; }

        [JsonProperty("counter")]
        public double? counter { get; set; }

        [JsonProperty("entitledFeatureState")]
        public EntitledFeatureState entitledFeatureState { get; set; }

        [JsonProperty("gameId")]
        public double? gameId { get; set; }

        [JsonProperty("hasSimultaneousBans")]
        public bool? hasSimultaneousBans { get; set; }

        [JsonProperty("hasSimultaneousPicks")]
        public bool? hasSimultaneousPicks { get; set; }

        [JsonProperty("isCustomGame")]
        public bool? isCustomGame { get; set; }

        [JsonProperty("isSpectating")]
        public bool? isSpectating { get; set; }

        [JsonProperty("localPlayerCellId")]
        public double? localPlayerCellId { get; set; }

        [JsonProperty("lockedEventIndex")]
        public double? lockedEventIndex { get; set; }

        [JsonProperty("myTeam")]
        public List<TeamInGame> myTeam { get; set; }

        [JsonProperty("recoveryCounter")]
        public double? recoveryCounter { get; set; }

        [JsonProperty("rerollsRemaining")]
        public double? rerollsRemaining { get; set; }

        [JsonProperty("skipChampionSelect")]
        public bool? skipChampionSelect { get; set; }

        [JsonProperty("theirTeam")]
        public List<TeamInGame> theirTeam { get; set; }

        [JsonProperty("timer")]
        public Timer timer { get; set; }

        [JsonProperty("trades")]
        public List<object> trades { get; set; }
    }

    public sealed class Bans
    {
        [JsonProperty("myTeamBans")]
        public List<object> myTeamBans { get; set; }

        [JsonProperty("numBans")]
        public double? numBans { get; set; }

        [JsonProperty("theirTeamBans")]
        public List<object> theirTeamBans { get; set; }
    }

    public sealed class ChatDetails
    {
        [JsonProperty("chatRoomName")]
        public string chatRoomName { get; set; }

        [JsonProperty("chatRoomPassword")]
        public string chatRoomPassword { get; set; }
    }

    public sealed class EntitledFeatureState
    {
        [JsonProperty("additionalRerolls")]
        public double? additionalRerolls { get; set; }

        [JsonProperty("unlockedSkinIds")]
        public List<object> unlockedSkinIds { get; set; }
    }

    public sealed class TeamInGame
    {
        [JsonProperty("assignedPosition")]
        public string assignedPosition { get; set; }

        [JsonProperty("cellId")]
        public double? cellId { get; set; }

        [JsonProperty("championId")]
        public double? championId { get; set; }

        [JsonProperty("championPickdoubleent")]
        public double? championPickdoubleent { get; set; }

        [JsonProperty("entitledFeatureType")]
        public string entitledFeatureType { get; set; }

        [JsonProperty("selectedSkinId")]
        public double? selectedSkinId { get; set; }

        [JsonProperty("spell1Id")]
        public double? spell1Id { get; set; }

        [JsonProperty("spell2Id")]
        public double? spell2Id { get; set; }

        [JsonProperty("summonerId")]
        public double? summonerId { get; set; }

        [JsonProperty("team")]
        public double? team { get; set; }

        [JsonProperty("wardSkinId")]
        public double? wardSkinId { get; set; }
    }

    public sealed class Timer
    {
        [JsonProperty("adjustedTimeLeftInPhase")]
        public double? adjustedTimeLeftInPhase { get; set; }

        [JsonProperty("doubleernalNowInEpochMs")]
        public long? doubleernalNowInEpochMs { get; set; }

        [JsonProperty("isInfinite")]
        public bool? isInfinite { get; set; }

        [JsonProperty("phase")]
        public string phase { get; set; }

        [JsonProperty("totalTimeInPhase")]
        public double? totalTimeInPhase { get; set; }
    }
}
