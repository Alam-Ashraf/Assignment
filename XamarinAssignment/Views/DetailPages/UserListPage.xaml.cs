using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using XamarinAssignment.Models;
using XamarinAssignment.ViewModels;

namespace XamarinAssignment.Views.DetailPages
{
    public partial class UserListPage : ContentPage
    {
        UserListViewModel UserListViewModel;

        public UserListPage()
        {
            InitializeComponent();

            UserListViewModel = new UserListViewModel();

            BindingContext = UserListViewModel;

            // Enable fast scrolling in Android Side
            UserListView.On<Android>().SetIsFastScrollEnabled(true);

            HandleClickEvent();
        }

        private void HandleClickEvent()
        {
            UserListView.ItemSelected+= UserListViewItemSelected;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Call User List Api
            UserListViewModel.GetUsers();
        }

        void UserListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listview = (Xamarin.Forms.ListView)sender;

            // Remove Selected item color (Orange)
            if(listview!=null)
            {
                listview.SelectedItem = null;
            }

            var user = (Contact) e.SelectedItem;


        }

    }
}
