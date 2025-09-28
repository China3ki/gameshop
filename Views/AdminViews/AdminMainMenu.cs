using GameShop.App.Components;
using GameShop.App.ViewsComponents;
using GameShop.Interfaces;
using GameShop.Views.NormalViews;

namespace GameShop.Views.AdminViews
{
    internal class AdminMainMenu(ViewType viewType) : View(viewType), IViewProvider
    {
        ViewManager _viewManager = new();
        public void InitView()
        {
            InitInfoList();
            InitOptionList();
        }
        public ViewType NextView()
        {
            switch (_viewManager.InitViewManager())
            {
                case 1:
                    return ViewType.Intro;
                case 2:
                    return ViewType.Intro;
                case 3:
                    return ViewType.Intro;
                case 4:
                    UserManager.Logout();
                    return ViewType.Start;
                case 5:
                    UserManager.Logout();
                    return ViewType.Outro;
                default:
                    return ViewType.Intro;
            }
        }
        protected override void InitOptionList()
        {
            _viewManager.AddElementOfMenu(_menuData[0], ConsoleColor.Cyan, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[1], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[2], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[3], ConsoleColor.White, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[4], ConsoleColor.Yellow, ConsoleColor.Black);
            _viewManager.AddElementOfMenu(_menuData[5], ConsoleColor.Red, ConsoleColor.Black);
        }
        protected override void InitInfoList()
        {
            _viewManager.AddElementOfInfo($"{_infoData[0]} {UserManager.UserNickname}!", ConsoleColor.Blue, ConsoleColor.Black);
        }
    }
}
