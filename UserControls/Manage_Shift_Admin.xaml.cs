using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for Manage_Shift_Admin.xaml
    /// </summary>
    public partial class Manage_Shift_Admin : UserControl
    {
        public static bool isUpdate = false;

        public Manage_Shift_Admin()
        {
            InitializeComponent();

            // khởi tạo
            listShiftTime = ShiftTime.getAllShift();

            //thêm vào map (shift,button,textbox)
            listShiftMapping.Add(new ShiftMapping(listShiftTime[0], Add_Fri_Shift1_btn, Shift1_Fri));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[1], Add_Fri_Shift2_btn, Shift2_Fri));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[2], Add_Fri_Shift3_btn, Shift3_Fri));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[3], Add_Fri_Shift4_btn, Shift4_Fri));

            listShiftMapping.Add(new ShiftMapping(listShiftTime[4], Add_Mon_Shift1_btn, Shift1_Mon));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[5], Add_Mon_Shift2_btn, Shift2_Mon));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[6], Add_Mon_Shift3_btn, Shift3_Mon));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[7], Add_Mon_Shift4_btn, Shift4_Mon));

            listShiftMapping.Add(new ShiftMapping(listShiftTime[8], Add_Sat_Shift1_btn, Shift1_Sat));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[9], Add_Sat_Shift2_btn, Shift2_Sat));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[10], Add_Sat_Shift3_btn, Shift3_Sat));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[11], Add_Sat_Shift4_btn, Shift4_Sat));

            listShiftMapping.Add(new ShiftMapping(listShiftTime[12], Add_Sun_Shift1_btn, Shift1_Sun));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[13], Add_Sun_Shift2_btn, Shift2_Sun));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[14], Add_Sun_Shift3_btn, Shift3_Sun));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[15], Add_Sun_Shift4_btn, Shift4_Sun));

            listShiftMapping.Add(new ShiftMapping(listShiftTime[16], Add_Thu_Shift1_btn, Shift1_Thu));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[17], Add_Thu_Shift2_btn, Shift2_Thu));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[18], Add_Thu_Shift3_btn, Shift3_Thu));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[19], Add_Thu_Shift4_btn, Shift4_Thu));

            listShiftMapping.Add(new ShiftMapping(listShiftTime[20], Add_Tues_Shift1_btn, Shift1_Tues));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[21], Add_Tues_Shift2_btn, Shift2_Tues));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[22], Add_Tues_Shift3_btn, Shift3_Tues));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[23], Add_Tues_Shift4_btn, Shift4_Tues));

            listShiftMapping.Add(new ShiftMapping(listShiftTime[24], Add_Wed_Shift1_btn, Shift1_Wed));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[25], Add_Wed_Shift2_btn, Shift2_Wed));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[26], Add_Wed_Shift3_btn, Shift3_Wed));
            listShiftMapping.Add(new ShiftMapping(listShiftTime[27], Add_Wed_Shift4_btn, Shift4_Wed));
        }

        public async void Load_Table()
        {
            //update status shift
            listShiftTime = ShiftTime.getAllShift();

            //update trong map
            for (int i = 0; i < listShiftMapping.Count; i++)
            {
                listShiftMapping[i].shift = listShiftTime[i];
            }

            //khởi tạo list thread, 1 task = 1 thread
            List<Task> taskList = new List<Task>();

            //duyệt mỗi ô, update mỗi ô = 1 thread
            foreach (var shiftMapping in listShiftMapping)
            {
                //add vào thead tự chạy
                taskList.Add(LoadShift(shiftMapping));
            }

            //đợi cho tất cả các ô chạy xong
            await Task.WhenAll(taskList);
        }

        //list map (shift,button,textbox)
        private readonly List<ShiftMapping> listShiftMapping = new List<ShiftMapping>();

        private List<ShiftTime> listShiftTime = new List<ShiftTime>();

        private async void Add_Shift_btn_Click(object sender, RoutedEventArgs e)
        {
            string btnName = (sender as Button).Name.ToString();
            string[] element = btnName.Split('_');

            var f = new Add_Shift(element[1], element[2]);
            f.ShowDialog();

            if (isUpdate)
            {
                //add thì update thằng đó thôi, update hết sẽ lâu
                ShiftMapping currentElement = listShiftMapping.Find((map) => map.button == (sender as Button));
                currentElement.shift.Status = 0;
                await LoadShift(currentElement);
            }
        }

        //async thì c# tự hiểu là tạo thread mới
        private async Task LoadShift(ShiftMapping map)
        {
            //tạo kiểu task
            await Task.Run(() =>
                           {
                               //có cập nhật UI thì phải xài hàm này để đảm bảo không conflict UI
                               this.Dispatcher.Invoke(() =>
                                                      {
                                                          //đoạn này của m
                                                          if (map.shift.Status == 0)
                                                          {
                                                              Object Id = new
                                                              {
                                                                  Week = DateTime.Today.DayOfYear / 7,
                                                                  WeekDay = map.shift.WeekDay,
                                                                  Shift = map.shift.Shift
                                                              };
                                                              ShiftDAO dao = new ShiftDAO();

                                                              UserShiftEntity sample = dao.get(Id, typeof(UserShiftEntity)) as UserShiftEntity;

                                                              map.button.Visibility = Visibility.Hidden;
                                                              BrushConverter bc = new BrushConverter();
                                                              map.textBlock.Background = (Brush)bc.ConvertFrom("#DCDCDC");

                                                              map.textBlock.Text =
                                                                  (new UserDAO().get(sample.CashierID) as UserEntity)
                                                                  .FullName.Trim();

                                                              map.textBlock.Visibility = Visibility.Visible;
                                                          }
                                                          else
                                                          {
                                                              map.button.Visibility = Visibility.Visible;
                                                              map.textBlock.Visibility = Visibility.Hidden;
                                                          }
                                                      });
                           });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Table();
        }

        private async void Reset_Shift_btn_Click(object sender, RoutedEventArgs e)
        {
            Reset_Shift_btn.Visibility = Visibility.Hidden;

            //quăng phần update dưới db cho 1 thread khác, UI không quan tâm phần này
            Task t = Task.Run(() =>
                     {
                         ShiftDAO dao = new ShiftDAO();
                         List<UserShiftEntity> data = dao.getAll() as List<UserShiftEntity>;
                         List<UserShiftEntity> Weekdata = data.Where(x => x.Week == DateTime.Today.DayOfYear / 7).ToList();
                         foreach (var c in Weekdata)
                         {
                             dao.delete(c);
                         }
                     });

            ShiftTime.resetShift();
            Load_Table();
            await t;

            MessageBox.Show("RESET DONE!", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);

            Reset_Shift_btn.Visibility = Visibility.Visible;
        }

        private class ShiftMapping
        {
            public Button button;
            public ShiftTime shift;
            public TextBlock textBlock;

            public ShiftMapping(ShiftTime _shift, Button _button, TextBlock _textBlock)
            {
                shift = _shift;
                button = _button;
                textBlock = _textBlock;
            }
        }
    }
}