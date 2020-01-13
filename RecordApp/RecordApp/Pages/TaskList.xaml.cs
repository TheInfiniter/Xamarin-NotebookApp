using RecordApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecordApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskList : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public TaskList()
        {
            InitializeComponent();

            Title = "Все записи";

            Items = new ObservableCollection<string>
            {
                "тест",
                "списка",
                "фидельман",
                "сасатб",
                "усач"
            };

            itemView.ItemsSource = Items;
        }

        /*
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        */

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            var taskInfo = new AddTask()
            {
                ReadOnlyTitle = true,
                ReadOnlyDescription = true,
                VisibleSaveButton = false,
                VisibleLabelName = false,
                VisibleLabelDescription = false,
                Title = "Подробности",
                BindingContext = e.SelectedItem as ItemModel
            };

            await Navigation.PushAsync(taskInfo);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public async void AddButton_Clicked(object sender, EventArgs e)
        {
            var newTask = new AddTask()
            {
                VisibleDeleteButton = false,
                VisibleUpdateButton = false,
                BindingContext = new ItemModel()
            };
            
            await Navigation.PushAsync(newTask);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            itemView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}
