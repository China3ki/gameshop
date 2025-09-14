using GameShop.App;
using GameShop.App.ViewsComponents;

namespace GameShop.Views.SingleViews
{
    internal class Error(ViewType viewType, string[] info, ErrorType errorType) : InfoView(viewType, info)
    {
        private ErrorType _errorType = errorType;
        public override void InitView()
        {
            base.InitView();
            CreatorInfo();
            WaitForEnter();
        }
        private void CreatorInfo()
        {
            InfoManager infoManager = new();
            List<string> errorList = LanguageManager.GetData(ViewType.Error, DataType.InfoList);
            switch(_errorType)
            {
                case ErrorType.WrongViewType:
                    infoManager.AddElement(errorList[0], ConsoleColor.Red, ConsoleColor.Black);
                    break;
                case ErrorType.FailedConnection:
                    infoManager.AddElement(errorList[1], ConsoleColor.Red, ConsoleColor.Black);
                    break;
                case ErrorType.FileNotFound:
                    infoManager.AddElement(errorList[2], ConsoleColor.Red, ConsoleColor.Black);
                    break;
            }
            infoManager.AddElement(errorList[3], ConsoleColor.Yellow, ConsoleColor.Black);
            infoManager.AddElement(errorList[4], ConsoleColor.White, ConsoleColor.Black);
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
