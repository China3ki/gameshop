using GameShop.App.ViewsComponents;
using GameShop.Interfaces;

namespace GameShop.Views.SingleView
{
    internal class InfoView(ViewType nextView, string[] info) : IViewProvider
    {
        private readonly ViewType _nextView = nextView;
        private readonly string[] _info = info;
        static protected FrameManager _frameManager = new();
        public virtual void InitView()
        {
            _frameManager.FrameInit();
            RenderInfo();
        }
        public ViewType NextView()
        {
            return _nextView;
        }
        /// <summary>
        /// Renders informational text to the console.
        /// </summary>
        protected void RenderInfo()
        {                                         
            for (int i = 0; i < _info.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - _info[i].Length) / 2, (Console.WindowHeight - _info.Length) / 2 + i);
                Console.Write(_info[i]);
            }
        }
    }
}
