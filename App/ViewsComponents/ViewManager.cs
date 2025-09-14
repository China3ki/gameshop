
namespace GameShop.App.ViewsComponents
{
    internal class ViewManager
    {
        private RenderManager _renderManager = new();
        private InfoManager _infoManager = new();
        private int _maxSizeOfPage; // Paginacja do dodania
        private int _numberOfElements;

        public int InitViewManager()
        {
            Console.Clear();
            FrameManager.FrameInit();
            _renderManager.RenderMenu();
            _infoManager.InitInfo();
            return ChangePositon();
        }
        /// <summary>
        /// Adds a new menu element with the specified text and colors.
        /// </summary>
        /// <remarks>This method updates the menu by adding a new element with the specified appearance.
        /// The total number of elements in the menu is incremented after the addition.</remarks>
        /// <param name="element">The text of the menu element to add. Cannot be null or empty.</param>
        /// <param name="fontColor">The color of the text for the menu element.</param>
        /// <param name="backgroundColor">The background color of the menu element.</param>
        public void AddElementOfMenu(string element, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            _renderManager.AddElement(element, fontColor, backgroundColor);
            _numberOfElements++;
        }
        public void AddElementOfInfo(string element, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            _infoManager.AddElement(element, fontColor, backgroundColor);
        }
        /// <summary>
        /// Updates the current position based on user input and waits for the Enter key to confirm the selection.
        /// </summary>
        /// <remarks>This method listens for key presses and adjusts the position accordingly. The
        /// position is managed  by an instance of <see cref="PositionManager"/>. The method continues to process key
        /// inputs until  the Enter key is pressed, at which point the final position is returned.</remarks>
        /// <returns>The final position as determined by the user's input.</returns>
        private int ChangePositon()
        {
            PositionManager positionManager = new(_numberOfElements, _numberOfElements);
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                positionManager.ChangePosition(key);
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                {
                    _renderManager.ChangeColorOfOption(positionManager.Position, key);
                }

            } while (key != ConsoleKey.Enter);
            return positionManager.Position;
        }
    }
}
