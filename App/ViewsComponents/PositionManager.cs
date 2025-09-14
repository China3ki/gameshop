using System.Diagnostics;

namespace GameShop.App.ViewsComponents
{
    internal class PositionManager(int maxSizeOfPage, int maxSizeOfMenuList)
    {
        public int Position { get; set; } = 1;
        //private readonly int _maxSizeOfPage = maxSizeOfPage;
        private readonly int _maxSizeOfPage = maxSizeOfPage;
        private int _maxSizeOfMenuList = maxSizeOfMenuList;
        public int Page { get; set; } = 0;
        public void ChangePosition(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Position = Position == 1 ? 1 : Position -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    Position = Position == _maxSizeOfPage - 1 ? _maxSizeOfPage - 1: Position += 1;
                    break;
            }
        }
        private void Pagination()
        {

        }
    }
}
