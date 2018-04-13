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
        bool scriptStoryTold = false;

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
                AddQuestionTypes();
                LarissaQuestions();
            }

        }

        private void LarissaDescription()
        {
            LarissaText.Add("Larissa's eyes are red from crying.");
            LarissaText.Add("You've heard that she's quite wealthy, but you'd never know it just by looking.");
            LarissaText.Add("Her T-shirt and lack of jewelry give her a very plain appearance.");
            LarissaText.Add("She refuses to talk first.");
            AddAllText();
            AddQuestionTypes();
        }

        void AddQuestionTypes()
        {
            choiceList.Add("Questions about the murder");
            choiceList.Add("Questions about Larissa's relationship with other guests");
            choiceList.Add("Interview someone else");
            AddChoicesForInput();
            DrawScreen();
        }

        //need another function here just for choices again

        void LarissaQuestions()
        {
            switch (playerInputToInt)
            {
                case 1://questions about murder
                    LarissaText.Add("\"I want to know about what happened last night,\" you say.");
                    LarissaText.Add("there's no response from her.");
                    LarissaText.Add("You can't read her expression.");
                    AddAllText();
                    //choices
                    choiceList.Add("When was the last time you saw Bruce alive?");
                    choiceList.Add("Where were you from 10 to 11? (alibi)");
                    AddChoicesForInput();
                    //sub questions
                    DrawScreen();
                    switch (playerInputToInt)
                    {
                        case 1://last time you saw bruce alive
                            if (Suspects.Killer == "Larissa")
                            {//killer text
                                LarissaText.Add("\"I was with him until we all started drinking.\"");
                                LarissaText.Add("\"He asked to be excused around 9:30? 9:45?.\"");
                                LarissaText.Add("\"He went up to bed.\"");
                                LarissaText.Add("\"I don't think he was feeling good from all the liquor.\"");
                            }
                            else
                            {//inno text
                                LarissaText.Add("\"Maybe a quarter to ten?\"");
                                LarissaText.Add("\"Normally, I would have stayed with him the whole night, but...\"");
                                LarissaText.Add("\"We had an arguement. He went upstairs to bed.\"");
                                LarissaText.Add("\"I know that sounds suspicious, but it was stupid. I got jealous.\"");
                                AddAllText();
                                choiceList.Add("Jealous about what?");
                                AddChoicesForInput();
                                DrawScreen();
                                LarissaText.Add("\"Ms. Grestin, his mom, invited Irene over, and she was flirting with Bruce a little.\"");
                                LarissaText.Add("\"I didn't really like it. I asked him not to talk to her.\"");
                                LarissaText.Add("\"He was annoyed that I didn't trust him.\"");
                                LarissaText.Add("\"But I swear, it was just a little spat! I would NEVER hurt him!\"");
                            }
                            AddAllText();
                            choiceList.Add("Got it.");
                            AddChoicesForInput();
                            break;
                        case 2://where were you at time of the murder?
                            if (Suspects.Killer == "Larissa")
                            {//killer text
                                LarissaText.Add("\"I was here and there.\"");
                                LarissaText.Add("she laughs.");
                                LarissaText.Add("\"I know that's not much help, but no one really wanted to talk to me.\"");
                                LarissaText.Add("\"Ms. Grestin doesn't like me much, and she was drinking with Peter- uh, Mr. Zangara, I mean.\"");
                                LarissaText.Add("\"Gabriel's nice enough, but he was watching the game in the lounge, and didn't want to talk.\"");
                                LarissaText.Add("");
                                LarissaText.Add("\"I guess I was alone in the kitchen most of the time.\"");

                                if (Suspects.heardThatGabrielAsleepInLounge == false)
                                {
                                    Suspects.heardThatGabrielAsleepInLounge = true;
                                    Suspects.InterviewClueList.Add("Larissa claims Gabriel was in the lounge when the murder took place.");
                                    ClueAlert("Larrisa claims Gabriel was in the lounge at the time of the murder.");
                                }
                                AddAllText();
                                choiceList.Add("Why didn't you just stay with Bruce?");
                                AddChoicesForInput();
                                DrawScreen();
                                LarissaText.Add("\"Tensions were a bit high last night.\"");
                                LarissaText.Add("\"Bruce got annoyed with me. It was my fault.\"");
                                LarissaText.Add("\"Ms. Grestin was a bit nosy about our financial situation.\"");
                                LarissaText.Add("\"I overreacted. There's a rumor going around about me.\"");

                                LarissaText.Add("\"They think I got the money for being...too close to a bunch of old rich men.\"");
                                LarissaText.Add("\"I don't even know how that rumor was started.\"");
                                LarissaText.Add("\"I swear it's not true at all.\"");
                                LarissaText.Add("");
                                LarissaText.Add("\"But Ms. Grestin, she wouldn't leave it alone. She said...\"");
                                LarissaText.Add("\"She said Peter knew about me being a whore.\"");
                                LarissaText.Add("\"I don't even know why he told her that!\"");
                                LarissaText.Add("She won't say anything else");
                                //choices
                                AddAllText();
                                choiceList.Add("So how did you get the money?");
                                AddChoicesForInput();
                                DrawScreen();
                                LarissaText.Add("\"I've just been saving my money and investing wisely.\"");
                                LarissaText.Add("\"I work as an appraiser at an auction house.\"");
                                LarissaText.Add("\"My job is to tell them if things are real and what their value is.\"");
                                LarissaText.Add("\"I make a good amount of money. That's all!\"");

                                //Add another clue here!
                                if (Suspects.heardThatLarissaMadeHerMoneyAsAnAppraiser == false)
                                {
                                    Suspects.heardThatLarissaMadeHerMoneyAsAnAppraiser = true;
                                    Suspects.InterviewClueList.Add("Larissa claims she made her fortune as an auction consultant.");
                                    ClueAlert("Larrisa claims she made her money as an auction consultant.");
                                }

                                AddAllText();
                                choiceList.Add("I understand.");
                                AddChoicesForInput();
                            }
                            else
                            {//inno text
                                LarissaText.Add("\"So from 10 to 11, right?\"");
                                LarissaText.Add("\"I was in the kitchen.\"");
                                LarissaText.Add("");
                                LarissaText.Add("\"Bruce was supposed to go to work the next day.\"");
                                LarissaText.Add("\"He was going to quit his job, so I wanted to make him a special lunch.\"");
                                LarissaText.Add("\"It was going to be a surprise.\"");
                                LarissaText.Add("\"If you don't believe me, you can look in the fridge.\"");
                                LarissaText.Add("\"I made pork chops with roasted veggies. It took me a long time.\"");
                                AddAllText();
                                choiceList.Add("Why was he going to quit his job?");
                                AddChoicesForInput();
                                DrawScreen();
                                LarissaText.Add("For the first time, you see her smile.");
                                LarissaText.Add("\"He hated that job, and with my money, he wouldn't have to work there anymore.\"");
                                LarissaText.Add("\"He felt bad about leaning on me for support, but I convinced him in the end.\"");
                                LarissaText.Add("\"He was so nervous, he wouldn't even drink anything.\"");

                                if (Suspects.heardThatLarissaWasIntTheKitchen == false)
                                {
                                    Suspects.heardThatLarissaWasIntTheKitchen = true;
                                    Suspects.InterviewClueList.Add("Larissa claims that she was in the kitchen when the murder happened.");
                                    ClueAlert("Larissa claims she was making Bruce lunch in the kitchen.");
                                }
                            AddAllText();
                            choiceList.Add("Okay, I get it.");
                            }
                            break;
                    }
                    break;
                case 2://questions about relationship
                    LarissaText.Add("\"I want to know about your relationship with everyone else,\" you say.");
                    LarissaText.Add("");
                    LarissaText.Add("Larissa looks confused.");
                    LarissaText.Add("\"What's there to say?\"");
          
                    AddAllText();
                    //choices
                    choiceList.Add("\"Did you get along with Bruce's family?\"");

                    if (SearchCrimeScene.checkedTrashCan && scriptStoryTold == false)
                        choiceList.Add("CLUE: (police badge) \"Why did we find a police badge under the floorboards?\"");

                    AddChoicesForInput();
                    DrawScreen();
                    switch (playerInputToInt)
                    {
                        case 1://how did you get along with Bruce's family?
                            if (Suspects.Killer == "Larissa")
                            {
                                if (Suspects.heardThatLarissaMadeHerMoneyAsAnAppraiser)
                                {
                                    LarissaText.Add("\"You know what Ms. Grestin thinks of me.\"");
                                    LarissaText.Add("\"She thinks I got my money as an escort.\"");
                                    LarissaText.Add("\"God knows why Peter would tell her such a thing.\"");
                                    LarissaText.Add("");
                                    LarissaText.Add("\"I still wanted them to like me, however.\"");
                                    LarissaText.Add("\"His family is my family, you know?\"");
                                }
                                else
                                {
                                    LarissaText.Add("\"Ms. Grestin doesn't like me much.\"");
                                    LarissaText.Add("\"She doesn't like the fact that we were going to move away after we got married.\"");
                                    LarissaText.Add("\"I hope you can understand I didn't think it was healthy to live with your mother at age 25.\"");
                                    LarissaText.Add("\"She didn't want him to leave her.\"");

                                    if (Suspects.heardThatLarissaWasGoingToMoveToParis)
                                    {
                                        Suspects.heardThatLarissaWasGoingToMoveToParis = true;
                                        Suspects.InterviewClueList.Add("Larissa planned to move to paris with Bruce after they got married.");
                                        ClueAlert("Larissa planned to move to Paris with Bruce.");
                                    }
                                }
                            }
                            else
                            {
                                LarissaText.Add("\"His mother doesn't trust me.\"");
                                LarissaText.Add("\"After we got married, we were going to move to Paris.\"");
                                LarissaText.Add("\"I used to live there, it's really something.\"");
                                LarissaText.Add("\"Bruce was 25 and living with his mother.\"");
                                LarissaText.Add("");
                                LarissaText.Add("\"I just wanted us to be able to start over somewhere else.\"");
                                LarissaText.Add("\"But I know she really didn't like the idea of him leaving.\"");
                                LarissaText.Add("\"But you NEED to know that I loved him.\"");
                                LarissaText.Add("\"Even though we didn't get along, we all had Bruce's best interests at heart.\"");

                                if (Suspects.heardThatLarissaWasGoingToMoveToParis == false)
                                {
                                    Suspects.heardThatLarissaWasGoingToMoveToParis = true;
                                    Suspects.InterviewClueList.Add("Larissa planned to move to paris with Bruce after they got married.");
                                    ClueAlert("Larissa planned to move to Paris with Bruce.");
                                }

                            }
                            break;

                        case 2://police badge
                            LarissaText.Add("\"He did?\"");
                            LarissaText.Add("Gabriel looks surprised.");
                            LarissaText.Add("");
                            LarissaText.Add("\"I... was it any good?\"");

                            if (Suspects.Killer == "Gabriel")
                            {
                                LarissaText.Add("\"That doesn't really matter now, I guess.\"");
                                LarissaText.Add("\"You know, I did get a call from him about a week ago.\"");
                                LarissaText.Add("");
                                LarissaText.Add("\"We're both writers, you see.\"");
                                LarissaText.Add("\"Bruce was never as successful as me, but he was still pretty good.\"");
                                LarissaText.Add("\"He could never work up the nerve to ask anyone to read his writing.\"");
                                LarissaText.Add("\"Thats probably why it was in the trash.\"");
                                LarissaText.Add("");
                                LarissaText.Add("\"I guess he had some ideas about a sequal for my book.\"");
                                LarissaText.Add("\"Is there a chance I'd get to read it?\"");
                                LarissaText.Add("\"Maybe I could get it published in his honor or something.\"");
                            }
                            else
                            {
                                LarissaText.Add("\"Bruce...would probably want me to come clean about that...\"");
                                AddAllText();
                                //choices
                                choiceList.Add("Come clean about what?");
                                AddChoicesForInput();
                                DrawScreen();
                                LarissaText.Add("Gabriel leans back in his chair, and looks at the ground.");
                                LarissaText.Add("");
                                LarissaText.Add("\"We were writers, Bruce and I. He was always better than me.\"");
                                LarissaText.Add("\"When we were in college, Bruce showed me a story he had written.\"");
                                LarissaText.Add("\"It was good. Like really good.\"");
                                LarissaText.Add("\"I tried to convince him to publish it, but he was too self-concious.\"");
                                LarissaText.Add("\"He didn't think anyone would read it.\"");
                                LarissaText.Add("");
                                LarissaText.Add("\"But I sent it to a publisher. Just to get a professional opinion, you see.\"");
                                LarissaText.Add("\"The publisher loved it. Wanted to get it made into a book. An actual book!\"");
                                LarissaText.Add("\"But...the thing is...\"");
                                LarissaText.Add("\"I published it under my name.\"");
                                LarissaText.Add("\"I didn't try to steal the story from him! I just knew he didn't want his name out in the open.\"");
                                LarissaText.Add("\"I had no idea it would be so popular.\"");
                                AddAllText();
                                //choices
                                choiceList.Add("I see...");
                                AddChoicesForInput();
                                DrawScreen();
                                LarissaText.Add("Gabriel fidgets in his seat.");
                                LarissaText.Add("\"Bruce was not happy when he found out.\"");
                                LarissaText.Add("\"Even though everyone loved his book, he didn't like that I'd gone behind his back.\"");
                                LarissaText.Add("\"He didn't even want any of the money I'd made from selling the book.\"");
                                LarissaText.Add("");
                                LarissaText.Add("\"But...after a while...I guess he got tired of holding a grudge.\"");
                                LarissaText.Add("\"I had no idea he was working on a sequal.\"");
                            }
                            break;
                    }
                    AddAllText();
                    choiceList.Add("Thanks for telling me that.");
                    AddChoicesForInput();
                    break;
                case 3:
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

