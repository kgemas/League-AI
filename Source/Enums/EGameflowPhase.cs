namespace LeagueAI.Libraries.Enums
{
    public enum EGameflowPhase
    {
        /// Đang ở ngoài sảnh chờ, không chọn gì cả
        None,

        /// Đang ở trong phòng
        Lobby,

        /// Đang tìm trận
        Matchmaking,

        /// Hiện hộp thoại chấp thuận
        ReadyCheck,

        /// Đang chọn tướng
        ChampSelect,

        /// 
        GameStart,

        /// Không thể khởi chạy game
        FailedToLaunch,

        /// Đang tải game / chơi
        InProgress,

        /// Chờ kết nối lại
        Reconnect,

        /// Chờ bảng điểm
        WaitingForStats,

        /// 
        EndOfGame,

        /// 
        PreEndOfGame,

        /// Lỗi
        TerminatedInError
    }
}
