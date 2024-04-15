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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtVenue.Text) ||
                dpDate.SelectedDate == null ||
                string.IsNullOrWhiteSpace(txtNumberOfVisitors.Text) ||
                cmbFormOfEvent.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            
            if (!int.TryParse(txtNumberOfVisitors.Text, out int numberOfVisitors))
            {
                MessageBox.Show("Пожалуйста, введите корректное число посетителей.");
                return; 
            }

            
            if (cmbFormOfEvent.SelectedItem != null)
            {
                
                string formOfEventName = cmbFormOfEvent.SelectedItem.ToString();

                
                var formOfEvent = Model.FormOfEvents.FirstOrDefault(f => f.FormOfEventName == formOfEventName);

                if (formOfEvent != null)
                {
                    
                    Events newEvent = new Events
                    {
                        Venue = txtVenue.Text,
                        Date = (DateTime)dpDate.SelectedDate,
                        NumberOfVisitors = int.Parse(txtNumberOfVisitors.Text),
                        FormOfEventID = formOfEvent.FormOfEventID
                    };

                    
                    Model.Events.Add(newEvent);
                    Model.SaveChanges();
                    MessageBox.Show("Мероприятие добавлено успешно.");
                    Close(); 
                }
                else
                {
                    MessageBox.Show("Выбранная форма мероприятия не найдена.");
                }
            }
            else
            {
                MessageBox.Show("Выберите форму мероприятия из списка.");
            }
        }
    }
}
