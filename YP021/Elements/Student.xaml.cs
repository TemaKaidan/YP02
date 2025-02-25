using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
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
using YP021.Classes;
using YP021.Models;
using YP021.Pages;

namespace YP021.Elements
{
    /// <summary>
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : UserControl
    {
        public Student(Students student, List<StudGroups> groups)
        {
            InitializeComponent();

            surname.Content = "Фамилия: " + student.surname;
            name.Content = "Имя: " + student.name;
            lastname.Content = "Отчество: " + student.lastname;
            
            var group = groups.FirstOrDefault(g => g.id == student.studGroupId);
            studentGroupId.Content = "Группа: " + (group != null ? group.name : "Неизвестно");

            dateOfRemand.Content = "Дата отчисления: " + student.dateOfRemand.ToShortDateString();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}