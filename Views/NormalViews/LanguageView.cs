using GameShop.App.Components;
using GameShop.App.ViewsComponents;
using GameShop.Interfaces;
using System.Diagnostics;

namespace GameShop.Views.NormalViews
{
    internal class LanguageView(ViewType viewType) : View(viewType), IViewProvider
    {
        private readonly ViewManager _viewManager = new();
        public void InitView()
        {
            InitOptionList();
            InitInfoList();
        }
        public ViewType NextView()
        {
            switch (_viewManager.InitViewManager())
            {
                case 1:
                    LanguageManager.Language = Language.Polski;
                    return ViewType.Language;
                case 2:
                    LanguageManager.Language = Language.English;
                    return ViewType.Language;
                case 3:
                    return ViewType.Start;
                default:
                    throw new NotImplementedException();
            }
        }
        protected override void InitOptionList()
        {
            _viewManager.AddElementOfMenu(_menuData[0], ConsoleColor.Cyan, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[1], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[2], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[3], ConsoleColor.Red, ConsoleColor.Black);
        }
        protected override void InitInfoList()
        {
            _viewManager.AddElementOfInfo(_infoData[0], ConsoleColor.Yellow, ConsoleColor.Black);
        }
    }
}
