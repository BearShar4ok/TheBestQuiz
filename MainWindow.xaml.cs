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

namespace TheBestQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationDbContext? db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            ListWindow listWindow = new ListWindow(this, db);
            listWindow.Show();
        }
    }
}
