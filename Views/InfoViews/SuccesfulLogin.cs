using GameShop.App.Components;
using GameShop.App.ViewsComponents;
using GameShop.Views.SingleViews;

namespace GameShop.Views.InfoViews
{
    internal class SuccesfulLogin(ViewType nextView, string[] info) : InfoView(nextView, info)
    {
        public override void InitView()
        {
            base.InitView();
            AddInfo();
            Thread.Sleep(1000);
        }
        private void AddInfo()
        {
            List<string> infolist = LanguageManager.GetData(ViewType.Login, DataType.InfoList);
            InfoManager info = new();
            info.AddElement($"{infolist[0]} {UserManager.UserNickname}!", ConsoleColor.Blue, ConsoleColor.Black);
            info.InitInfo();
        }      
    }
}
