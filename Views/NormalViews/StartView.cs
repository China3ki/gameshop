using GameShop.App.ViewsComponents;
using GameShop.Interfaces;

namespace GameShop.Views.NormalViews
{
    internal class StartView(ViewType viewType) : View(viewType), IViewProvider
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
                    return ViewType.Login;
                case 2:
                    return ViewType.Register;
                case 3:
                    return ViewType.Language;
                case 4:
                    return ViewType.Outro;
                default:
                    return ViewType.Error;
            }
        }
        protected override void InitInfoList()
        {
            _viewManager.AddElementOfInfo(_infoData[0], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfInfo(_infoData[1], ConsoleColor.Yellow, ConsoleColor.Black);
        }
        protected override void InitOptionList()
        {
            _viewManager.AddElementOfMenu(_menuData[0], ConsoleColor.Cyan, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[1], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[2], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[3], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[4], ConsoleColor.Red, ConsoleColor.Black);
        }
    }
}
