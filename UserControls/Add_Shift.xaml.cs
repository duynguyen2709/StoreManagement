using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Windows;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for Add_Shift.xaml
    /// </summary>
    public partial class Add_Shift : Window
    {
        public Add_Shift(string Weekday, string Shift)
        {
            InitializeComponent();
            textBlock_Week.Text = (DateTime.Today.DayOfYear / 7).ToString();
            textBlock_Shift.Text = Shift;
            if (Weekday == "Mon" || Weekday == "Tues" || Weekday == "Fri" || Weekday == "Sun")
            {
                Weekday += "day";
            }
            else if (Weekday == "Thu")
            {
                Weekday = "Thursday";
            }
            else if (Weekday == "Sat")
            {
                Weekday = "Saturday";
            }
            else if (Weekday == "Wed")
            {
                Weekday = "Wednesday";
            }

            textBlock_WeekDay.Text = Weekday;
        }

        private List<UserEntity> Cashiers;

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            UserEntity curCashier = comboBox.SelectedItem as UserEntity;
            UserShiftEntity temp = new UserShiftEntity
            {
                CashierID = curCashier.UserID,
                Shift = int.Parse(textBlock_Shift.Text[5].ToString()),
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = textBlock_WeekDay.Text
            };
            ShiftDAO dao = new ShiftDAO();
            dao.insert(temp);

            Manage_Shift_Admin.isUpdate = true;

            Close();
        }

        private void comboBox_SelectionChanged()
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserDAO dao = new UserDAO();
            List<UserEntity> Employees = dao.getAll(typeof(UserEntity)) as List<UserEntity>;
            Cashiers = new List<UserEntity>();

            foreach (UserEntity c in Employees)
            {
                if (c.Role == 1)
                {
                    Cashiers.Add(c);
                }
            }
            comboBox.ItemsSource = Cashiers;
        }
    }
}