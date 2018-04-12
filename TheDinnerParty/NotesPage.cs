using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class NotesPage : Content
    {

        List<string> noteText = new List<string>();
        List<string> choiceList = new List<string>();

        public static string notePageType;
        public int pageNumber = 1;
        private int totalPageNumbers = 3;
        public static bool notebookOpened = false;

        public void OpenNotebook()
        {
            notebookOpened = true;

            while (notebookOpened)
            {
                SetNoteTypeFromPageNumber();
                DrawNotesPage();
                choiceList.Add("Page 1");
                choiceList.Add("Page 2");
                choiceList.Add("Page 3");
                AddChoicesForInput();
                //choices
                switch (playerInputToInt)
                {
                    case 1:
                        pageNumber = 1;
                        break;
                    case 2:
                        pageNumber = 2;
                        break;
                    case 3:
                        pageNumber = 3;
                        break;
                }
            }
        }

        public void CloseNotebook()
        {
            notebookOpened = false;
            Console.WriteLine("Fuck Man Im Closing JEEZ");
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

        void PageContent()
        {
            switch (pageNumber)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Console.SetCursorPosition(1, 4);
                   
                    break;
            }
        }

        void ShowPageNumber()
        {
            //show page number at bottom
            Console.SetCursorPosition(55, 27);//bottom middle
            WriteThis(ConsoleColor.Gray, "page " + pageNumber +  "/" + totalPageNumbers);
            //set note title depending on page number
        }

        void DrawNotesPage()
        {
            Console.Clear();
            DrawOutline();//draws box
            DrawNoteHeader();
            ShowPageNumber();
        }


        #region userInterface Functions
        void AddAllText()
        {
            AddContent(noteText);
            noteText.Clear();
        }
        void AddChoicesForInput()
        {
            ShowChoices(choiceList);//display choices
            GetChoiceInput(choiceList.Count());//get input about choices
            choiceList.Clear();
        }
        #endregion

    }
}
