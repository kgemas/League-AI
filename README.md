<h1 align="center">
  <img src="https://user-images.githubusercontent.com/93424739/194055848-84830c09-dd8a-4017-b691-5198130bd3f0.jpg">
</h1>

<h1 align="center">
  <p>Bot auto play League of Legends<p>
  <img src="https://readme-typing-svg.herokuapp.com?color=%2336BCF7&center=true&vCenter=true&width=380&lines=Bot+AI+League+of+Legends">
</h1>


<p align="center">
  Display language:
  <a href="https://github.com/kgemas/League-AI/blob/main/README.md">[Vietnamese]</a>
  -
  <a href="https://github.com/kgemas/League-AI/blob/main/README.EN.md">[English]</a>
</p

Xin chào, tôi là Khải Vũ, nhà phát triển duy nhất của dự án này.
Sau Vanguard, dự án này đã ngừng hỗ trợ chính thức, phiên bản 0.1.15 là phiên bản cuối cùng. Tôi đã fork mã nguồn để bot có thể hoạt động trên máy tính cá nhân. Đã lâu rồi kể từ khi nó được phát hành với mục tiêu ban đầu là mọi người có thể sử dụng nó trên máy tính cá nhân của mình như một công cụ tiết kiệm thời gian vô nghĩa. Thời gian trôi qua thật nhanh, tôi không còn đủ thời gian để tiếp tục phát triển công cụ này nữa, nhưng hy vọng chúng ta sẽ gặp lại nhau trong một phần mềm kỳ lạ khác trên github này 🤗

Đây là gì?
===
- Đây là con bot tự chơi game liên minh huyền thoại.
- Được phát hành để thử nghiệm các công nghệ mới, nó chỉ sử dụng các api có sẵn được công khai và hoàn toàn không can thiệp vào game.
- Cách hoạt động của bot này là thao tác bàn phím và chuột giống như người chơi.
<details open>
  <summary>Mở rộng / Thu nhỏ</summary>
  <p align="center">
    <img src="https://github.com/kgemas/League-AI/raw/main/Assets/example.gif">
  </p>
</details>

- Bạn có thể xem trang Thống kê thời gian thực người sử dụng: https://sso.khaivu.dev

https://github.com/kgemas/League-AI/assets/44091521/9f034e9f-9858-4606-bb4a-0c878b594012

Tải về
===
- Phiên bản mới nhất, hãy tải về file [LeagueAI.zip](https://github.com/kgemas/League-AI/releases/latest) nhé.
- Sau khi tải xong, các bạn có thể so sánh với mã hash md5 để đảm bảo tệp tin mình tải về là an toàn.



Mô trường hoạt động
===========
Để phần mềm hoạt động được, cần có các gói môi trường hoạt động
- Cài đặt .NET Framework 4.7.2 Runtime [Tải về ở đây](https://go.microsoft.com/fwlink/?LinkId=863262).



30 giây cài đặt.
===
- **Bước 0**: Từ phiên bản mới nhất (v0.1.13), bot sẽ tự cài đặt dựa trên thư mục của LeagueClient.exe. Trong trường hợp mở lên không chạy thì cần cài đặt thủ công.

- **Bước 1**: Hãy mở game client lên. Màn hình sẽ có mấy menu như này.
<p align="center">
  <img src="https://github.com/kgemas/League-AI/raw/main/Assets/dashboard.PNG">
</p>

- **Bước 2**: Chạy chương trình ```LeagueAI.exe``` và nhập Key (nếu có).
- Done 🎉 Giữ màn hình không khoá lại và đi chơi thôi 💃



Tuỳ chỉnh nâng cao tệp ```config.json```
===========
```
// địa chỉ máy chủ cộng đồng
"hostActive": "https://leaguebot.khaivu.dev"

// số lượng game mà bot sẽ tự chơi
"maxGame": 8,

// tướng ưa thích tự động chơi
"defaultChampion": "Veigar",

// ngôn ngữ hiển thị (nếu như command line trên máy tính của bạn có thể hiển thị được). Danh sách bên dưới.
"languageBot": "VI",

// 1 = tự động tắt máy, 0 = không tắt máy
"autoShutdown": 1,

// thứ tự upgrade skill
"upgrandSkillMap": {
  "1": "Q",
  "2": "W",
  "3": "E",
  "4": "Q",
  "5": "W",
  "6": "R",
  "7": "Q",
  "8": "W",
}
```
- Danh sách ngôn ngữ: AM, AR, EU, BN, GB, BR, BG, CA, CHR, HR, CS, DA, NL, EN, ET, FIL, FI, FR, DE, EL, GU, IW, HI, HU, IS, ID, IT, JA, KN, KO, LV, LT, MS, ML, MR, NO, PL, PT, RO, RU, SR, CN, SK, SL, ES, SW, SV, TA, TE, TH, TW, TR, UR, UK, VI, CY.

- Danh sách tướng: Aatrox, Ahri, Akali, Akshan, Alistar, Amumu, Anivia, Annie, Aphelios, Ashe, AurelionSol, Azir, Bard, Belveth, Blitzcrank, Brand, Braum, Caitlyn, Camille, Cassiopeia, Chogath, Corki, Darius, Diana, Draven, DrMundo, Ekko, Elise, Evelynn, Ezreal, Fiddlesticks, Fiora, Fizz, Galio, Gangplank, Garen, Gnar, Gragas, Graves, Gwen, Hecarim, Heimerdinger, Illaoi, Irelia, Ivern, Janna, JarvanIV, Jax, Jayce, Jhin, Jinx, Kaisa, Kalista, Karma, Karthus, Kassadin, Katarina, Kayle, Kayn, Kennen, Khazix, Kindred, Kled, KogMaw, KSante, Leblanc, LeeSin, Leona, Lillia, Lissandra, Lucian, Lulu, Lux, Malphite, Malzahar, Maokai, MasterYi, Milio, MissFortune, MonkeyKing, Mordekaiser, Morgana, Nami, Nasus, Nautilus, Neeko, Nidalee, Nilah, Nocturne, Nunu, Olaf, Orianna, Ornn, Pantheon, Poppy, Pyke, Qiyana, Quinn, Rakan, Rammus, RekSai, Rell, Renata, Renekton, Rengar, Riven, Rumble, Ryze, Samira, Sejuani, Senna, Seraphine, Sett, Shaco, Shen, Shyvana, Singed, Sion, Sivir, Skarner, Sona, Soraka, Swain, Sylas, Syndra, TahmKench, Taliyah, Talon, Taric, Teemo, Thresh, Tristana, Trundle, Tryndamere, TwistedFate, Twitch, Udyr, Urgot, Varus, Vayne, Veigar, Velkoz, Vex, Vi, Viego, Viktor, Vladimir, Volibear, Warwick, Xayah, Xerath, XinZhao, Yasuo, Yone, Yorick, Yuumi, Zac, Zed, Zeri, Ziggs, Zilean, Zoe, Zyra.

Tuỳ chỉnh nâng cao cho những máy chủ chưa được hỗ trợ
===========
Trong một vài bản phân phối game, có thể bạn sẽ gặp phải trường hợp mà đường dẫn các tệp tin không có giá trị mặc định như trong tệp cài đặt ```appsettings.json``` hoặc bot không tự cài đặt được.

Cách giải quyết là hãy trỏ từng tệp tin đến đúng địa chỉ của nó (bao gồm đường dẫn đầy đủ). Có 6 tệp tin cần phải cấu hình tay như hình dưới.

<p align="center">
  <img src="https://github.com/kgemas/League-AI/raw/main/Assets/adventureConfig.PNG">
</p>

Bạn hãy tìm đến đúng file có trong thư mục game. Mục đích cấu hình những file này để phần mềm có quyền đọc API.



Cập nhật quan trọng mọi phiên bản.
===========
- Để quá trình hoạt động ổn định, hãy cập nhật phiên bản mới khi có thể, các phiên bản mới nhất thường bao gồm các bản sửa lỗi và tính năng mới.
- Bắt đầu từ các bản cập nhật sau, tool ```UpdateBotAI.exe``` sẽ được đính kèm vào tệp tin ```LeagueAI.zip``` tại các [bản phát hành](https://github.com/kgemas/League-AI/releases/latest). Chạy file ```UpdateBotAI.exe``` và nó sẽ tự thay thế các bản cũ.



Nhóm telegram hỗ trợ.
===
[LeagueAI - Github Kgemas (VN)](https://t.me/+HBclRDdmP4pjYjNl)

Quy tắc ứng xử:
1. Với người mới: hãy đọc các câu trả lời bằng chức năng tìm kiếm ở github + nhóm telegram trước khi đặt câu hỏi.
2. Với các thành viên: hãy lịch sự và giúp đỡ người mới khi có thể.

Mình tạo ra nhóm telegram để hỗ trợ sửa lỗi nhanh hơn, đơn giản vì mình hoạt động ở đây nhiều hơn. 

Bản thân phần mềm này là phần mềm thử nghiệm các công nghệ mới.

Mình là người phát triển duy nhất nên sẽ rất tuyệt nếu mọi người giúp đỡ nhau và mình chỉ cần quan tâm đến những vấn đề mới chưa được phát hiện.



Không thể chạy phần mềm?
===
Như một cao nhân đã nói khi không thể chạy được:
<p align="center">
  <img src="https://user-images.githubusercontent.com/93424739/212647023-0b3e30a5-bfd2-4bb0-966a-8f32cbb2c587.png">
</p>

Các bạn có thể theo dõi những vấn đề **đã được giải quyết** [tại đây](https://github.com/kgemas/League-AI/issues?q=is%3Aissue+is%3Aclosed).

Hoặc xem những vấn đề **đang xử lý** [tại đây](https://github.com/kgemas/League-AI/issues?q=is%3Aopen+is%3Aissue).

Nếu bạn gặp lỗi nào đó mới chưa từng được giải quyết, hãy [tạo một vấn đề mới](https://github.com/kgemas/League-AI/issues/new/choose), có thể sẽ mất 1-2 ngày để tôi giải quyết, nhưng hãy kiên nhẫn nhé 😂

Giúp đỡ dự án?
===
- Nếu bạn thấy dự án này thú vị, hãy trở thành một trong những người duy trì máy chủ bằng QR bên trái nhé.
- Nếu bạn muốn cảm ơn nhà phát triển, thì bên phải là chiếc QR của hắn 🐳.
<p align="center">
  <img src="https://user-images.githubusercontent.com/93424739/212659961-08520136-8fd4-492c-9e2c-73a501fd6426.png" width="600">
</p>


Good luck 🐱‍👤🎶
