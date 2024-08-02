using LeagueAI.Libraries.Helper;
using System.Threading;

namespace LeagueAI.Libraries.Api
{
    public sealed class ShopApi : BaseApiMember<GameApi>
    {
        public bool Opened { get; set; }
        public ShopApi(GameApi api) : base(api)
        {
            Opened = false;
        }

        public void Toogle(
            int delay)
        {
            // Tắt mở cửa hàng
            Thread.Sleep(200);
            if (Opened)
            {
                InputHelper.PressKey("Escape", delay);
            }
            else
            {
                InputHelper.PressKey("P", delay);
            }

            Opened = !Opened;
        }

        public void SearchItem(
            string keyword,
            int keyDelay,
            int delay)
        {
            // Mở hộp tìm kiếm và tìm kiếm chữ
            Thread.Sleep(200);
            InputHelper.KeyDown("LControlKey", 20);
            InputHelper.KeyDown("L", 20);
            InputHelper.KeyUp("LControlKey", 20);
            InputHelper.KeyUp("L", 20);
            Thread.Sleep(delay);

            InputHelper.InputWords(keyword, keyDelay, delay);
            //Logger.WriteLine("Buyed " + keyword);
        }

        public void BuySearchedItem(int delay)
        {
            // Enter 2 lần để mua (sau khi gõ xong)
            Thread.Sleep(200);
            InputHelper.PressKey("Enter", delay);
            InputHelper.PressKey("Enter", delay);
        }
    }
}
