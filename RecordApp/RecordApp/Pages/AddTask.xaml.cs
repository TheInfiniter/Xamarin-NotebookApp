using RecordApp.Models;
using System;
using RecordApp.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecordApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        public bool ReadOnlyTitle
        {
            set
            {
                EntryTitle.IsReadOnly = value;
            }
        }

        public bool ReadOnlyDescription 
        {
            set
            {
                EntryDescription.IsReadOnly = value;
            }
        }

        public bool VisibleSaveButton
        {
            set
            {
                SaveButton.IsVisible = value;
            }
        }

        public bool VisibleDeleteButton
        {
            set
            {
                DeleteButton.IsVisible = value;
            }
        }

        public bool VisibleUpdateButton
        {
            set
            {
                UpdateButton.IsVisible = value;
            }
        }

        public bool VisibleLabelName
        {
            set
            {
                LabelName.IsVisible = value;
            }
        }

        public bool VisibleLabelDescription
        {
            set
            {
                LabelDescription.IsVisible = value;
            }
        }

        public AddTask()
        {
            InitializeComponent();

            Title = "Добавить";
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var workItem = (ItemModel)BindingContext;
            await App.Database.SaveItemAsync(workItem);
            await Navigation.PopToRootAsync();
        }

        private async void OnToggle(object sender, EventArgs e)
        {
            OnSaveClicked(sender, e);
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var workItem = (ItemModel)BindingContext;
            await App.Database.DeleteItemAsync(workItem);
            await Navigation.PopAsync();
        }
        
        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            var newTask = new AddTask()
            {
                VisibleDeleteButton = false,
                VisibleUpdateButton = false,
            };

            newTask.BindingContext = BindingContext;

            await Navigation.PushAsync(newTask);
        }
    }
}