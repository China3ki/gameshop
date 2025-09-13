namespace GameShop.App.ViewsComponents
{
    internal class MenuManager
    {
        private List<string> _menu = [];
        private List<ConsoleColor> _fontColors = [];
        private List<ConsoleColor> _backgroundColors = [];
        public void AddElementOfMenu(string element, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            _menu.Add(element);
            _fontColors.Add(fontColor);
            _backgroundColors.Add(backgroundColor);
        }
        private int ChangePositon()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;


            } while (key != ConsoleKey.Enter);
            return 0;
        }
    }
}
