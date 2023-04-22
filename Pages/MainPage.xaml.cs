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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheBestQuiz.Additions;
using TheBestQuiz.Pages;

namespace TheBestQuiz
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ApplicationDbContext db;
        public MainPage(ApplicationDbContext db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            Addition.NavigateService?.Navigate(new RegisterPage(db));
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string pass = Shifr.SHA(PasswordBox.Password);

            var user = db.Users.FirstOrDefault(x => Shifr.DeShifrMy(x.Login) == login && x.Password == pass);

            if (user != null)
            {
                Addition.NavigateService?.Navigate(new ListPage(db));
            }
        }
    }
}
