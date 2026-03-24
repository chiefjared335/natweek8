using System;
using System.Windows;
using System.Windows.Media;

namespace natopdrachtweek8
{
    public partial class MainWindow : Window
    {
        Random random = new Random();

        int getal1;
        int getal2;
        string math;

        int score = 0; 

        public MainWindow()
        {
            InitializeComponent();
            scoreText.Text = "Score: 0";
        }

        void makeNewMath()
        {
            getal1 = random.Next(0, 11);
            getal2 = random.Next(0, 11);

            int choice = random.Next(1, 5);

            if (choice == 1)
            {
                math = "+";
            }
            else if (choice == 2)
            {
                math = "-";


                if (getal1 < getal2)
                {
                    int temp = getal1;
                    getal1 = getal2;
                    getal2 = temp;
                }
            }
            else if (choice == 3)
            {
                math = "*";
            }
            else
            {
                math = "/";


                while (getal2 == 0)
                {
                    getal2 = random.Next(1, 11);
                }


                getal1 = getal1 * getal2;
            }

            sum.Text = getal1 + " " + math + " " + getal2;


            this.Background = Brushes.White;
        }


        private void newMathButton_Click(object sender, RoutedEventArgs e)
        {
            makeNewMath();
        }

        private void checkAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            double correctAnswer = 0;

            if (math == "+")
            {
                correctAnswer = getal1 + getal2;
            }
            else if (math == "-")
            {
                correctAnswer = getal1 - getal2;
            }
            else if (math == "*")
            {
                correctAnswer = getal1 * getal2;
            }
            else if (math == "/")
            {
                correctAnswer = (double)getal1 / getal2;
            }

            double userAnswer;

            if (double.TryParse(answerTextBox.Text, out userAnswer))
            {
                if (userAnswer == correctAnswer)
                {
                    score++; 
                    scoreText.Text = "Score: " + score;

                    
                    this.Background = Brushes.LightGreen;
                }
                else
                {
                    
                    this.Background = Brushes.IndianRed;
                }
            }
        }
    }
}