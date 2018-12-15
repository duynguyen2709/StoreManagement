using StoreManagement.DAO;
using StoreManagement.Entities;
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

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for Add_Shift.xaml
    /// </summary>
    public partial class Add_Shift : Window
    {
        List<UserEntity> Cashiers;
        public Add_Shift(string Weekday,string Shift)
        {
            InitializeComponent();
            textBlock_Week.Text = (DateTime.Today.DayOfYear / 7).ToString();
            textBlock_Shift.Text = Shift;
            if (Weekday == "Mon" || Weekday == "Tues" || Weekday == "Fri" || Weekday == "Sun")
            {
                Weekday += "day";
            }
            else if (Weekday == "Thu") Weekday = "Thursday";
            else if (Weekday == "Sat") Weekday = "Saturday";
            else if (Weekday == "Wed") Weekday = "Wednesday";
            textBlock_WeekDay.Text = Weekday;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserDAO dao = new UserDAO();
            List<UserEntity> Employees = dao.getAll(typeof(UserEntity)) as List<UserEntity>;
            Cashiers= new List<UserEntity>();
            foreach(var c in Employees)
            {
                if(c.Role==1 )
                {
                    Cashiers.Add(c);
                }
            }
            comboBox.ItemsSource = Cashiers;
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            UserEntity curCashier = comboBox.SelectedItem as UserEntity;
            UserShiftEntity temp = new UserShiftEntity();
            temp.CashierID = curCashier.UserID;
            temp.Shift = int.Parse(textBlock_Shift.Text[5].ToString());
            temp.Week = DateTime.Today.DayOfYear / 7;
            temp.WeekDay = textBlock_WeekDay.Text;
            ShiftDAO dao = new ShiftDAO();
            dao.insert(temp);
            this.Close();
        }

        private void comboBox_SelectionChanged()
        {

        }
    }
}
