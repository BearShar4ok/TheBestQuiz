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

namespace TheBestQuiz
{
    /// <summary>
    /// Логика взаимодействия для ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        private MainWindow mainWindow;
        public ApplicationDbContext db;

        public ListWindow(MainWindow mainWindow, ApplicationDbContext db)
        {
            InitializeComponent();
            this.db = db;

            Theme_Button1.Content = db.Theme.First(x => x.Id == 1).Name;
            Theme_Button2.Content = db.Theme.First(x => x.Id == 2).Name;
            Theme_Button3.Content = db.Theme.First(x => x.Id == 3).Name;
            Theme_Button4.Content = db.Theme.First(x => x.Id == 4).Name;
            Theme_Button5.Content = db.Theme.First(x => x.Id == 5).Name;
            this.mainWindow = mainWindow;
        }

        private void Theme_Button1_Click(object sender, RoutedEventArgs e)
        {
            QuestionWindow questionWindow = new QuestionWindow(this, 1, db);
            questionWindow.Show();
        }

        private void Theme_Button2_Click(object sender, RoutedEventArgs e)
        {
            QuestionWindow questionWindow = new QuestionWindow(this, 2, db);
            questionWindow.Show();
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
