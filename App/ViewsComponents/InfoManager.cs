namespace GameShop.App.ViewsComponents
{
    internal class InfoManager
    {
        private List<string> _info = [];
        private List<ConsoleColor> _fontColors = [];
        private List<ConsoleColor> _backgroundColors = [];
        public void InitInfo()
        {
            RenderInfoBorder();
            RenderInfo();
        }
        public void AddElement(string element, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            _info.Add(element);
            _fontColors.Add(fontColor);
            _backgroundColors.Add(backgroundColor);
        } 
        public void ClearInfo()
        {
            for(int y = 0; y < _info.Count + 2; y++)
            {
                for(int x = 0; x < Console.WindowWidth; x++)
                {
                    Console.SetCursorPosition(x, Console.WindowHeight - y - 2);
                    if (x == 0 || x == Console.WindowWidth - 1) Console.Write('║');
                    else Console.Write(' ');
                }
            }
            _info.Clear();
        }
        private void RenderInfoBorder()
        {
            for(int x = 0; x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, Console.WindowHeight - 2 - _info.Count);
                if (x == 0) Console.Write('╠');
                if (x == Console.WindowWidth - 1) Console.Write('╣');
                else Console.Write('═');
            }
        }
        private void RenderInfo()
        {
            for(int i = _info.Count - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(2, Console.WindowHeight - 1 - _info.Count + i);
                Console.ForegroundColor = _fontColors[i];
                Console.BackgroundColor = _backgroundColors[i];
                Console.Write(_info[i]);
                Console.ResetColor();
            }
        }
    }
}
