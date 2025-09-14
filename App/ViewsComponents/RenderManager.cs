using System.Xml.Linq;

namespace GameShop.App.ViewsComponents
{
    internal class RenderManager
    {
        private List<string> _menu = [];
        private List<ConsoleColor> _fontColors = [];
        private List<ConsoleColor> _backgroundColors = [];

        public void AddElement(string element, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            _menu.Add(element);
            _fontColors.Add(fontColor);
            _backgroundColors.Add(backgroundColor);
        }
        public void RenderMenu()
        {
            for(int i = 0; i < _menu.Count; i++)
            {
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = _fontColors[i];
                    Console.BackgroundColor = _backgroundColors[i];
                }
                Console.SetCursorPosition(2, i);
                Console.Write(_menu[i]);
                Console.ResetColor();
            }
        }
        public void ChangeColorOfOption(int position, ConsoleKey key)
        {
            int previousPosition = key == ConsoleKey.UpArrow ? position -= 1 : position += 1;
            // Previous position
            Console.SetCursorPosition(2, previousPosition);
            Console.ForegroundColor = _fontColors[previousPosition];
            Console.BackgroundColor = _backgroundColors[previousPosition];
            Console.Write(_menu[previousPosition]);
            Console.ResetColor();
            // Current position
            Console.SetCursorPosition(2, position);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = _backgroundColors[position];
            Console.Write(_menu[position]);
            Console.ResetColor();
        }
    }
}
