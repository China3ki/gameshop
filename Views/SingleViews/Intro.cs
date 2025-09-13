using GameShop.Interfaces;
using System.Text;

namespace GameShop.Views.SingleViews
{
    internal class Intro(ViewType nextView, string[] info) : InfoView(nextView, info)
    {
        public override void InitView()
        {
            base.InitView();
            LoadingBar();
        }
        /// <summary>
        /// Displays a loading bar animation in the console, simulating a progress bar.
        /// </summary>
        /// <remarks>The loading bar is rendered as a graphical box with a progress indicator that fills
        /// over time. The progress percentage is displayed below the bar and updates as the animation progresses. This
        /// method blocks the calling thread while the animation is running.</remarks>
        private void LoadingBar()
        {
            /// Bar
            for(int y = 0; y < 3; y++)
            {
                StringBuilder line = new();
                for (int x = 0; x < 27; x++)
                {
                    if (y == 0) line.Append(x == 0 ? '╔' : x == 26 ? '╗' : '═');
                    else if (y == 2) line.Append(x == 0 ? '╚' : x == 26 ? '╝' : '═');
                    else line.Append(x > 0 && x < 26 ? ' ' : '║');
                }
                Console.SetCursorPosition((Console.WindowWidth - 27) / 2, (Console.WindowHeight / 2) + 4 + y);
                Console.Write(line.ToString());
            }

            /// Timer
            int timer = 0;
            for(int i = 0; i < 25; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - 25) / 2 + i, (Console.WindowHeight / 2) + 5);
                Console.Write('█');
                timer += 4;
                Console.SetCursorPosition((Console.WindowWidth - 27) / 2, (Console.WindowHeight / 2) + 7);
                Console.Write($"{timer}%");
                Thread.Sleep(80);
            }
            Thread.Sleep(200);
        }
    }
}
