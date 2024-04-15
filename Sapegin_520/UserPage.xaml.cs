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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sapegin_520
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage() 
        {
            InitializeComponent(); 
            LoadEvents(); 
        }

        private void LoadEvents() 
        {
            lstEvents.ItemsSource = Model.Events.ToList(); 
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            DateTime searchDate;
            bool isDate = DateTime.TryParse(searchText, out searchDate);

            var filteredData = Model.Events
                .Where(s => s.Venue.ToLower().Contains(searchText) ||
                            s.NumberOfVisitors.ToString().Contains(searchText) ||
                            (isDate && DbFunctions.TruncateTime(s.Date) == DbFunctions.TruncateTime(searchDate)) ||
                            s.FormOfEvents.FormOfEventName.ToLower().Contains(searchText))
                .ToList();
            lstEvents.ItemsSource = filteredData;
        }
    }
}
