using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using YP021.Classes;
using YP021.Models;
using YP021.Pages;

namespace YP021.Elements
{
    public partial class Student : UserControl
    {
        private Students _student;
        private readonly DatabaseContext _context = new DatabaseContext();

        public Student(Students student)
        {
            InitializeComponent();
            _student = student;
            surname.Content = "Фамилия: " + student.surname;
            name.Content = "Имя: " + student.name;
            lastname.Content = "Отчество: " + student.lastname;

            DatabaseContext dbc = new DatabaseContext();
            var group = dbc.StudGroups.FirstOrDefault(g => g.id == student.studGroupId);
            studentGroupId.Content = "Группа: " + (group != null ? group.name : "Неизвестно");
            dateOfRemand.Content = "Дата отчисления: " + student.dateOfRemand;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this)?.Navigate(new EditStudent(_student, _context));
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить студента?", "Подтверждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _context.Students.Remove(_student);
                _context.SaveChanges();
                ((Panel)Parent)?.Children.Remove(this);
            }
        }
    }
}