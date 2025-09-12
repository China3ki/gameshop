using System.Text;

namespace GameShop.App.ViewsComponents
{
    internal class FrameManager
    {
        /// <summary>
        /// Initializes and renders a decorative frame around the console window, including a centered logo at the top.
        /// </summary>
        /// <remarks>This method dynamically adjusts the frame dimensions based on the current console
        /// window size. The frame includes borders, corners, and a centered logo at the top. The logo is displayed in a
        /// distinct color.</remarks>
        public void FrameInit()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            string logo = " | GameShop | ";
            StringBuilder frame = new();
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    // Corners
                    if(y == 0 && x == 0) frame.Append('╔');
                    else if(y == 0 && x == width - 1) frame.Append('╗');
                    else if (y == height - 1 && x == 0) frame.Append('╚');
                    else if (y == height - 1 && x == width - 1) frame.Append('╝');
                    // Borders
                    else if ((y > 0 && y < height - 1) && (x == 0 || x == width - 1)) frame.Append('║');
                    else if ((y == 0 || y == height - 1) && (x > 0 && x < width - 1)) frame.Append('═');
                    // Inside frame
                    else if ((y != 0 && y != height - 1) && (x > 0 && x < width - 1)) frame.Append(' ');
                }
            }
            Console.Write(frame.ToString());

            // Logo
            Console.SetCursorPosition((width - logo.Length) / 2, 0);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(logo);
            Console.ResetColor();
        }
    }
}
