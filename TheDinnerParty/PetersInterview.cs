using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class PetersInterview : Content
    {
        public void StartPeterInterview()
        {
            Console.Title = "The Dinner Party : Interview";
            location = "Police Station";
            DrawScreen();

            //GabrielDescription();
            //DrawScreen();
            //GabrielDescriptionResponse();
            //DrawScreen();
            //GabrielQuestions();
        }
    }
}
