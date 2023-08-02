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

What is this?
===
- This is a self-playing bot of league of legends.
- Released to test new technologies, it uses only publicly available apis and does not interfere with the game at all.
- The way this bot works is to emulate a keyboard and mouse like a player.
<details open>
  <summary>Expand / Shrink</summary>
  <p align="center">
    <img src="https://github.com/kgemas/League-AI/raw/main/Assets/example.gif">
  </p>
</details>

- Real-time statistics page: https://sso.khaivu.dev

https://github.com/kgemas/League-AI/assets/44091521/9f034e9f-9858-4606-bb4a-0c878b594012


Download
===
- Latest version, please download the file [LeagueAI.zip] (https://github.com/kgemas/League-AI/releases/latest).
- Once the download is done, you can compare it with the md5 hash to ensure that the file you download is safe.


Environmental requirements
===========
For the software to work, operating environment packages are required.
- Install .NET Framework 4.7.2 Runtime [Download Here](https://go.microsoft.com/fwlink/?LinkId=863262).


30 seconds install.
===
- **Step 0**: From the latest versions (v0.1.13), the bot will install itself based on the directory of LeagueClient.exe. In case it does not work, it needs to be installed manually.

- **Step 1**: Open the game app. The screen will have several menus like this.
<p align="center">
  <img src="https://github.com/kgemas/League-AI/raw/main/Assets/dashboard.PNG">
</p>

- **Step 2**: Run the program ```LeagueAI.exe``` and enter the Key (if any).
- Done 🎉 Keep the screen unlocked and go play 💃

Advanced File Customization ```config.json```
===
```
// server
"hostActive": "https://leaguebot.khaivu.dev"

// the number of games the bot will play on its own
"maxGame": 8,

// favorite champion
"defaultChampion": "Veigar",

// display language (if the command line on your computer can be displayed). List below.
"languageBot": "VI",

// 1 = automatic shutdown, 0 = no shutdown
"autoShutdown": 1,

// skill upgrade order
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
- Languages: AM, AR, EU, BN, GB, BR, BG, CA, CHR, HR, CS, DA, NL, EN, ET, FIL, FI, FR, DE, EL, GU, IW, HI , HU, IS, ID, IT, JA, KN, KO, LV, LT, MS, ML, MR, NO, PL, PT, RO, RU, SR, CN, SK, SL, ES, SW, SV, TA , TE, TH, TW, TR, UR, UK, VI, CY.

- Champions: Aatrox, Ahri, Akali, Akshan, Alistar, Amumu, Anivia, Annie, Aphelios, Ashe, AurelionSol, Azir, Bard, Belveth, Blitzcrank, Brand, Braum, Caitlyn, Camille, Cassiopeia, Chogath, Corki, Darius, Diana, Draven, DrMundo, Ekko, Elise, Evelynn, Ezreal, Fiddlesticks, Fiora, Fizz, Galio, Gangplank, Garen, Gnar, Gragas, Graves, Gwen, Hecarim, Heimerdinger, Illaoi, Irelia, Ivern, Janna, JarvanIV, Jax, Jayce, Jhin, Jinx, Kaisa, Kalista, Karma, Karthus, Kassadin, Katarina, Kayle, Kayn, Kennen, Khazix, Kindred, Kled, KogMaw, KSante, Leblanc, LeeSin, Leona, Lillia, Lissandra, Lucian, Lulu, Lux, Malphite, Malzahar, Maokai, MasterYi, Milio, MissFortune, MonkeyKing, Mordekaiser, Morgana, Nami, Nasus, Nautilus, Neeko, Nidalee, Nilah, Nocturne, Nunu, Olaf, Orianna, Ornn, Pantheon, Poppy, Pyke, Qiyana, Quinn, Rakan, Rammus, RekSai, Rell, Renata, Renekton, Rengar, Riven, Rumble, Ryze, Samira, Sejuani, Senna, Seraphine, Sett, Shaco, Shen, Shyvana, Singed, Sion, Sivir, Skarner, Sona, Soraka, Swain, Sylas, Syndra, TahmKench, Taliyah, Talon, Taric, Teemo, Thresh, Tristana, Trundle, Tryndamere, TwistedFate, Twitch, Udyr, Urgot, Varus, Vayne, Veigar, Velkoz, Vex, Vi, Viego, Viktor, Vladimir, Volibear, Warwick, Xayah, Xerath, XinZhao, Yasuo, Yone, Yorick, Yuumi, Zac, Zed, Zeri, Ziggs, Zilean, Zoe, Zyra.

Advanced customization for unsupported servers
===========
In some game distributions, you may encounter a case where the file path does not have a default value like in the settings file ```appsettings.json``` or the bot can't install itself. The workaround is to point each file to its correct address (the full path of the file). There are 6 files that need to be configured manually as shown below.

<p align="center">
  <img src="https://github.com/kgemas/League-AI/raw/main/Assets/adventureConfig.PNG">
</p>

Until the publisher fixes the bug, this configuration will remain active. Because the software needs to use these profiles to get permission to read the API.

Updates and patches
===========
- For stable operation, update to the new version when possible, the latest versions usually include bug fixes and new features.
- Starting from the following updates, the ```UpdateBotAI.exe``` tool will be attached to the file ```LeagueAI.zip``` at [release](https://github.com/kgemas/League-AI/releases/latest). Run the file ```UpdateBotAI.exe``` and it will replace the old versions by itself.

Support telegram group.
===
[LeagueAI - Github Kgemas (Vietnam)](https://t.me/+HBclRDdmP4pjYjNl)

Behavior rules:
1. For newbie: read the answer using the search function on github + telegram group before asking a question.
2. With members: be polite and help newcomers when possible.

I created a telegram group to help fix bugs faster, simply because I'm more active here.

The software itself is experimental software for new technologies.

I'm the only developer so it would be great if people help each other and I just need to take care of new unexplored issues.


Can't run the software?
===
- As one master said
<p align="center">
  <img src="https://user-images.githubusercontent.com/93424739/212647023-0b3e30a5-bfd2-4bb0-966a-8f32cbb2c587.png">
</p>

- You can track **resolved** issues [here](https://github.com/kgemas/League-AI/issues?q=is%3Aissue+is%3Aclosed).

- Or view issues **in progress** [here](https://github.com/kgemas/League-AI/issues?q=is%3Aopen+is%3Aissue).

- If you have some new unresolved errors, please [create a new issue](https://github.com/kgemas/League-AI/issues/new/choose), it may take 1-2 days for me to process, but please be patient 😂


Project support?
===
- If you find this project interesting, become one of the server maintainers using the QR on the left.
- If you want to thank the developer, on the right is his QR 🐳.

<p align="center">
  <img src="https://user-images.githubusercontent.com/93424739/212659961-08520136-8fd4-492c-9e2c-73a501fd6426.png" width="600">
</p>

Good luck 🐱‍👤🎶
