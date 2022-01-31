<p align="center">
  <img src="https://readme-typing-svg.herokuapp.com?color=%2336BCF7&center=true&vCenter=true&width=380&lines=Bot+AI+League+of+Legends">
</p>
<p align="center">
  Bot auto play League of Legends
  <img src="./Assets/LOLBot.png">
</p>

## Yêu cầu
- .NET Framework 4.7.2.

## Cài đặt.
- Mở game client.
- Mở folder đã giải nén, tìm đến file "config.json". Tiếp theo, sửa đổi
```
// Chỉnh sửa folder game tương ứng ở đây, "32787" folder
"DefaultLeaguePath": "E:\\GamePC\\Garena\\Games\\32787"
```

- Tuỳ chọn khác có thể sử dụng
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
    "9": "Q",
    "10": "W",
    "11": "R",
    "12": "Q",
    "13": "W",
    "14": "E",
    "15": "E",
    "16": "R",
    "17": "E",
    "18": "E"
  }
```

- Sau khi cài đặt xong, khởi chạy chương trình "LeagueAI.exe".
- Chương trình yêu cầu dán url active license -> điền theo hướng dẫn của người phát hành.
- Sau khi active, chương trình sẽ khởi chạy với các thông báo thành công (nếu xảy ra lỗi, hãy chụp hình và gửi tới người phát hành).
- Chương trình có các kịch bản chạy game mẫu (Begin, InGame, End). Gõ tương ứng từng kịch bản, ví dụ "Begin" sẽ bắt đầu tự chơi. "InGame" dành cho người chơi đang trong trận.
- Những kịch bản này có thể được sửa đổi tại folder "Patterns" (Hãy cẩn thận trong khi chỉnh sửa với người không chuyên).
- Giữ máy không khoá màn hình.
