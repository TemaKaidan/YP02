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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YP021.Classes;

namespace YP021.Pages
{
    /// <summary>
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : Page
    {
        private static Main _instance;

        private DatabaseContext databaseContext;

        private bool isMenuCollapsed = false;

        public static Main Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Main();
                }
                return _instance;
            }
        }

        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation();

            if (isMenuCollapsed)
            {
                widthAnimation.From = 50;
                widthAnimation.To = 200;
                MenuPanel.Width = 200;
                foreach (UIElement element in MenuPanel.Children)
                {
                    if (element is Button btn && btn.Content.ToString() != "☰")
                    {
                        btn.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                widthAnimation.From = 200;
                widthAnimation.To = 50;
                foreach (UIElement element in MenuPanel.Children)
                {
                    if (element is Button btn && btn.Content.ToString() != "☰")
                    {
                        btn.Visibility = Visibility.Collapsed;
                    }
                }
            }

            widthAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
            MenuPanel.BeginAnimation(WidthProperty, widthAnimation);
            isMenuCollapsed = !isMenuCollapsed;
        }
        public Student()
        {
            InitializeComponent();
            databaseContext = new DatabaseContext();
            CreateUI();


        }

        private void CreateUI()
        {
            // Загружаем список всех групп, чтобы использовать его при создании студентов
            var groups = databaseContext.StudGroups.ToList();

            foreach (var x in databaseContext.Students.ToList())
            {
                parrent.Children.Add(new Elements.Student(x)); // Передаем студента и список групп
            }
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {

        }
    }
}
