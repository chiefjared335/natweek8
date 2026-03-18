using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace natopdrachtweek8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
        public partial class MainWindow : Window
        {
            Random random = new Random();

            int getal1;
            int getal2;
            string math;

        public MainWindow()
        {
            InitializeComponent();
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
                }
                else if (choice == 3)
                {
                    math = "*";
                }
                else if (choice == 4)
                {
                    math = "/";
                }

                sum.Text = getal1 + " " + math + " " + getal2;
            }

            private void newMathButton_Click(object sender, RoutedEventArgs e)
            {
               makeNewMath();
            }

        private void checkAnswerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }