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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        public AdminPage() // Конструктор класса AdminPage.
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            lstEvents.ItemsSource = Model.Events.ToList();

            private void btnAddEvent_Click(object sender, RoutedEventArgs e)
            {
                AddPage addEventWindow = new AddPage();
                addEventWindow.ShowDialog();
                LoadEvents();
            }

            private void btnDeleteEvent_Click(object sender, RoutedEventArgs e)
            {
                Events selectedEvent = (Events)lstEvents.SelectedItem;
                if (selectedEvent != null)
                {
                    Model.Events.Remove(selectedEvent);
                    Model.SaveChanges();
                    LoadEvents();
                }
            }
        }
    }
}
