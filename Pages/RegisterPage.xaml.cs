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
using TheBestQuiz.Models;

namespace TheBestQuiz
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        ApplicationDbContext db;
        public RegisterPage(ApplicationDbContext db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string pass = PassBox.Password.Trim();
            string repeatPass = RepeatPassBox.Password.Trim();

            if (login.Length < 1)
            {
                LoginTextBox.ToolTip = "ле, поле не может быть пустым";
                LoginTextBox.Background = Brushes.LightPink;
            } 
            else if (pass.Length < 5)
            {
                PassBox.ToolTip = "ле, пароль маленький";
                PassBox.Background = Brushes.LightPink;
            }
            else if (pass != repeatPass)
            {
                RepeatPassBox.ToolTip = "ле, пароли не совпадают, чорт";
                RepeatPassBox.Background = Brushes.LightPink;
            }
            else
            {
                LoginTextBox.ToolTip = "";
                LoginTextBox.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                RepeatPassBox.ToolTip = "";
                RepeatPassBox.Background = Brushes.Transparent;

                RegisterUser(login, pass);

                Addition.NavigateService?.Navigate(new MainPage(db));
            }
        }

        private void RegisterUser(string login, string password)
        {
            User user = new User();
            user.Login = Shifr.ShifrMy(login); 
            user.Password = Shifr.SHA(password);

            db.Users.Add(user);

            db.SaveChanges();
        }
    }
}
