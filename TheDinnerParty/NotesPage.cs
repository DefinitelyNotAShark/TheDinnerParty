using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class NotesPage : Content
    {
        public static string notePageType;
        public int pageNumber = 1;
        private int totalPageNumbers = 3;

        public void OpenNotebook()
        {
            DrawNotesPage();
        }

        void SetNoteTypeFromPageNumber()
        {
            switch (pageNumber)
            {
                case 1:
                    notePageType = "General Notes";
                    break;
                case 2:
                    notePageType = "Clues";
                    break;
                case 3:
                    notePageType = "About Suspects";
                    break;
            }
        }

        void ShowPageInfo()
        {
            //show page number at bottom
            Console.SetCursorPosition(60, 27);//bottom middle
            WriteThis(ConsoleColor.Gray, "page " + pageNumber +  "/" + totalPageNumbers);
            //set note title depending on page number
        }

        void DrawNotesPage()
        {
            Console.Clear();
            DrawOutline();//draws box
            DrawNoteHeader();
            ShowPageInfo();
        }
    }
}
