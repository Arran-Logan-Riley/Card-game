using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Card_Game
{
    public partial class Form1 : Form
    {
        //properties 
        List<PictureBox> cardPlacement;
        GameManager gameManager = new GameManager();
        List<PictureBox> fliptracker = new List<PictureBox>();
        List<HighScore> HighScores = new List<HighScore>();
        private int cardTimer = 0;
        private int mathcedCards = 0;
        private int timerStart = 0;
        private List<PictureBox> boxes;
        private List<Label> Labels;
        bool cardsFlipped = false;
        private int gameEnd = 12;
        private int ScoreTracker = 0; 
        public Form1()
        {
            InitializeComponent();
            this.panel1.Visible = false; //sets the state of the panels at the start 
            this.panel2.Visible = false;
            this.EndGamePanel.Visible = false;
            boxes = new List<PictureBox>() //initilising the list of cards
            
            {
                this.pictureBox1, //properties
                this.pictureBox2,
                this.pictureBox3,
                this.pictureBox4,
                this.pictureBox5,
                this.pictureBox6,
                this.pictureBox7,
                this.pictureBox8,
                this.pictureBox9,
                this.pictureBox10,
                this.pictureBox11,
                this.pictureBox12,
                this.pictureBox13,
                this.pictureBox14,
                this.pictureBox15,
                this.pictureBox16,
                this.pictureBox17,
                this.pictureBox18,
                this.pictureBox19,
                this.pictureBox20,
                this.pictureBox21,
                this.pictureBox22,
                this.pictureBox23,
                this.pictureBox24,
            };
            Labels = new List<Label>()//initlises the highscore lables 
            {
                HighScoreLB1,
                HighScoreLB2,
                HighScoreLB3,
                HighScoreLB4,
                HighScoreLB5,
                HighScoreLB6,
                HighScoreLB7,
                HighScoreLB8,
                HighScoreLB9,
                HighScoreLB10, 
            };
            LoadScores();//loads the score form the jason file 

            // countBoxes();
        }
        private void ShowScores()
        {
            //sort list
            //sorting algorithm vv sorts the list of scores 
            if(HighScores.Count != 0)
            {
                HighScores.Sort((p2, p1) =>
                {
                    return p1.Score - p2.Score;
                });
            


            if(HighScores.Count >= 10) //if its over 10 it removes the 10th object
            {
                for (int i = 10; i < HighScores.Count; i++)
                {
                    HighScores.Remove(HighScores[i]);  
                }        
            }
           
            ///
            if (HighScores.Count != 0)
            {
                for (int i = 0; i < HighScores.Count; i++)
                {
                    Labels[i].Text = HighScores[i].PlayerName + " : " + HighScores[i].Score;
                }
            }
          }
        }
        private void countBoxes()
        {
            foreach (PictureBox box in boxes)
            {
                Console.WriteLine(box.Tag);
            }
        }
        private void Label2_Click(object sender, EventArgs e)
        {

            if(Textbox.Text == "ENTER A NAME" || Textbox.Text == "")//this should work, but dosnt
            {
                MessageBox.Show(string.Format("Please enter a name"),"no");
                return;
            }
            this.panel1.Show();
            GameTimer.Enabled = true;
        }

        private void Label8_Click(object sender, EventArgs e)//sets the text box to "enter a name"
        {
            this.panel1.Visible = false;
            this.Textbox.Text = "ENTER A NAME";
        }

        private void EnterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)//if the user presses quit, it will exit the application
        {
            Application.Exit();
        }

        private void Label12_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true; //sets the visablity of panel 2 to true
        }

        private void Label14_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false; //sets the visablity of panel 2 to true
        }

        private void TextBox_Validated(object sender, EventArgs e)
        {
            // this.TextBox.Text = this.TextBox.Text.ToUpper(); //idk why this dosnt work...
        }

        private void Textbox_Click(object sender, EventArgs e) //when a user clicks the tet box the text in the text box will disapare
        {
            this.Textbox.Text = "";
        }
        /// <summary>
        /// This might be a event handler for all picture boxes when clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void PictureClick(object sender, EventArgs eventArgs)
        {


            if (!cardsFlipped)
            {
                if (fliptracker.Count == 1)
                {
                    if (fliptracker[0] == (PictureBox)sender) return; // fix double click bug
                }
                Console.WriteLine("Click me");
                //find the clicked on picture box
                PictureBox box = FindPictureBox(sender);
                //get the tag number of said box
                int card = Convert.ToInt32(box.Tag);
                //if this card isnt flipped

                //change the image of the box to the card image
                box.Image = gameManager.Deck.deck[card].getCardImage(); //ifList is more than 2 flip the cards back
                                                                        //add the box to the flip tracker                                                             //this.pictureBox1 = somehow set the flip status  
                fliptracker.Add(box);
                //set the flip status of the card to true
                gameManager.Deck.getDeck()[card].setCardFlipStatus(true);

                //if timer is enabled do nothing
                if (GameTimer.Enabled)
                {

                }
                //else start a timer
                else if (fliptracker.Count == 2)
                {
                    GameTimer.Start();
                    cardsFlipped = true;
                }

            }

        }
        private PictureBox FindPictureBox(object sender) //finds the picture box in the pciture box list
        {
            foreach (PictureBox box in boxes)
            {
                if (((PictureBox)sender) == box)
                {
                    return box;
                }
            }
            return null;
        }


        private void GameClock(object sender, EventArgs e)//game clock method that does all the matching and end game management
        {
            // int nowTime = Convert.ToInt32(timerStart);

            // nowTime++;

            if (fliptracker.Count == 2) //if the flip tracker has two objects added to it
            {
                int firstCard = Convert.ToInt32(fliptracker[0].Tag);//sets the card to the picked cards tag
                int secondCard = Convert.ToInt32(fliptracker[1].Tag);

                Card card1 = gameManager.Deck.getDeck()[firstCard]; //sets card1&2 to a vareable 
                Card card2 = gameManager.Deck.getDeck()[secondCard];
                
                if (gameManager.Deck.getDeck()[firstCard].Compare(gameManager.Deck.getDeck()[secondCard])) //uses the compare method to compare the card objects 
                {
                    Console.WriteLine("matched!");//writes in the console if they are matching 
                    ScoreTracker++;//addes to the players score
                    label17.Text = (ScoreTracker.ToString()); 
                    fliptracker[0].Visible = false; //if the cards are equil set the cards to invisable  
                    fliptracker[1].Visible = false;
                    gameEnd--;
                    if (gameEnd == 0) //end game statement vv
                    {
                        this.panel1.Visible = false; //this should work, but dosn't for some reasin. 
                        Console.WriteLine(EndGamePanel.Visible);//console logs if it works
                        ScoreTracker--; 
                        
                        MessageBox.Show(string.Format("Your score is {0} ", ScoreTracker),"Game over");//end game message box

                        HighScore score = new HighScore(ScoreTracker, Textbox.Text);//pushes ScoreTracker and the text output of the user to a list
                        HighScores.Add(score); //adds score to the highscore list
                        SaveScores();//Saves the score to the jason file 
                        ShowScores();//shows the score from the jason file 
                        Application.Exit(); //closes the application 
                    }
                }
                else//if not matched it sets the card back to their cover status 
                {
                    fliptracker[0].Image = Properties.Resources.cover;
                    fliptracker[1].Image = Properties.Resources.cover;
                    ScoreTracker--; 
                    label17.Text=(ScoreTracker.ToString()); 
                }
                // nowTime = 2;
                card1.setCardFlipStatus(false);//aceeses the tags set in the cards and sets the flipstatus of them back to false
                card2.setCardFlipStatus(false);
                fliptracker.Remove(fliptracker[1]); //when an item is deleted out of an array it bumps the last one to the front, making vv 0
                fliptracker.Remove(fliptracker[0]);


            }
            GameTimer.Stop();//stops the timer 
            cardsFlipped = false;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EndGameClick1(object sender, EventArgs e)
        {
            this.EndGamePanel.Visible = false; //sets the game panel endgame to invisable(not currently functinal)
        }

        public void SaveScores()//save score to the jason method 
        {
            for (int i = HighScores.Count - 1; i > 10; i--)
            {
                HighScores.RemoveAt(i);
            }
            StreamWriter writer = new StreamWriter("save.json");
            string data = JsonConvert.SerializeObject(HighScores);
            writer.Write(data);//writes the data 
            writer.Close();//closes the writeer 
        }
        public void LoadScores()//loads the score from the jason file 
        {
            try
            {
                using (StreamReader reader = new StreamReader("save.json"))//reading the data from the jason file 
                {
                    string data = reader.ReadToEnd();
                    Console.WriteLine(data);
                    HighScores = Deserialize<HighScore>(data);
                    reader.Close();//closes the reader 
                }
                ShowScores();//show score method 
            }
            catch (Exception e)
            {
                HighScores = new List<HighScore>();
                Console.WriteLine(e.Message);
            }
            
        }
        public List<T> Deserialize<T>(string path)//turning an object into a string 
        {
            return JsonConvert.DeserializeObject<List<T>>(path);
        }

        private void Label9_Click(object sender, EventArgs e)//restart function
        {
            this.boxes.ForEach((box) => //this function goes through all the cards and sets it to cover &visibility 
            {
                box.Image= Properties.Resources.cover;
                box.Visible = true;
                ScoreTracker = 0;
                gameManager.Deck = new Deck();
                fliptracker = new List<PictureBox>();
                this.label17.Text = "0"; 
            });
        }
    }
}
