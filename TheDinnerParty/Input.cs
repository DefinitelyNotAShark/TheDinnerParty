using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class Input
    {
        string playerInput;
        public int playerInputToInt;
        int inputHeight = 28;
        static bool loopBreak = false;

      
   
        public void GetChoiceInput(int numberOfChoices)
        {
            loopBreak = false;
            while (loopBreak == false)//loop until input is valid
            {
                Console.SetCursorPosition(1, inputHeight);
                Console.ForegroundColor = ConsoleColor.Gray;//input is always gray
                playerInput = Console.ReadLine();//get input

                //if (CheckIfNotesAreOpened() == true)
                //     OpenNotebook();
  

                ClearInputLine();
                if (CheckIfChoiceIsValid(numberOfChoices))//if the input isn't valid
                {
                    loopBreak = true;
                }

                else
                    loopBreak = false;
            }
        }

        private void ClearInputLine()
        {
            Console.SetCursorPosition(1, inputHeight);
            Console.WriteLine("                                                       ");//clear the input line
        }

        bool CheckIfChoiceIsValid(int numberOfChoices)
        {
            #region checkinputstrings
            switch (playerInput)//max 8 choices cheap way to convert input to int
            {
                case "1":
                    playerInputToInt = 1;
                    break;
                case "2":
                    playerInputToInt = 2;
                    break;
                case "3":
                    playerInputToInt = 3;
                    break;
                case "4":
                    playerInputToInt = 4;
                    break;
                case "5":
                    playerInputToInt = 5;
                    break;
                case "6":
                    playerInputToInt = 6;
                    break;
                case "7":
                    playerInputToInt = 7;
                    break;
                case "8":
                    playerInputToInt = 8;
                    break;
                    #endregion
            }

            for (int i = 1; i < numberOfChoices + 1; i++)//checks if you typed a number that corresponds with a choice
            {
                if (playerInputToInt == i)
                {
                    return true;
                }
                else
                {
                    Console.SetCursorPosition(45, 28);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(playerInput + " is not a valid number");
                }
            }
            return false;
        }

        bool CheckIfNotesAreOpened()
        {
            if (playerInput.ToLower() == "n")
                return true;

            else
                return false;
        }
    }
}
