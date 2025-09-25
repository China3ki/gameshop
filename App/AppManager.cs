using GameShop.Interfaces;
using GameShop.Views.FormViews;
using GameShop.Views.NormalViews;
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
        /// <summary>
        /// Starts and runs the application loop, managing content until the application is stopped.
        /// </summary>
        /// <remarks>The method repeatedly invokes the content management process while the application is
        /// running.  The loop continues until the internal state indicates that the application should stop.</remarks>
        public void RunApp()
        {
            do
            {
                ContentManagement();
            } while (_run);
        }
        /// <summary>
        /// Manages the transition between different application views based on the current view state.
        /// </summary>
        /// <remarks>This method initializes and displays the appropriate view for the current application
        /// state,  as determined by the <see cref="_currentView"/> field. It handles transitions between views such as 
        /// Intro, Start, Language, and Outro. If the current view is not recognized, a <see
        /// cref="NotImplementedException"/>  is thrown.</remarks>
        /// <exception cref="NotImplementedException">Thrown if the current view type specified in <see cref="_currentView"/> is not implemented.</exception>
        private void ContentManagement()
        {
            IViewProvider view;
            switch( _currentView)
            {
                case ViewType.Intro:
                    view = new Intro(ViewType.Start, ["   ____                      ____  _                 ", "  / ___| __ _ _ __ ___   ___/ ___|| |__   ___  _ __  ", " | |  _ / _` | '_ ` _ \\ / _ \\___ \\| '_ \\ / _ \\| '_ \\ ", " | |_| | (_| | | | | | |  __/___) | | | | (_) | |_) |", "  \\____|\\__,_|_| |_| |_|\\___|____/|_| |_|\\___/| .__/ ", "                                              |_|    "]);
                    view.InitView();
                    break;
                case ViewType.Start:
                    view = new StartView(ViewType.Start);
                    view.InitView();
                    break;
                case ViewType.Language:
                    view = new LanguageView(ViewType.Language);
                    view.InitView();
                    break;
                case ViewType.Register:
                    view = new RegisterView(ViewType.Register);
                    view.InitView();
                    break;
                case ViewType.Outro:
                    view = new Outro(ViewType.Outro, ["   ____                      ____  _                 ", "  / ___| __ _ _ __ ___   ___/ ___|| |__   ___  _ __  ", " | |  _ / _` | '_ ` _ \\ / _ \\___ \\| '_ \\ / _ \\| '_ \\ ", " | |_| | (_| | | | | | |  __/___) | | | | (_) | |_) |", "  \\____|\\__,_|_| |_| |_|\\___|____/|_| |_|\\___/| .__/ ", "                                              |_|    "]);
                    view.InitView();
                    _run = false;
                    break;
                case ViewType.SuccesfulRegistration:
                    view = new SuccesfulRegistration(ViewType.Start, [" __        __   _                          ", " \\ \\      / /__| | ___ ___  _ __ ___   ___ ", "  \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\", "   \\ V  V /  __/ | (_| (_) | | | | | |  __/", "    \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|", "                                           "]);
                    view.InitView();
                    break;
                default:
                    view = new Error(ViewType.Error, ["  _____                     ", " | ____|_ __ _ __ ___  _ __ ", " |  _| | '__| '__/ _ \\| '__|", " | |___| |  | | | (_) | |   ", " |_____|_|  |_|  \\___/|_|   ", "                            "], ErrorType.WrongViewType);
                    view.InitView();
                    Environment.Exit(0);
                    break;
            }
            _currentView = view.NextView();
        }
    }
}
