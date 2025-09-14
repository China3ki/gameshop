using GameShop.App.ViewsComponents;
using GameShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Views.NormalViews
{
    internal class StartView(ViewType viewType) : View(viewType), IViewProvider
    {
        private readonly ViewManager _menuManager = new();
        public void InitView()
        {
            InitOptionList();
            InitInfoList();
            _menuManager.InitViewManager();
            NextView();
        }
        protected override void InitInfoList()
        {
            _menuManager.AddElementOfInfo(_infoData[0], ConsoleColor.White, ConsoleColor.Black);
            _menuManager.AddElementOfInfo(_infoData[1], ConsoleColor.Yellow, ConsoleColor.Black);
        }
        protected override void InitOptionList()
        {
            _menuManager.AddElementOfMenu(_menuData[0], ConsoleColor.Cyan, ConsoleColor.Black);
            _menuManager.AddElementOfMenu(_menuData[1], ConsoleColor.White, ConsoleColor.Black);
            _menuManager.AddElementOfMenu(_menuData[2], ConsoleColor.White, ConsoleColor.Black);
            _menuManager.AddElementOfMenu(_menuData[3], ConsoleColor.White, ConsoleColor.Black);
            _menuManager.AddElementOfMenu(_menuData[4], ConsoleColor.Red, ConsoleColor.Black);
        }
        public ViewType NextView()
        {
            switch(_menuManager.InitViewManager())
            {
                case 1:
                    return ViewType.Login;
                case 2:
                    return ViewType.Register;
                case 3:
                    return ViewType.Language;
                case 4:
                    return ViewType.Exit;
                default:
                    throw new NotImplementedException(); // work;
            }
        }
    }
}
