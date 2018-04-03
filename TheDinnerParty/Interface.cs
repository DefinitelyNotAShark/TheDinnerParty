using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TheDinnerParty
{
    class Interface
    {
        int width = 120;
        int height = 30;

        int headerPos = 55;
        int headerHeight = 1;

        int titlePos = 2;
        public string location = "House";
        static string titleString = "The Dinner Party";

        public void DrawScreen()
        {
            Clear();
            DrawOutline();//draws box
            DrawHeaders();//draws interface at top of screen. Right now only shows location.
            DrawChoiceSeperation();
            SetCursor();//this moves the cursor so the screen scrolls correctly.
        }

        private void DrawChoiceSeperation()
        {
            SetCursorPosition(1, 19);//20 is where the choices start
            for (int i = 0; i < width - 2; i++)//the -2 is so the edges stay
            {
                WriteThis(ConsoleColor.White, "-");
            }

            SetCursorPosition(1, 27);//20 is where the choices must end
            for (int i = 0; i < width - 2; i++)//the -2 is so the edges stay
            {
                WriteThis(ConsoleColor.White, "-");
            }
        }

        void DrawOutline()
        {
            DrawTopLine();
            DrawSideBorders();
            DrawBottomLine();
        }

        private void DrawHeaders()
        {
            SetCursorPosition(titlePos, headerHeight);
            WriteThis(ConsoleColor.Yellow, titleString);
            SetCursorPosition(headerPos, headerHeight);
            WriteThis(ConsoleColor. White, "Location: ");
            WriteThis(locationColor(), location);
            SetCursorPosition(0, headerHeight + 1);

            for (int i = 0; i < width; i++)
            {
                WriteThis(ConsoleColor.White, "-");
            }

        }

        private ConsoleColor locationColor()
        {
            if (location == "House")
                return ConsoleColor.White;
            if (location == "Police Station")
                return ConsoleColor.Cyan;
            if (location == "Crime Scene")
                return ConsoleColor.Red;
            if (location == "Interrogation Room")
                return ConsoleColor.Green;

            else
                return ConsoleColor.White;
        }

        private void SetCursor()
        {
            SetCursorPosition(1, 0);//this keeps the app scrolled up
            SetCursorPosition(2, 28);//and then we set it to the one we really need it to be at!
        }

        private void DrawTopLine()
        {
            for(int i = 0; i < width; i++)
            {
                WriteThis(ConsoleColor.White, "-");
            }
        }

        void DrawSideBorders()
        {
            for (int a = 0; a < height - 3; a++)//draws side borders
            {
                SetCursorPosition(0, a + 2);//set cursor to left
                WriteThis(ConsoleColor.White, "|");
                SetCursorPosition(width - 1, a + 2);//set cursor to right
                WriteThis(ConsoleColor.White, "|");
            }
        }

        private void DrawBottomLine()
        {
            for (int i = 1; i < width - 1; i++)//draws bottom line
            {
                SetCursorPosition(i, height - 1);
                WriteThis(ConsoleColor.White, "-");
            }
        }


        void WriteThis(ConsoleColor color, string content)//easy way to write in the color I want
        {
            ForegroundColor = color;
            Write(content);
        }
    }
}
