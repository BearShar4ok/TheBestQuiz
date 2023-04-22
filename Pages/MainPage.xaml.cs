﻿using System;
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
    }
}