using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeagueAI.Libraries
{
    public sealed partial class DEFINE
    {
        public static Encoding HttpRequestEncoding = Encoding.UTF8;
        public const string ConfigPath = "config.json";
        public const int KeyboardLanguage = 1033;
        public const string LogPath = "log.txt";
        public const string DatetimeFormat = "dd-MM-yyyy";

        #region Game file
        public static string ClientExecutableName { get; set; } = "League of Legends";
        public static string GameExecutableName { get; set; } = "League of Legends (TM) Client";
        public static string LeagueClientUxRender { get; set; } = "LeagueClientUxRender.exe";
        public static string LeagueGameconfigPath { get; set; } = "game.cfg";
        public static string LockfilePath { get; set; } = "lockfile";
        public static string LeaguePersistedSettingsPath { get; set; } = "PersistedSettings.json";

        #endregion

        public static string ArgumentClient { get; set; } = "--output-base-dir=";

        #region message log
        public static string InitSettingLog { get; set; } = "** Bắt đầu cài đặt **";
        public static string FinishSettingLog { get; set; } = "Khởi tạo thành công";
        public static string SettingKeyboardLog { get; set; } = "Cài đặt phím tắt trong game thành công.";
        public static string SettingScreenLog { get; set; } = "Cài đặt màn hình thành công.";
        public static string InputLicenseLog { get; set; } = "Nhập mã kích hoạt (bấm enter nếu đang có sự kiện miễn phí): ";
        public static string WrongLicense2Log { get; set; } = "Khoá sai định dạng hoặc hết thời gian sử dụng.";
        public static string ServerErrorLog { get; set; } = "Đã có lỗi khi chuyển đổi định dạng ngày tháng. Lỗi hệ thống!";
        public static string SettingError { get; set; } = "Cấu hình đường dẫn sai. Không thể lấy thông tin kết nối Client API.";
        public static string TrustCerLog { get; set; } = "Không thể tải chứng chỉ tin cậy. Ấn phím bất kỳ để thoát.";
        public static string UnknowServerLog { get; set; } = "Không có server nào đang hoạt động, xin hãy kiểm tra lại cấu hình.";
        public static string UnknowServer2Log { get; set; } = "Không có server nào đang hoạt động, vui lòng nhập địa chỉ server: ";
        public static string UnknowEventLog { get; set; } = "Không có sự kiện miễn phí nào đang khả dụng.";
        public static string RequestEventLog { get; set; } = "Đã gửi yêu cầu kích hoạt. Nếu được chấp thuận, bạn có thể sử dụng như bình thường.";
        public static string ErrorLog { get; set; } = "Lỗi không xác định (T.T). Nếu bạn liên tục gặp vấn đề này, xin hãy báo cáo một vấn đề mới.";
        public static string WaitGameLog { get; set; } = "Chờ đợi {0}s để mở game ...";
        public static string EndGameLog { get; set; } = "Hoàn thành game: {0}.";
        public static string EndMission { get; set; } = "Tự động đóng - hoàn thành tiến trình game.";
        public static string ErrorCenterScreenLog { get; set; } = "Không thể căn chỉnh cửa sổ trò chơi.";
        public static string ErrorBringToFrontLog { get; set; } = "Không thể gán cửa sổ trò chơi lên đầu.";
        public static string FollowLog { get; set; } = "Đi theo: {0}.";
        public static string CantLoadConfigLog { get; set; } = "Tệp tin cấu hình {0} không thể tải.";
        public static string CantLoadGameAPILog { get; set; } = "Không thể đọc API client";
        public static string NotOpenGameClientYetLog { get; set; } = "Chưa mở game League Client.";
        public static string CantFindGameLog { get; set; } = "Không thể tìm trận: {0}.";
        public static string CantStartGame { get; set; } = "Không thể mở game do hết thời gian chờ.";
        public static string ExecuteUpdate { get; set; } = "Đang cập nhật...";
        public static string PatternErrorLog { get; set; } = "Không tìm thấy kịch bản {0}.";
        public static string Reconnected { get; set; } = "Kết nối lại.";
        public static string WriteAccessAPI { get; set; } = "Client API: {0}, {1}";
        public static string LogCantGetUsername { get; set; } = "Không thể gọi đến api để lấy được tên người chơi.";
        public static string BeginGameLog { get; set; } = "Bắt đầu kịch bản chơi ...";
        public static string BeginCantLoadUserInfoLog { get; set; } = "Không thể tải thông tin người chơi. Thử lại sau 10s.";
        public static string BeginMaximumLevelLog { get; set; } = "Đã đạt tới giới hạn level (maxLevel).";
        public static string BeginUserInfoLog { get; set; } = "Xác định người chơi {0}.";
        public static string BeginLogError1 { get; set; } = "Đã có lỗi trong quá trình khởi chạy game ...";
        public static string BeginLogError2 { get; set; } = "Không thể tìm trận. Tạo phòng lại ...";
        public static string BeginLogError3 { get; set; } = "Không thể tìm trận. Người chơi chưa sẵn sàng hoặc phòng không tồn tại. Thử lại sau 10s.";
        public static string BeginLogError4 { get; set; } = "Lỗi không xác định trong quá trình tìm kiếm trận. Thử lại sau 10s.";
        public static string BeginLogError5 { get; set; } = "Không thể tiếp tục, không có tướng để chọn.";
        public static string BeginLogError6 { get; set; } = "Không thể chọn tướng chưa sở hữu.";
        public static string BeginLogError7 { get; set; } = "Không thể chọn tướng. Đã có người chọn tướng của bạn.";
        public static string BeginLog1 { get; set; } = "Đang tìm trận...";
        public static string BeginLog2 { get; set; } = "Không thể tìm trận. Đang trong hàng đợi. Thử lại sau 30s.";
        public static string BeginLog3 { get; set; } = "Đã tìm thấy trận.";
        public static string BeginLog4 { get; set; } = "Chọn tướng [{0}] thành công.";
        public static string BeginLog5 { get; set; } = "Đợi người chơi khác sẵn sàng....";
        public static string BeginLog6 { get; set; } = "Phòng bị huỷ, tìm kiếm trận đấu khác ...";
        public static string InGameLog { get; set; } = "Bắt đầu tiến trình trong game ...";
        public static string InGameLog2 { get; set; } = "Không thể lấy trạng thái của game...";
        public static string InGameLog4 { get; set; } = "Bạn đang ở đội [xanh]!";
        public static string InGameLog5 { get; set; } = "Bạn đang ở đội [đỏ]!";
        public static string InGameTalkFirst { get; set; } = "LeagueAI - Github Kgemas.";
        public static string EndGameLog2 { get; set; } = "Bắt đầu tiến trình kết thúc game.";
        public static string Logo2 { get; set; } = @"
- Hướng dẫn cài đặt: https://github.com/kgemas/League-AI
- Nhóm hỗ trợ sửa lỗi: https://t.me/+HBclRDdmP4pjYjNl
- Xem các vấn đề đã được xử lý: https://github.com/kgemas/League-AI/issues?q=is%3Aissue+is%3Aclosed
> Chúc may mắn :3";
        public static string Logo1 { get; set; } = @"

 _._     _,-'""`-._
(,-.`._,'(       |\`-/|
    `-.-' \ )-`( , o o)
          `-    \`_`""'-

> League AI - Kgemas";

        #endregion

        public static int[] ColorEnemyFocus { get; set; } = new int[] { 216, 41, 41 };
        public static int[] ColorEnemyLevelBox { get; set; } = new int[] { 51, 3, 0 };
        public static int[] ColorAllyLevelBox { get; set; } = new int[] { 0, 28, 44 };
        public static int[] ColorAllyCreep { get; set; } = new int[] { 73, 142, 197 };
        public static int[] ColorEnemyCreep { get; set; } = new int[] { 208, 94, 94 };
        public static int[] ColorAllyCreepMiniMap { get; set; } = new int[] { 76, 152, 216 };
        public static int[] ColorEnemyMiniMap { get; set; } = new int[] { 217, 57, 47 };
        public static int[] ColorSafePlan { get; set; } = new int[] { 47, 126, 155 };
        public static int[] ColorRiver { get; set; } = new int[] { 7, 57, 71 };
        public static int[] ColorWarningAfk { get; set; } = new int[] { 60, 45, 24 };
        public static int[] ColorCloseShop { get; set; } = new int[] { 165, 162, 148 };
        public static int[] ColorBlackJungle { get; set; } = new int[] { 52, 55, 40 };
        public static int[] ColorBoxChatBanPick { get; set; } = new int[] { 62, 53, 1 };
        public static int[] TargetClick { get; set; } = new int[] { 800, 500 };
        public static string DefaultChampion { get; set; } = "Veigar";
        public static string DefaultRoom { get; set; } = "CoopVsAIIntroBot";
        public static string AutoAcquireTarget { get; set; } = "1";
        public static string WindowMode { get; set; } = "2";

        public static List<ItemDto> DefaultItem { get; set; } = new List<ItemDto>()
        {
            new ItemDto("Doran Ring",400),
            new ItemDto("Sorcere",1100),
            new ItemDto("Lost Chapter",1300),
            new ItemDto("Luden Tempest",2100),
            new ItemDto("Needlessly Large Rod",1250),
            new ItemDto("Needlessly Large Rod",1250),
            new ItemDto("Rabadon Deathcap",1100),
        };

        #region Champion list
        public static EChampion[] Champions { get; set; } = Enum.GetValues(typeof(EChampion)).Cast<EChampion>().ToArray();
        #endregion

    }
}
