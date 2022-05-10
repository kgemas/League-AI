<p align="center">
  <img src="https://readme-typing-svg.herokuapp.com?color=%2336BCF7&center=true&vCenter=true&width=380&lines=Bot+AI+League+of+Legends">
</p>
<p align="center">
  Bot auto play League of Legends
  <img src="./Assets/LOLBot.png">
</p>

30s Cài đặt.
=============================================================================================
- Đầu tiên hãy mở game lên nè.
- Mở folder đã cài đặt, tìm đến file cấu hình ```config.json```.
- Tiếp theo, hãy sửa đổi đường dẫn đến folder game của bạn và lưu lại.
```
// Chỉnh sửa thư mục game tương ứng ở đây, thư mục "32787" (máy chủ garena).
"DefaultLeaguePath": "E:\\GamePC\\Garena\\Games\\32787"
```

- Sau khi cấu hình xong, khởi chạy chương trình "LeagueAI.exe" và nhập Key (nếu có).
- Để màn hình mở và đi ăn chơi nhảy nhót 💃

- Nếu bạn sử dụng cấu hình garena, thì bỏ qua phần cấu hình ```config.json``` máy chủ NA này.
```
- Với máy chỉ NA, chỉ cần xoá hết cấu hình của garena đi (hoặc comment lại, mặc định thì folder game máy chủ này mặc định ở trong C:/Riot Games).
- Sau đó bỏ các dấu /* và */ đi (bỏ comment cấu hình của máy chủ NA).
- Hãy chú ý tệp json phải đúng định dạng, bạn có thể sẽ phải tìm kiếm google theo từ khoá "validate json online" để kiểm tra.
```

Mô trường hoạt động
=============================================================================================
- .NET Framework 4.7.2 Runtime [Tải về ở đây](https://go.microsoft.com/fwlink/?LinkId=863262).

Tuỳ chỉnh nâng cao
=============================================================================================
- Hãy cẩn thận trong khi chỉnh sửa, bạn có thể khám phá các tuỳ chọn khác tại tệp config.json trong thư mục cài đặt.
- Một vài tuỳ chọn khác có thể sử dụng:
```
// số lượng game mà bot sẽ tự chơi
"maxGame": 8,

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
Cập nhật quan trọng mọi phiên bản.
===
Để có thể cập nhật nhanh chóng bot này, các bạn hãy tải về "Bot cập nhật LeagueAI" [tại đây](https://github.com/kgemas/Tool-Update-LeagueAI/releases/download/v1.0.0/UpdateBotAI.zip).

Tóm tắt: Tải về và giải nén cùng trong folder của bot. Sau đó chạy "UpdateBotAI.exe", nó sẽ tự thay thế các bản cũ.

Chi tiết về cách cài đặt và sử dụng công cụ update này, xem thêm [tại đây](https://github.com/kgemas/Tool-Update-LeagueAI)

Không thể chạy phần mềm?
===
Như một cao nhân đã nói
> Hãy thử cập nhật phần mềm nếu gặp lỗi 💥 vì rất có thể vấn đề đó đã được giải quyết rồi đó!

Các bạn có thể theo dõi những vấn đề **đã được giải quyết** [tại đây](https://github.com/kgemas/League-AI/issues?q=is%3Aissue+is%3Aclosed).

Hoặc xem những vấn đề **đang xử lý** [tại đây](https://github.com/kgemas/League-AI/issues?q=is%3Aopen+is%3Aissue).


Good luck 🐱‍👤🎶
