<p align="center">
  <img src="https://readme-typing-svg.herokuapp.com?color=%2336BCF7&center=true&vCenter=true&width=380&lines=Bot+AI+League+of+Legends">
</p>
<p align="center">
  Bot auto play League of Legends
  <img src="./Assets/LOLBot.png">
</p>

## Mô trường hoạt động
- .NET Framework 4.7.2 Runtime.

## Cài đặt để khởi chạy.
- Đầu tiên hãy mở game lên nè.
- Mở folder đã cài đặt, tìm đến file cài đặt "config.json".
- Tiếp theo, hãy sửa đổi đường dẫn đến folder game của bạn.
```
// Chỉnh sửa thư mục game tương ứng ở đây, thư mục "32787"
"DefaultLeaguePath": "E:\\GamePC\\Garena\\Games\\32787"
```

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

- Sau khi cài đặt xong, khởi chạy chương trình "LeagueAI.exe".
- Chương trình có các kịch bản chạy game mẫu (Begin, InGame, End), gõ tương ứng từng kịch bản.
- Ví dụ "Begin" sẽ bắt đầu tự chơi. "InGame" dành cho người chơi đang trong trận, sau đó BOT sẽ làm nốt việc của bạn 😴
- Giữ máy không khoá màn hình.

P/s: 
- Những kịch bản này có thể được sửa đổi tại folder "Patterns".
- Hãy cẩn thận trong khi chỉnh sửa, bạn có thể khám phá các tuỳ chọn khác tại folder cài đặt.

Good luck 🐱‍👤
