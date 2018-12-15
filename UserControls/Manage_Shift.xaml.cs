using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for Manage_Shift.xaml
    /// </summary>
    public partial class Manage_Shift : UserControl
    {
        public Manage_Shift()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void Load_Table(List<ShiftTime> data)
        {
            if (data[12].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[12].WeekDay,
                    Shift = data[12].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift1_Sun_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift1_Sun.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift1_Sun.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift1_Sun_check.Visibility = Visibility.Visible;
                    Shift1_Sun_check.IsChecked = true;
                }
            }
            else
            {
                Shift1_Sun_check.Visibility = Visibility.Visible;
                Shift1_Sun.Visibility = Visibility.Hidden;
            }

            if (data[13].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[13].WeekDay,
                    Shift = data[13].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift2_Sun_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift2_Sun.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift2_Sun.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift2_Sun_check.Visibility = Visibility.Visible;
                    Shift2_Sun_check.IsChecked = true;
                    Shift2_Sun.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift2_Sun_check.Visibility = Visibility.Visible;
                Shift2_Sun.Visibility = Visibility.Hidden;
            }
            if (data[14].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[14].WeekDay,
                    Shift = data[14].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift3_Sun_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift3_Sun.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift3_Sun.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift3_Sun_check.Visibility = Visibility.Visible;
                    Shift3_Sun_check.IsChecked = true;
                    Shift3_Sun.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift3_Sun_check.Visibility = Visibility.Visible;
                Shift3_Sun.Visibility = Visibility.Hidden;
            }
            if (data[15].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[15].WeekDay,
                    Shift = data[15].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift4_Sun_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift4_Sun.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift4_Sun.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift4_Sun_check.Visibility = Visibility.Visible;
                    Shift4_Sun_check.IsChecked = true;
                    Shift4_Sun.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift4_Sun_check.Visibility = Visibility.Visible;
                Shift4_Sun.Visibility = Visibility.Hidden;
            }
            if (data[4].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[4].WeekDay,
                    Shift = data[4].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift1_Mon_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift1_Mon.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift1_Mon.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift1_Mon_check.Visibility = Visibility.Visible;
                    Shift1_Mon_check.IsChecked = true;
                    Shift1_Mon.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift1_Mon_check.Visibility = Visibility.Visible;
                Shift1_Mon.Visibility = Visibility.Hidden;
            }
            if (data[5].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[5].WeekDay,
                    Shift = data[5].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift2_Mon_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift2_Mon.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift2_Mon.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift2_Mon_check.Visibility = Visibility.Visible;
                    Shift2_Mon_check.IsChecked = true;
                    Shift2_Mon.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift2_Mon_check.Visibility = Visibility.Visible;
                Shift2_Mon.Visibility = Visibility.Hidden;
            }
            if (data[6].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[6].WeekDay,
                    Shift = data[6].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift3_Mon_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift3_Mon.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift3_Mon.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift3_Mon_check.Visibility = Visibility.Visible;
                    Shift3_Mon_check.IsChecked = true;
                    Shift3_Mon.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift3_Mon_check.Visibility = Visibility.Visible;
                Shift3_Mon.Visibility = Visibility.Hidden;
            }
            if (data[7].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[7].WeekDay,
                    Shift = data[7].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift4_Mon_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift4_Mon.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift4_Mon.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift4_Mon_check.Visibility = Visibility.Visible;
                    Shift4_Mon_check.IsChecked = true;
                    Shift4_Mon.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift4_Mon_check.Visibility = Visibility.Visible;
                Shift4_Mon.Visibility = Visibility.Hidden;
            }
            if (data[20].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[20].WeekDay,
                    Shift = data[20].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift1_Tues_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift1_Tues.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift1_Tues.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift1_Tues_check.Visibility = Visibility.Visible;
                    Shift1_Tues_check.IsChecked = true;
                    Shift1_Tues.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift1_Tues_check.Visibility = Visibility.Visible;
                Shift1_Tues.Visibility = Visibility.Hidden;
            }
            if (data[21].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[21].WeekDay,
                    Shift = data[21].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift2_Tues_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift2_Tues.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift2_Tues.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift2_Tues_check.Visibility = Visibility.Visible;
                    Shift2_Tues_check.IsChecked = true;
                    Shift2_Tues.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift2_Tues_check.Visibility = Visibility.Visible;
                Shift2_Tues.Visibility = Visibility.Hidden;
            }
            if (data[22].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[22].WeekDay,
                    Shift = data[22].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift3_Tues_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift3_Tues.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift3_Tues.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift3_Tues_check.Visibility = Visibility.Visible;
                    Shift3_Tues_check.IsChecked = true;
                    Shift3_Tues.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift3_Tues_check.Visibility = Visibility.Visible;
                Shift3_Tues.Visibility = Visibility.Hidden;
            }
            if (data[23].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[23].WeekDay,
                    Shift = data[23].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift4_Tues_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift4_Tues.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift4_Tues.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift4_Tues_check.Visibility = Visibility.Visible;
                    Shift4_Tues_check.IsChecked = true;
                    Shift4_Tues.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift4_Tues_check.Visibility = Visibility.Visible;
                Shift4_Tues.Visibility = Visibility.Hidden;
            }
            if (data[24].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[24].WeekDay,
                    Shift = data[24].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift1_Wed_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift1_Wed.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift1_Wed.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift1_Wed_check.Visibility = Visibility.Visible;
                    Shift1_Wed_check.IsChecked = true;
                    Shift1_Wed.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift1_Wed_check.Visibility = Visibility.Visible;
                Shift1_Wed.Visibility = Visibility.Hidden;
            }
            if (data[25].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[25].WeekDay,
                    Shift = data[25].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift2_Wed_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift2_Wed.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift2_Wed.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift2_Wed_check.Visibility = Visibility.Visible;
                    Shift2_Wed_check.IsChecked = true;
                    Shift2_Wed.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift2_Wed_check.Visibility = Visibility.Visible;
                Shift2_Wed.Visibility = Visibility.Hidden;
            }
            if (data[26].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[26].WeekDay,
                    Shift = data[26].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift3_Wed_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift3_Wed.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift3_Wed.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift3_Wed_check.Visibility = Visibility.Visible;
                    Shift3_Wed_check.IsChecked = true;
                    Shift3_Wed.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift3_Wed_check.Visibility = Visibility.Visible;
                Shift3_Wed.Visibility = Visibility.Hidden;
            }
            if (data[27].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[27].WeekDay,
                    Shift = data[27].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift4_Wed_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift4_Wed.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift4_Wed.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift4_Wed_check.Visibility = Visibility.Visible;
                    Shift4_Wed_check.IsChecked = true;
                    Shift4_Wed.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift4_Wed_check.Visibility = Visibility.Visible;
                Shift4_Wed.Visibility = Visibility.Hidden;
            }
            if (data[16].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[16].WeekDay,
                    Shift = data[16].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift1_Thu_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift1_Thu.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift1_Thu.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift1_Thu_check.Visibility = Visibility.Visible;
                    Shift1_Thu_check.IsChecked = true;
                    Shift1_Thu.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift1_Thu_check.Visibility = Visibility.Visible;
                Shift1_Thu.Visibility = Visibility.Hidden;
            }
            if (data[17].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[17].WeekDay,
                    Shift = data[17].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift2_Thu_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift2_Thu.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift2_Thu.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift2_Thu_check.Visibility = Visibility.Visible;
                    Shift2_Thu_check.IsChecked = true;
                    Shift2_Thu.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift2_Thu_check.Visibility = Visibility.Visible;
                Shift2_Thu.Visibility = Visibility.Hidden;
            }
            if (data[18].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[18].WeekDay,
                    Shift = data[18].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift3_Thu_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift3_Thu.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift3_Thu.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift3_Thu_check.Visibility = Visibility.Visible;
                    Shift3_Thu_check.IsChecked = true;
                    Shift3_Thu.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift3_Thu_check.Visibility = Visibility.Visible;
                Shift3_Thu.Visibility = Visibility.Hidden;
            }
            if (data[19].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[19].WeekDay,
                    Shift = data[19].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift4_Thu_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift4_Thu.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift4_Thu.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift4_Thu_check.Visibility = Visibility.Visible;
                    Shift4_Thu_check.IsChecked = true;
                    Shift4_Thu.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift4_Thu_check.Visibility = Visibility.Visible;
                Shift4_Thu.Visibility = Visibility.Hidden;
            }
            if (data[0].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[0].WeekDay,
                    Shift = data[0].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift1_Fri_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift1_Fri.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift1_Fri.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift1_Fri_check.Visibility = Visibility.Visible;
                    Shift1_Fri_check.IsChecked = true;
                    Shift1_Fri.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift1_Fri_check.Visibility = Visibility.Visible;
                Shift1_Fri.Visibility = Visibility.Hidden;
            }
            if (data[1].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[1].WeekDay,
                    Shift = data[1].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift2_Fri_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift2_Fri.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift2_Fri.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift2_Fri_check.Visibility = Visibility.Visible;
                    Shift2_Fri_check.IsChecked = true;
                    Shift2_Fri.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift2_Fri_check.Visibility = Visibility.Visible;
                Shift2_Fri.Visibility = Visibility.Hidden;
            }
            if (data[2].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[2].WeekDay,
                    Shift = data[2].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift3_Fri_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift3_Fri.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift3_Fri.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift3_Fri_check.Visibility = Visibility.Visible;
                    Shift3_Fri_check.IsChecked = true;
                    Shift3_Fri.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift3_Fri_check.Visibility = Visibility.Visible;
                Shift3_Fri.Visibility = Visibility.Hidden;
            }
            if (data[3].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[3].WeekDay,
                    Shift = data[3].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift4_Fri_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift4_Fri.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift4_Fri.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift4_Fri_check.Visibility = Visibility.Visible;
                    Shift4_Fri_check.IsChecked = true;
                    Shift4_Fri.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift4_Fri_check.Visibility = Visibility.Visible;
                Shift4_Fri.Visibility = Visibility.Hidden;
            }
            if (data[8].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[8].WeekDay,
                    Shift = data[8].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift1_Sat_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift1_Sat.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift1_Sat.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift1_Sat_check.Visibility = Visibility.Visible;
                    Shift1_Sat_check.IsChecked = true;
                    Shift1_Sat.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift1_Sat_check.Visibility = Visibility.Visible;
                Shift1_Sat.Visibility = Visibility.Hidden;
            }
            if (data[9].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[9].WeekDay,
                    Shift = data[9].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift2_Sat_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift2_Sat.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift2_Sat.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift2_Sat_check.Visibility = Visibility.Visible;
                    Shift2_Sat_check.IsChecked = true;
                    Shift2_Sat.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift2_Sat_check.Visibility = Visibility.Visible;
                Shift2_Sat.Visibility = Visibility.Hidden;
            }
            if (data[10].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[10].WeekDay,
                    Shift = data[10].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift3_Sat_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift3_Sat.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift3_Sat.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift3_Sat_check.Visibility = Visibility.Visible;
                    Shift3_Sat_check.IsChecked = true;
                    Shift3_Sat.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift3_Sat_check.Visibility = Visibility.Visible;
                Shift3_Sat.Visibility = Visibility.Hidden;
            }
            if (data[11].Status == 0)
            {
                Object Id = new
                {
                    Week = DateTime.Today.DayOfYear / 7,
                    WeekDay = data[11].WeekDay,
                    Shift = data[11].Shift
                };
                ShiftDAO dao = new ShiftDAO();
                UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;
                if (sample.CashierID != LoginForm.Idcashier)
                {
                    Shift4_Sat_check.Visibility = Visibility.Hidden;
                    BrushConverter bc = new BrushConverter();
                    Shift4_Sat.Background = (Brush)bc.ConvertFrom("#DCDCDC");
                    Shift4_Sat.Visibility = Visibility.Visible;
                }
                else
                {
                    Shift4_Sat_check.Visibility = Visibility.Visible;
                    Shift4_Sat_check.IsChecked = true;
                    Shift4_Sat.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Shift4_Sat_check.Visibility = Visibility.Visible;
                Shift4_Sat.Visibility = Visibility.Hidden;
            }
        }

        private List<UserShiftEntity> Registation_Shift_list = new List<UserShiftEntity>();
        private List<bool> regStatus = new List<bool>();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = false;

            ShiftDAO dao = new ShiftDAO();
            for (int i = 0; i < Registation_Shift_list.Count; i++)
            {
                if (regStatus[i] == true)
                {
                    Object Id = new
                    {
                        Week = DateTime.Today.DayOfYear / 7,
                        WeekDay = Registation_Shift_list[i].WeekDay,
                        Shift = Registation_Shift_list[i].Shift
                    };

                    UserShiftEntity temp = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;

                    if (temp == null)
                        dao.insert(Registation_Shift_list[i]);
                }
                else
                {
                    dao.delete(Registation_Shift_list[i]);
                }
            }
            this.Page_Loaded(null, null);
            button.IsEnabled = true;
            MessageBox.Show("Shift Updated", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Monday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Sunday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_10(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Monday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_11(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Monday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_12(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Monday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_13(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Tuesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_14(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Tuesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_15(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Tuesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_16(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Wednesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_17(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Wednesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_18(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Wednesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_19(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Thursday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Tuesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_20(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Thursday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_21(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Thursday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_22(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Friday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_23(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Friday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_24(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Friday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_25(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Saturday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_26(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Saturday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_27(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Saturday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Wednesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_4(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Thursday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_5(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Friday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_6(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Saturday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_7(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Sunday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_8(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Sunday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void CheckBox_Checked_9(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Sunday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(true);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Registation_Shift_list = new List<UserShiftEntity>();
            regStatus = new List<bool>();
            List<ShiftTime> data = ShiftTime.getAllShift();
            Load_Table(data);
        }

        private void Shift1_Fri_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Friday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift1_Mon_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Monday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift1_Sat_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Saturday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift1_Sun_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Sunday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift1_Thu_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Thursday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift1_Tues_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Tuesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift1_Wed_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 1,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Wednesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift2_Fri_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Friday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift2_Mon_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Monday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift2_Sat_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Saturday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift2_Sun_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Sunday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift2_Thu_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Thursday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift2_Tues_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Tuesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift2_Wed_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 2,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Wednesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift3_Fri_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Friday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift3_Mon_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Monday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift3_Sat_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Saturday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift3_Sun_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Sunday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift3_Thu_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Thursday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift3_Tues_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Tuesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift3_Wed_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 3,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Wednesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift4_Fri_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Friday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift4_Mon_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Monday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift4_Sat_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Saturday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift4_Sun_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Sunday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift4_Thu_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Thursday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift4_Tues_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Tuesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }

        private void Shift4_Wed_check_Unchecked(object sender, RoutedEventArgs e)
        {
            UserShiftEntity temp = new UserShiftEntity()
            {
                CashierID = LoginForm.Idcashier,
                Shift = 4,
                Week = DateTime.Today.DayOfYear / 7,
                WeekDay = "Wednesday"
            };
            Registation_Shift_list.Add(temp); regStatus.Add(false);
        }
    }
}