using GameShop.App.Components;
using System.Text;

namespace GameShop.App.ViewsComponents
{
    static internal class FrameManager
    {
        /// <summary>
        /// Initializes and renders a frame around the console window, including a logo at the top.
        /// </summary>
        /// <remarks>This method dynamically adjusts the frame dimensions based on the current console
        /// window size. The frame consists of box-drawing characters, with the logo centered at the top.</remarks>
        static public void FrameInit()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            string logo = " | GameShop | ";
            for(int y = 0; y < height; y++)
            {
                StringBuilder line = new();
                for (int x = 0; x < width; x++)
                {
                    if (y == 0) line.Append(x == 0 ? '╔' : x == width - 1 ? '╗' : '═'); // Top
                    else if (y == height - 1) line.Append(x == 0 ? '╚' : x == width - 1 ? '╝' : '═'); // Bottom
                    else line.Append(x == 0 || x == width - 1 ? '║' : ' '); // Center
                }
                Console.SetCursorPosition(0, y);
                Console.Write(line.ToString());
            }

            // Logo
            Console.SetCursorPosition((width - logo.Length) / 2, 0);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(logo);
            Console.ResetColor();
            // Username
            if (UserManager.Logged)
            {
                string username = $" | {UserManager.UserNickname} | ";
                Console.SetCursorPosition((width - username.Length) / 2, Console.WindowHeight - 1);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(username);
                Console.ResetColor();
            }
        }
    }
}
