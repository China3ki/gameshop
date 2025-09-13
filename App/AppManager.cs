using GameShop.Interfaces;
using GameShop.Views.SingleViews;

namespace GameShop.App
{
    internal class AppManager
    {
        private bool _run = false;
        private ViewType _currentView = ViewType.Intro;
        public AppManager()
        {
            _run = true;
            RunApp();
        }
        public void RunApp()
        {
            do
            {
                ContentManagement();
            } while (_run);
        }
        private void ContentManagement()
        {
            IViewProvider view;
            switch( _currentView)
            {
                case ViewType.Intro:
                    view = new Intro(ViewType.Start, ["   ____                      ____  _                 ", "  / ___| __ _ _ __ ___   ___/ ___|| |__   ___  _ __  ", " | |  _ / _` | '_ ` _ \\ / _ \\___ \\| '_ \\ / _ \\| '_ \\ ", " | |_| | (_| | | | | | |  __/___) | | | | (_) | |_) |", "  \\____|\\__,_|_| |_| |_|\\___|____/|_| |_|\\___/| .__/ ", "                                              |_|    "]);
                    view.InitView();
                    break;
                default:
                    throw new NotImplementedException();
            }
            _currentView = view.NextView();
        }
    }
}
