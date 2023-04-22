using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheBestQuiz.Models;

namespace TheBestQuiz
{
    /// <summary>
    /// Логика взаимодействия для QuizWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        private ListWindow listWindow;
        public ApplicationDbContext db;
        public int qCounter = 1;
        public List<bool> answers = new List<bool>();
        public List<Quiz> questions;

        public QuestionWindow(ListWindow listWindow, int id, ApplicationDbContext db)
        {           
            InitializeComponent();
            this.db = db;

            this.listWindow = listWindow;

            questions = db.Quiz.Where(x => x.ThemeId == id).ToList();
            ShowQuestion();
        }

        private void Yes_Button_Click(object sender, RoutedEventArgs e)
        {
            if (qCounter != questions.Count)
            {
                qCounter++;

                answers.Add(true);
                ShowQuestion();
            }
            else
            {
                // window closes
                answers.Add(true);
                this.Close();
            }          
        }

        private void No_Button_Click(object sender, RoutedEventArgs e)
        {
            if (qCounter != questions.Count)
            {
                qCounter++;

                answers.Add(false);
                ShowQuestion();
            }
            else
            {
                // window closes
                answers.Add(false);
                this.Close();
            }
        }

        public void ShowQuestion()
        {
            QuestionNum_TextBlock.Text = "Question " + qCounter;
            QuestionText_TextBlock.Text = questions[qCounter - 1].Question;
        }

        private void Info_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Info");
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Settings");
        }
    }
}
