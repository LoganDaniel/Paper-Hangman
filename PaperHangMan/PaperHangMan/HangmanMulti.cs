using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Text;
using Android.Text;

namespace PaperHangMan
{
    [Activity(Label = "HangmanMulti", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HangmanMulti : Activity
    {
        Typeface tf = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/orangeJuice.ttf");

        AlertDialog alertDialog;

        string word;                // The word the player has to guess
        int hanglives = 1;          // When hanglives = 9 Then player loses!
        int lettersGuessedRight;    // When lettersGuessRight = Word.Length then Player wins!

        Button btnLetterA;
        Button btnLetterB;
        Button btnLetterC;
        Button btnLetterD;
        Button btnLetterE;
        Button btnLetterF;
        Button btnLetterG;
        Button btnLetterH;
        Button btnLetterI;
        Button btnLetterJ;
        Button btnLetterK;
        Button btnLetterL;
        Button btnLetterM;
        Button btnLetterN;
        Button btnLetterO;
        Button btnLetterP;
        Button btnLetterQ;
        Button btnLetterR;
        Button btnLetterS;
        Button btnLetterT;
        Button btnLetterU;
        Button btnLetterV;
        Button btnLetterW;
        Button btnLetterX;
        Button btnLetterY;
        Button btnLetterZ;

        ImageView imgHanging;
        LinearLayout linearWordAnswer;
        TextView lblWord;
        TextView lblScore;
        List<TextView> lblWordArrayList = new List<TextView>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HangmanGame);

            //lblScore.Visibility = ViewStates.Invisible;

            btnLetterA = FindViewById<Button>(Resource.Id.btnLetterA);
            btnLetterB = FindViewById<Button>(Resource.Id.btnLetterB);
            btnLetterC = FindViewById<Button>(Resource.Id.btnLetterC);
            btnLetterD = FindViewById<Button>(Resource.Id.btnLetterD);
            btnLetterE = FindViewById<Button>(Resource.Id.btnLetterE);
            btnLetterF = FindViewById<Button>(Resource.Id.btnLetterF);
            btnLetterG = FindViewById<Button>(Resource.Id.btnLetterG);
            btnLetterH = FindViewById<Button>(Resource.Id.btnLetterH);
            btnLetterI = FindViewById<Button>(Resource.Id.btnLetterI);
            btnLetterJ = FindViewById<Button>(Resource.Id.btnLetterJ);
            btnLetterK = FindViewById<Button>(Resource.Id.btnLetterK);
            btnLetterL = FindViewById<Button>(Resource.Id.btnLetterL);
            btnLetterM = FindViewById<Button>(Resource.Id.btnLetterM);
            btnLetterN = FindViewById<Button>(Resource.Id.btnLetterN);
            btnLetterO = FindViewById<Button>(Resource.Id.btnLetterO);
            btnLetterP = FindViewById<Button>(Resource.Id.btnLetterP);
            btnLetterQ = FindViewById<Button>(Resource.Id.btnLetterQ);
            btnLetterR = FindViewById<Button>(Resource.Id.btnLetterR);
            btnLetterS = FindViewById<Button>(Resource.Id.btnLetterS);
            btnLetterT = FindViewById<Button>(Resource.Id.btnLetterT);
            btnLetterU = FindViewById<Button>(Resource.Id.btnLetterU);
            btnLetterV = FindViewById<Button>(Resource.Id.btnLetterV);
            btnLetterW = FindViewById<Button>(Resource.Id.btnLetterW);
            btnLetterX = FindViewById<Button>(Resource.Id.btnLetterX);
            btnLetterY = FindViewById<Button>(Resource.Id.btnLetterY);
            btnLetterZ = FindViewById<Button>(Resource.Id.btnLetterZ);

            imgHanging = FindViewById<ImageView>(Resource.Id.imageView1);
            lblScore = FindViewById<TextView>(Resource.Id.lblScore);
            linearWordAnswer = FindViewById<LinearLayout>(Resource.Id.linearLayoutWord);

            //Adding custom font
            //lblScore.SetTypeface(tf, TypefaceStyle.Normal);
            lblScore.SetTextColor(Color.Transparent);

            //Textview Settings that we must define in the code as the Textview is created through the  code
            linearWordAnswer.SetBackgroundColor(Color.Transparent);
            linearWordAnswer.Orientation = Orientation.Horizontal;
            linearWordAnswer.SetPadding(10, 10, 10, 10);

            SelectWord();

            btnLetterA.Click += btnLetter_Click;
            btnLetterB.Click += btnLetter_Click;
            btnLetterC.Click += btnLetter_Click;
            btnLetterD.Click += btnLetter_Click;
            btnLetterE.Click += btnLetter_Click;
            btnLetterF.Click += btnLetter_Click;
            btnLetterG.Click += btnLetter_Click;
            btnLetterH.Click += btnLetter_Click;
            btnLetterI.Click += btnLetter_Click;
            btnLetterJ.Click += btnLetter_Click;
            btnLetterK.Click += btnLetter_Click;
            btnLetterL.Click += btnLetter_Click;
            btnLetterM.Click += btnLetter_Click;
            btnLetterN.Click += btnLetter_Click;
            btnLetterO.Click += btnLetter_Click;
            btnLetterP.Click += btnLetter_Click;
            btnLetterQ.Click += btnLetter_Click;
            btnLetterR.Click += btnLetter_Click;
            btnLetterS.Click += btnLetter_Click;
            btnLetterT.Click += btnLetter_Click;
            btnLetterU.Click += btnLetter_Click;
            btnLetterV.Click += btnLetter_Click;
            btnLetterW.Click += btnLetter_Click;
            btnLetterX.Click += btnLetter_Click;
            btnLetterY.Click += btnLetter_Click;
            btnLetterZ.Click += btnLetter_Click;
        }

        private void btnLetter_Click(object sender, EventArgs e)
        {
            string LetterButton = (sender as Button).Text;
            Button btnLetter = (sender as Button);
            if (word.Contains(LetterButton))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    string letter = word[i].ToString();

                    if (letter == LetterButton)
                    {       //Run this if the player guessed correctly
                        UpdateLetter(i, LetterButton);
                        continue;       //Continues the for loop
                    }
                }
            }
            else
            {
                //Run this if the player guessed incorrectly
                //Toast.MakeText(this, word, ToastLength.Short).Show();
                // Player loses one chance per incorrect guess
                hanglives = hanglives + 1;
                if (hanglives == 2)
                {
                    imgHanging.SetImageResource(Resource.Drawable.Hangman_2);
                }
                else if (hanglives == 3)
                {
                    imgHanging.SetImageResource(Resource.Drawable.Hangman_3);
                }
                else if (hanglives == 4)
                {
                    imgHanging.SetImageResource(Resource.Drawable.Hangman_4);
                }
                else if (hanglives == 5)
                {
                    imgHanging.SetImageResource(Resource.Drawable.Hangman_5);
                }
                else if (hanglives == 6)
                {
                    imgHanging.SetImageResource(Resource.Drawable.Hangman_6);
                }
                else if (hanglives == 7)
                {
                    imgHanging.SetImageResource(Resource.Drawable.Hangman_7);
                }
                else if (hanglives == 8)
                {
                    imgHanging.SetImageResource(Resource.Drawable.Hangman_8);
                }
                else if (hanglives == 9)
                {
                    imgHanging.SetImageResource(Resource.Drawable.Hangman_9);
                }
                HasPlayerLost();
            }
            btnLetter.Enabled = false;
            btnLetter.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }

        public void UpdateLetter(int letterIndex, string letterChar)
        {
            lblWordArrayList[letterIndex].Text = letterChar;
            HasPlayerWon();

        }
        public void HasPlayerWon()
        {
            lettersGuessedRight = lettersGuessedRight + 1;

            if (lettersGuessedRight == word.Length)
            {
                OpenPromtTryAgain();
                //Toast.MakeText(this, "Player has won", ToastLength.Short).Show();
            }
        }

        public void HasPlayerLost()
        {
            if (hanglives == 9)
            {
                OpenPromtTryAgain();
                //Toast.MakeText(this, "The player has lost", ToastLength.Short).Show();
            }
        }

        public void OpenPromtTryAgain()
        {
            alertDialog = new AlertDialog.Builder(this).Create();
            alertDialog.SetTitle("Want to play again?");
            alertDialog.SetButton("Play again", (s, ev) =>
            {
                Finish();
                StartActivity(typeof(HangmanMulti));
            });
            alertDialog.SetButton2("Main Menu", (s, ev) =>
            {
                Finish();
            });

            alertDialog.SetCancelable(false);

            alertDialog.Show();
        }
        public void SelectWord()
        {
            alertDialog = new AlertDialog.Builder(this).Create();
            EditText txtEntrName = new EditText(this);
            txtEntrName.SetHint(Resource.String.SelectWord);

            txtEntrName.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(10) });
            
            alertDialog.SetTitle("Select a word");
            alertDialog.SetMessage("Letters only. Numbers, symbols and spaces are invalid");      
            alertDialog.SetView(txtEntrName);
            alertDialog.SetButton("Play", (s, ev) =>
            {
                word = txtEntrName.Text;
                word = word.ToUpper();
                var answerLetters = word.ToCharArray();

                if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                {
                    //Set the word display to blanks for word.length
                    for (int i = 0; i < word.Length; i++)
                    {
                        // Create new Textview for each letter
                        lblWord = new TextView(this);
                        lblWordArrayList.Add(lblWord);
                        lblWord.Text = "_";
                        lblWord.Id = i;
                        lblWord.SetTypeface(tf, TypefaceStyle.Normal);
                        lblWord.SetPadding(15, 5, 15, 5);
                        lblWord.SetTextColor(Color.Black);
                        lblWord.TextSize = 25;

                        linearWordAnswer.AddView(lblWord);
                    }
                    lblWordArrayList.ToArray();
                    alertDialog.Cancel();
                }
                else
                {
                    InvalidWord(word);
                }
            });
            alertDialog.SetButton2("Main Menu", (s, ev) =>
            {
                Finish();
            });
            alertDialog.SetCancelable(false);
            alertDialog.Show();
        }

        public void InvalidWord(string wordtext)
        {
            alertDialog = new AlertDialog.Builder(this).Create();
            EditText txtEntrName = new EditText(this);
            txtEntrName.Text = wordtext;
            txtEntrName.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(10) });

            alertDialog.SetTitle("Invalid characters. Letters only");
            alertDialog.SetMessage("Letters only. Numbers, symbols and spaces are invalid");
            alertDialog.SetView(txtEntrName);
            alertDialog.SetButton("Play", (s, ev) =>
            {
                word = txtEntrName.Text;
                word = word.ToUpper();
                var answerLetters = word.ToCharArray();

                if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                {
                    //Set the word display to blanks for word.length
                    for (int i = 0; i < word.Length; i++)
                    {
                        // Create new Textview for each letter
                        lblWord = new TextView(this);
                        lblWordArrayList.Add(lblWord);
                        lblWord.Text = "_";
                        lblWord.Id = i;
                        lblWord.SetTypeface(tf, TypefaceStyle.Normal);
                        lblWord.SetPadding(15, 5, 15, 5);
                        lblWord.SetTextColor(Color.Black);
                        lblWord.TextSize = 25;

                        linearWordAnswer.AddView(lblWord);
                    }
                    lblWordArrayList.ToArray();
                    alertDialog.Cancel();
                }
                else
                {
                    InvalidWord(word);
                }
            });
            alertDialog.SetButton2("Main Menu", (s, ev) =>
            {
                Finish();
            });

            alertDialog.SetCancelable(false);

            alertDialog.Show();
        }

        public override void OnBackPressed()
        {
            AlertDialog BackQuitDialog = new AlertDialog.Builder(this).Create();
            BackQuitDialog.SetTitle("Are you sure you want to quit");
            BackQuitDialog.SetButton("Quit", (s, ev) =>
            {
                Finish();
            });
            BackQuitDialog.SetButton2("Return", (s, ev) =>
            {
                BackQuitDialog.Cancel();
            });

            if (BackQuitDialog != null)
            {
                if (BackQuitDialog.IsShowing)
                {
                    BackQuitDialog.Cancel();
                }
                else
                {
                    BackQuitDialog.Show();
                }
            }
            else
            {
                BackQuitDialog.Show();
            }
        }
    }
}