using GameShop.App.Components;
using GameShop.App.ViewsComponents;

namespace GameShop.Views.SingleViews
{
    internal class SuccesfulRegistration(ViewType viewtype, string[] info) : InfoView(viewtype, info)
    {
        public override void InitView()
        {
            Console.Clear();
            base.InitView();
            AddInfo();
            WaitForEnter();
        }
        private void AddInfo()
        {
            List<string> info = LanguageManager.GetData(ViewType.SuccesfulRegistration, DataType.InfoList);
            InfoManager infoManager = new();
            infoManager.AddElement(info[0], ConsoleColor.Green, ConsoleColor.Black);
            infoManager.AddElement(info[1], ConsoleColor.White, ConsoleColor.Black);
            infoManager.AddElement(info[2], ConsoleColor.Yellow, ConsoleColor.Black);
            infoManager.InitInfo();
        }
        private void WaitForEnter()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Enter);
        }
    }
}
