using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.EntityFrameworkCore;
using YP021.Classes;
using YP021.Elements;
using YP021.Models;

namespace YP021.Pages
{
    public partial class EditStudent : Page
    {
        private Students _student;
        private DatabaseContext _context = new DatabaseContext();

        public EditStudent(Students student, DatabaseContext context)
        {
            InitializeComponent();
            _student = student;
            _context = context;
            surnameTextBox.Text = student.surname;
            nameTextBox.Text = student.name;
            lastnameTextBox.Text = student.lastname;
            foreach(StudGroups group in _context.StudGroups)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = group.name;
                item.Tag = group.id;
                groupTextBox.Items.Add(item);
                if(group.id == student.studGroupId)
                {
                    item.IsSelected = true;
                }
            }

            dateOfRemandPicker.SelectedDate = student.dateOfRemand;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Students student = _context.Students.FirstOrDefault(x => x.id == _student.id);
            student.surname = surnameTextBox.Text;
            student.name = nameTextBox.Text;
            student.lastname = lastnameTextBox.Text;
            student.studGroupId = (int)(groupTextBox.SelectedItem as ComboBoxItem).Tag;
            student.dateOfRemand = dateOfRemandPicker.SelectedDate ?? DateTime.MinValue;
            _context.SaveChanges();
            MessageBox.Show("Изменения сохранены");
            NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
