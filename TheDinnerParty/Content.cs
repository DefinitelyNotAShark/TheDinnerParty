using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class Content : Input
    {
        int width = 120;
        int height = 30;

        int headerPos = 55;
        int headerHeight = 1;

        int titlePos = 2;
        public string location = "House";
        static string titleString = "The Dinner Party";

        int contentHeight = 3;//this is the top of the screen, right below the header which takes up 3 spaces
        int choiceHeight = 15;//this is the bottom of the content screen. Maybe I'll draw a line there later.
        int choiceNumber = 1;//this is the eventual number of choices that i'll have that will display

        public static bool showNotes = false;

        public void AddContent(List<string> content)//make a list of strings and put them in this func. to show on display.
        {
            contentHeight = 3;
            Console.ForegroundColor = ConsoleColor.White; 
            foreach (string s in content)
            {
                Console.SetCursorPosition(2, contentHeight);
                Console.WriteLine(s + "\n");
                contentHeight++;
            }
        }

        public void ShowChoices(List<string> choices)
        {

            choiceNumber = 1;//reset the choice num
            choiceHeight = 20;//reset choice height

            if (NotesPage.notebookOpened)          
                choiceHeight = 24;

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, choiceHeight);
            Console.WriteLine("Choices: ");

            if (showNotes)
            {
                AddNotesChoice();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach(string s in choices)
            {
                Console.SetCursorPosition(2, choiceHeight + 1);
                Console.WriteLine(choiceNumber + ". " + s + "\n");//format the choices to be numbered
                choiceHeight++;
                choiceNumber++;
            }
        }

        public void ClueAlert(string clue)
        {
            Console.SetCursorPosition(2, 16);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You have a new clue: " + clue);
            Console.ForegroundColor = ConsoleColor.White;
        }

        void AddNotesChoice()
        {
            Console.SetCursorPosition(50, choiceHeight);
            if(NotesPage.notebookOpened == false)
            Console.WriteLine("Press \"N\" to open your notes.");

            else if(NotesPage.notebookOpened == true)
                Console.WriteLine("Press \"B\" to get back to the case.");
        }

        public void DrawScreen()
        {
            Console.Clear();
            DrawOutline();//draws box
            DrawHeaders();//draws interface at top of screen. Right now only shows location.
            DrawChoiceSeperation();
            SetCursor();//this moves the cursor so the screen scrolls correctly.
        }

        private void DrawChoiceSeperation()
        {
            Console.SetCursorPosition(1, 19);//20 is where the choices start
            for (int i = 0; i < width - 2; i++)//the -2 is so the edges stay
            {
                WriteThis(ConsoleColor.White, "-");
            }

            Console.SetCursorPosition(1, 27);//20 is where the choices must end
            for (int i = 0; i < width - 2; i++)//the -2 is so the edges stay
            {
                WriteThis(ConsoleColor.White, "-");
            }
        }

        public void DrawOutline()
        {
            DrawTopLine();
            DrawSideBorders();
            DrawBottomLine();
        }

        private void DrawHeaders()
        {
            Console.SetCursorPosition(titlePos, headerHeight);
            WriteThis(ConsoleColor.Yellow, titleString);
            Console.SetCursorPosition(headerPos, headerHeight);
            WriteThis(ConsoleColor.White, "Location: ");
            WriteThis(locationColor(), location);
            Console.SetCursorPosition(0, headerHeight + 1);

            for (int i = 0; i < width; i++)
            {
                WriteThis(ConsoleColor.White, "-");
            }
        }

        public void DrawNoteHeader()
        {
            Console.SetCursorPosition(titlePos, headerHeight);
            WriteThis(ConsoleColor.White, "Notes");
            Console.SetCursorPosition(headerPos, headerHeight);
            WriteThis(ConsoleColor.White, NotesPage.notePageType);//this isn't showing up yet
            Console.SetCursorPosition(0, headerHeight + 1);

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
            Console.SetCursorPosition(1, 0);//this keeps the app scrolled up
            Console.SetCursorPosition(2, 28);//and then we set it to the one we really need it to be at!
        }

        private void DrawTopLine()
        {
            for (int i = 0; i < width; i++)
            {
                WriteThis(ConsoleColor.White, "-");
            }
        }

        void DrawSideBorders()
        {
            for (int a = 0; a < height - 3; a++)//draws side borders
            {
                Console.SetCursorPosition(0, a + 2);//set cursor to left
                WriteThis(ConsoleColor.White, "|");
                Console.SetCursorPosition(width - 1, a + 2);//set cursor to right
                WriteThis(ConsoleColor.White, "|");
            }
        }

        private void DrawBottomLine()
        {
            for (int i = 1; i < width - 1; i++)//draws bottom line
            {
                Console.SetCursorPosition(i, height - 1);
                WriteThis(ConsoleColor.White, "-");
            }
        }

        public void WriteThis(ConsoleColor color, string content)//easy way to write in the color I want
        {
            Console.ForegroundColor = color;
            Console.Write(content);
        }
    }
}

