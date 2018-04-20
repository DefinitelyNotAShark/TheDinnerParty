using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TheDinnerParty
{
    class TitleScreen
    {
        private int centeredTitleInt = 6;
        private int centeredEnterInt = 45;
        public void DrawTitleScreen()
        {
            CursorVisible = false;
            DrawTitleAsciiArt();
            EnterText();
        }

        void DrawTitleAsciiArt()
        {
            ForegroundColor = ConsoleColor.DarkRed;
            SetCursorPosition(centeredTitleInt, 1);
            WriteLine(" ______  __ __    ___      ___    ____  ____   ____     ___  ____       ____   ____  ____  ______  __ __ ");
            SetCursorPosition(centeredTitleInt, 2);
            WriteLine("|      ||  |  |  /  _]    |   \\  |    ||    \\ |    \\   /  _]|    \\     |    \\ /    ||    \\|      ||  |  |");
            SetCursorPosition(centeredTitleInt, 3);
            WriteLine("|      ||  |  | /  [_     |    \\  |  | |  _  ||  _  | /  [_ |  D  )    |  o  )  o  ||  D  )      ||  |  |");
            SetCursorPosition(centeredTitleInt, 4);
            WriteLine("|_|  |_||  _  ||    _]    |  D  | |  | |  |  ||  |  ||    _]|    /     |   _/|     ||    /|_|  |_||  ~  |");
            SetCursorPosition(centeredTitleInt, 5);
            WriteLine("  |  |  |  |  ||   [_     |     | |  | |  |  ||  |  ||   [_ |    \\     |  |  |  _  ||    \\  |  |  |___, |");
            SetCursorPosition(centeredTitleInt, 6);
            WriteLine("  |  |  |  |  ||     |    |     | |  | |  |  ||  |  ||     ||  .  \\    |  |  |  |  ||  .  \\ |  |  |     |");
            SetCursorPosition(centeredTitleInt, 7);
            WriteLine("  |__|  |__|__||_____|    |_____||____||__|__||__|__||_____||__|\\_|    |__|  |__|__||__|\\_| |__|  |____/ ");
        }

        void EnterText()
        {
            SetCursorPosition(centeredEnterInt - 10, 9);
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("A grisly murder,");

            SetCursorPosition(centeredEnterInt - 2, 12);
                ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("A house full of suspects,");

            SetCursorPosition(centeredEnterInt + 7, 15);
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("Welcome to the dinner party.");

            SetCursorPosition(centeredEnterInt, 22);
            ForegroundColor = ConsoleColor.White;
            WriteLine("Press any key to start!");
            
        }
    }
}
