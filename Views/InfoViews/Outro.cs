using GameShop.App.Components;
namespace GameShop.Views.SingleViews
{
    internal class Outro(ViewType viewType, string[] info) : InfoView(viewType, info)
    {
        public override void InitView()
        {
            base.InitView();
            CreatorInfo();
            Thread.Sleep(2000);
        }
        private void CreatorInfo()
        {
            List<string> info = LanguageManager.GetData(ViewType.Outro, DataType.InfoList);
            for(int i = 0; i < info.Count; i++)
            {
                if (i == 0) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition((Console.WindowWidth - info[i].Length) / 2, Console.WindowHeight - 4 + i);
                Console.Write(info[i]);
                Console.ResetColor();
            }
        }
    }
}
