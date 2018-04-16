using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class PetersInterview : Content
    {
        //remember to set location in police station
        private List<string> PeterText = new List<string>();
        private List<string> choiceList = new List<string>();

        bool loopBreak = false;

        public void StartPeterInterview()
        {
            Console.Title = "The Dinner Party : Interview";
            location = "Police Station";
            DrawScreen();
            PeterDescription();            

            while (!loopBreak)
            {
                DrawScreen();
                PeterQuestions();
            }

        }

        private void PeterDescription()
        {
            PeterText.Add("Peter is an older man with a large gut and mean eyes.");
            PeterText.Add("He manages to look bored and interested in you at the same time, which confuses you.");
            PeterText.Add("Here's what you know about Peter: ");
            PeterText.Add("- He is a retired cop.");
            PeterText.Add("- His police badge was never reported missing.");
            PeterText.Add("- He was Bruce's uncle.");
            PeterText.Add("");
            AddAllText();
            PeterQuestions();
        }


        //need another function here just for choices again

        void PeterQuestions()
        {

            choiceList.Add("\"Where were you from 10 to 11?\" (alibi)");

            choiceList.Add("Interview someone else");

            if (SearchCrimeScene.checkedFloorboards)
                choiceList.Add("\"(clue) Why is your police badge in Bruce's room?\"");

            if (Suspects.talkedToLarissaAboutPeterButLarissasTheKiller)
                choiceList.Add("\"I can't get Larissa to admit anything about the money.\"");


            AddChoicesForInput();
            //sub questions
            DrawScreen();

            switch (playerInputToInt)
            {
                case 1://where were you from 10 to 11
                    if (Suspects.Killer == "Peter")
                    {//killer text
                        PeterText.Add("\"Why are you questioning me?\"");
                        PeterText.Add("\"Do you seriously think I'd kill my nephew?\"");
                        PeterText.Add("\"Why would I ruin a perfectly good night of drinking?\"");
                        PeterText.Add("");
                        PeterText.Add("\"After Bruce went to bed, Agatha and I were drinking in the dining room.\"");
                        PeterText.Add("\"We got through quite a lot of liquor.\"");
                    }
                    else
                    {//inno text
                        PeterText.Add("\"She can confirm it, you know.\"");
                        PeterText.Add("\"Do you seriously think I'd kill my nephew?\"");
                        PeterText.Add("");                       
                        PeterText.Add("\"Peter leans forward angrily.\"");
                        PeterText.Add("\"I was having drinks with Agatha in the dining room most of the night.\"");

                    }
                        if (Suspects.heardThatPeterWasInTheDiningRoom == false)
                        {
                            Suspects.heardThatPeterWasInTheDiningRoom= true;
                            Suspects.InterviewClueList.Add("Peter claims he was in the dining room when the murder took place.");
                            ClueAlert("Peter claims he was in the dining room.");
                        }

                    AddAllText();
                    choiceList.Add("Got it.");
                    AddChoicesForInput();
                    break;
                case 3://police badge in Bruce's room
                    PeterText.Add("Peter looks surprised.");
                    PeterText.Add("\"Where the hell did you find that?.\"");
                    PeterText.Add("\"I've been lookin' for it everywhere.\"");
                    PeterText.Add("\"That bitch Larissa took it, didn't she?\"");
                    PeterText.Add("");
                    PeterText.Add("\"You're looking for a killer, you'll want to look at her.\"");

                    if (Suspects.Killer == "Larissa")
                    {
                        PeterText.Add("\"All she does is lie.\"");
                        PeterText.Add("\"Bet she won't even tell you we used to know each other.\"");
                        PeterText.Add("\"You know what?\"");
                        PeterText.Add("\"You'll want to ask her how she made her money.\"");
                        PeterText.Add("\"I can personally guarantee it wasn't made legally.\"");

                        AddAllText();
                        choiceList.Add("\"How would you know that?\"");
                        choiceList.Add("\"Did you have anything to do with it?\"");
                        AddChoicesForInput();
                        DrawScreen();
                        PeterText.Add("\"Ha! You think I'd tell an officer anything about my role in this?.\"");
                        PeterText.Add("\"Look. Ask her about the money.\"");
                        PeterText.Add("");
                        PeterText.Add("\"What is it they always say?\"");
                        PeterText.Add("\"Most of the time if someone dies, the spouse did it?\"");
                        PeterText.Add("\"Well if luck is on my side, I'll have pointed you in the right direction.\"");

                        if (Suspects.talkedToPeterAboutLarissa == false)
                        {
                            Suspects.talkedToPeterAboutLarissa = true;
                            Suspects.InterviewClueList.Add("Peter used to know Larissa and might know how she made her money.");
                            ClueAlert("Peter and Larissa have a history.");
                        }


                    }

                    else if (Suspects.Killer == "Peter")
                    {
                        PeterText.Add("\"You'll want to ask her how she made her money.\"");
                        PeterText.Add("\"She's no angel. I've known her a while. Longer than she knew Bruce.\"");

                        if (Suspects.talkedToPeterAboutLarissa == false)
                        {
                            Suspects.talkedToPeterAboutLarissa = true;
                            Suspects.InterviewClueList.Add("Peter used to know Larissa and might know how she made her money.");
                            ClueAlert("Peter and Larissa have a history.");
                        }
                    }



                    AddAllText();
                    choiceList.Add("Got it.");
                    AddChoicesForInput();
                    break;
                
                case 4:
                    PeterText.Add("Peter sighs, and seems to contemplate whether to tell the truth.");
                    PeterText.Add("\"You know what? If it helps catch my nephew's killer, I'll tell the truth.\"");
                    PeterText.Add("\"I hope you'll understand that this was a long time ago, and that I've changed.\"");
                    PeterText.Add("");
                    PeterText.Add("\"A long time ago, I met a woman named Larissa.\"");
                    PeterText.Add("\"This was almost a decade ago when I was still a cop.\"");
                    PeterText.Add("\"She was trying to steal my wallet, stupid girl.\"");
                    AddAllText();
                    choiceList.Add("\"Please, go on.\"");
                    AddChoicesForInput();
                    DrawScreen();
                    PeterText.Add("\"Well, she was begging me not to arrest her. She looked so pathetic.\"");
                    PeterText.Add("\"I told her this idea I'd been playing with in my head for a while.\"");
                    PeterText.Add("\"It was a proposition. A way to make us both rich.\"");
                    PeterText.Add("");
                    PeterText.Add("\"I knew about this old museum where the security wasn't very tight.\"");
                    PeterText.Add("\"I just needed someone to do the dirty work for me.\"");
                    AddAllText();
                    choiceList.Add("\"You robbed a museum?\"");
                    AddChoicesForInput();
                    DrawScreen();
                    PeterText.Add("\"She robbed it. I only gave her my badge.\"");
                    PeterText.Add("\"She used it to get past the night guards by pretending to be making sure the building was secure.\"");
                    PeterText.Add("\"She took some of the paintings, and walked out in under 10 minutes.\"");
                    PeterText.Add("");
                    PeterText.Add("\"Larissa worked at an auction, so it was easy to get the paintings sold to the right people.\"");
                    PeterText.Add("\"I spent my money. She saved hers.\"");
                    PeterText.Add("\"And it seemed like everything was going to get swept under the rug.\"");
                    PeterText.Add("");
                    PeterText.Add("\"But then she met Bruce. He was an excuse to get herself out of the states without suspicion.\"");
                    PeterText.Add("\"She had no idea I was his uncle.\"");
                    PeterText.Add("\"She couldn't imagine I'd tell Bruce what she did.\"");
                    AddAllText();
                    choiceList.Add("\"Did Bruce turn her in?\"");
                    AddChoicesForInput();
                    DrawScreen();
                    PeterText.Add("\"Bruce loved her. He wouldn't turn her in.\"");
                    PeterText.Add("\"He didn't care what she'd done.\"");
                    PeterText.Add("\"But my guess was Larissa couldn't risk being so close to people who knew her secret.\"");
                    PeterText.Add("");
                    PeterText.Add("\"She was in the kitchen. She had access to the knife.\"");
                    PeterText.Add("\"I don't know for sure that it was her, but I'd bet my life on it.\"");
                    PeterText.Add("\"I'm lucky I was talking to Agatha the whole night or she would have killed me too.\"");
                    AddAllText();
                    choiceList.Add("\"I see...\"");
                    AddChoicesForInput();
                    DrawScreen();

                    break;

                case 2:
                    //go back to interview menu!
                    SuspectInterviewPage suspectInterviewPage = new SuspectInterviewPage();
                    suspectInterviewPage.StartInterview();
                    break;
            }
        }


        #region userInterface Functions
        void AddAllText()
        {
            AddContent(PeterText);
            PeterText.Clear();
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
