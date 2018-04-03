using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class Content
    {
        int contentHeight = 3;//this is the top of the screen, right below the header which takes up 3 spaces
        int choiceHeight = 15;//this is the bottom of the content screen. Maybe I'll draw a line there later.
        int choiceNumber = 1;//this is the eventual number of choices that i'll have that will display

        public bool showNotes = false;

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
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, choiceHeight);
            Console.WriteLine("Choices: ");

            if (showNotes)
                AddNotesChoice();

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach(string s in choices)
            {
                Console.SetCursorPosition(2, choiceHeight + 1);
                Console.WriteLine(choiceNumber + ". " + s + "\n");//format the choices to be numbered
                choiceHeight++;
                choiceNumber++;
            }
        }

        void AddNotesChoice()
        {
            Console.SetCursorPosition(50, choiceHeight);
            Console.WriteLine("Press \"N\" to open your notes.");
        }
    }
}
