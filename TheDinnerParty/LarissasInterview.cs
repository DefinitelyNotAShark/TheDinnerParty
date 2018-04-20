using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDinnerParty
{
    class LarissasInterview : Content
    {
        //remember to set location in police station
        private List<string> LarissaText = new List<string>();
        private List<string> choiceList = new List<string>();

        bool loopBreak = false;

        public void StartLarissaInterview()
        {
            Console.Title = "The Dinner Party : Interview";
            location = "Police Station";
            DrawScreen();
            LarissaDescription();
            DrawScreen();
            LarissaQuestions();

            while (!loopBreak)
            {
                DrawScreen();
                LarissaQuestions();
            }

        }

        private void LarissaDescription()
        {
            LarissaText.Add("Larissa's eyes are red from crying.");
            LarissaText.Add("You've heard that she's quite wealthy, but you'd never know it just by looking.");
            LarissaText.Add("Her T-shirt and lack of jewelry give her a very plain appearance.");
            LarissaText.Add("Here's what you know about Larissa: ");
            LarissaText.Add("- She's works at an auction house");
            LarissaText.Add("- She has a large amount of money. It's unknown where the money came from.");
            LarissaText.Add("- She was engaged to Bruce.");
            LarissaText.Add("");
            LarissaText.Add("She refuses to talk first.");
            AddAllText();
            LarissaQuestions();
        }


        //need another function here just for choices again

        void LarissaQuestions()
        {

            choiceList.Add("\"Where were you from 10 to 11?\" (alibi)");

            choiceList.Add("Interview someone else");



            if (Suspects.talkedToPeterAboutLarissa)
            {
                choiceList.Add("\"(Clue)Peter tells me that you two have a history.\"");
            }


            AddChoicesForInput();
            //sub questions
            DrawScreen();

            switch (playerInputToInt)
            {
                case 1://where were you from 10 to 11
                    if (Suspects.Killer == "Larissa")
                    {//killer text
                        LarissaText.Add("\"I was with Bruce until we all started drinking.\"");
                        LarissaText.Add("\"He asked to be excused around 9:30? 9:45?.\"");
                        LarissaText.Add("\"He went up to bed.\"");
                        LarissaText.Add("\"I don't think he was feeling good from all the liquor.\"");
                        LarissaText.Add("");
                        LarissaText.Add("\"After Bruce went to bed, I went to the kitchen to make him lunch.\"");
                        LarissaText.Add("\"I'm afraid no one can confirm that I was in the kitchen the whole time,\"");
                    }
                    else
                    {//inno text
                        LarissaText.Add("\"After Bruce went to bed around 10 or so, I went to the kitchen.\"");
                        LarissaText.Add("\"Bruce was going to quit his job tomorrow, and he was very nervous.\"");
                        LarissaText.Add("\"He wouldn't even drink with us.\"");
                        LarissaText.Add("\"I thought I'd make him something special to keep his nerves in check.\"");
                        LarissaText.Add("");
                        LarissaText.Add("\"I'm afraid no one can confirm that I was in the kitchen the whole time,\"");
                        LarissaText.Add("\"But if you want, you can find the pork chops in the fridge.\"");
                        LarissaText.Add("\"They took me until midnight to make.\"");

                        if (Suspects.Killer == "Peter")
                        {
                            LarissaText.Add("\"At one point peter stumbled in drunk and demanded some of them.\"");
                            LarissaText.Add("\"It was strange. He acted drunk, but his eyes were pretty clear.\"");
                            LarissaText.Add("\"When I said no, he walked away.\"");
                        }

                        else if(Suspects.Killer == "Gabriel")
                        {
                            LarissaText.Add("\"Gabriel came in and asked for a taste when I was done making them.\"");
                            LarissaText.Add("\"Very nice man, Gabriel.\"");
                        }
                    }

                    if (Suspects.heardThatLarissaWasIntTheKitchen == false)
                    {
                        Suspects.heardThatLarissaWasIntTheKitchen = true;
                        Suspects.InterviewClueList.Add("Larissa claims she was in the kitchen when the murder took place.");
                        ClueAlert("Larissa claims she was in the kitchen.");
                    }

                    AddAllText();
                    choiceList.Add("Got it.");
                    AddChoicesForInput();
                    break;

                case 3://peter and Larissa's history


                    LarissaText.Add("Larissa looks uncomfortable.");
                    LarissaText.Add("");
                    LarissaText.Add("\"We did know each other, yes.\"");
                    LarissaText.Add("\"It's not what you think. We were never together.\"");
                    LarissaText.Add("\"How much did Peter tell you about this?\"");

                    AddAllText();
                    choiceList.Add("\"He told me about what you did. (bluff)\"");
                    choiceList.Add("\"He didn't tell me much. Just that it had to do with how you got your money. (truth)\"");
                    AddChoicesForInput();
                    DrawScreen();

                    if (Suspects.Killer == "Larissa")
                    {
                        LarissaText.Add("\"Yes I used to know him.\"");
                        LarissaText.Add("\"I knew him back when he was a police officer.\"");
                        LarissaText.Add("\"He was...easily persuaded to look the other way if someone had a handful of cash.\"");
                        LarissaText.Add("\"If anything, you should be looking more into how Peter's been spending HIS money.\"");
                        LarissaText.Add("");
                        LarissaText.Add("Seems she doesn't want to talk about it.");
                        LarissaText.Add("Maybe I can get Peter to tell me what happened.");

                        if (Suspects.talkedToLarissaAboutPeterButLarissasTheKiller == false)
                        {
                            Suspects.talkedToLarissaAboutPeterButLarissasTheKiller = true;
                            Suspects.InterviewClueList.Add("Larissa won't admit her history with Peter.");
                            ClueAlert("Larissa has a history with Peter, but refuses to talk about it.");
                        }

                    }

                    else
                    {
                        LarissaText.Add("She covers her face with her hands.");
                        LarissaText.Add("\"He told you?\"");
                        LarissaText.Add("\"Did he tell you it was all his idea?\"");
                        LarissaText.Add("\"I swear, I didn't want to do it.\"");
                        LarissaText.Add("");
                        LarissaText.Add("\"He gave me his police badge.\"");
                        LarissaText.Add("\"He told me how easy it would be to do it.\"");
                        LarissaText.Add("\"He said he knew how much I needed the money.\"");
                        LarissaText.Add("");

                        AddAllText();
                        choiceList.Add("\"What exactly did you do?\"");
                        AddChoicesForInput();
                        DrawScreen();

                        LarissaText.Add("\"It was so long ago. I was desperate.\"");
                        LarissaText.Add("\"I used his badge to get into a museum at night.\"");
                        LarissaText.Add("\"I showed my badge to the officers, said I was inspecting the security.\"");
                        LarissaText.Add("");
                        LarissaText.Add("\"I got a couple paintings off the walls\"");
                        LarissaText.Add("\"I was so scared that security would come running any minute.\"");
                        LarissaText.Add("\"But I got out with the paintings.\"");
                        LarissaText.Add("");
                        LarissaText.Add("\"They were easy to smuggle into the auction.\"");
                        LarissaText.Add("\"We made so much money off of them...\"");
                        LarissaText.Add("\"Peter took 60 percent of it. I got 40.\"");

                        if (Suspects.Killer == "Peter")
                        {
                            LarissaText.Add("");
                            LarissaText.Add("\"But...Recently...there have been some issues with him.\"");
                            AddAllText();
                            choiceList.Add("What do you mean?");
                            AddChoicesForInput();
                            DrawScreen();

                            LarissaText.Add("\"He's been calling us, threatening Bruce.\"");
                            LarissaText.Add("\"He was asking for more money, or he'll turn me in.\"");
                            LarissaText.Add("\"I mean, who would trust my word over a police officer's word?\"");
                            LarissaText.Add("\"I'm so afraid...that...maybe that's the reason my husband is dead.\"");
                        }

                        if (Suspects.Killer != "Peter")
                        {
                            LarissaText.Add("");
                            LarissaText.Add("\"But He's no killer.\"");
                            LarissaText.Add("\"He likes to keep his hands clean.\"");
                            LarissaText.Add("\"If he wanted my husband dead, he wouldn't be a suspect right now.\"");
                            LarissaText.Add("\"Oh God, please don't think the worst of me.\"");
                            LarissaText.Add("\"I just want all these stupid secrets and grudges to stop.\"");
                        }

                    }
                    AddAllText();
                    choiceList.Add("Got it.");
                    AddChoicesForInput();
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
                AddContent(LarissaText);
                LarissaText.Clear();
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



