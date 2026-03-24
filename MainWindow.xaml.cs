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

        int score = 0; // ✅ score start op 0

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

                // ✅ voorkom negatieve uitkomst
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

                // ✅ voorkom delen door 0
                while (getal2 == 0)
                {
                    getal2 = random.Next(1, 11);
                }

                // ✅ zorg dat uitkomst geen decimal is
                getal1 = getal1 * getal2;
            }

            sum.Text = getal1 + " " + math + " " + getal2;

            // reset kleur
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
                    score++; // ✅ +1 bij goed antwoord
                    scoreText.Text = "Score: " + score;

                    // ✅ groen bij goed
                    this.Background = Brushes.LightGreen;
                }
                else
                {
                    // ❌ rood bij fout
                    this.Background = Brushes.IndianRed;
                }
            }
        }
    }
}