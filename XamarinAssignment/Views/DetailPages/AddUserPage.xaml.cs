using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinAssignment.ViewModels;

namespace XamarinAssignment.Views.DetailPages
{
    public partial class AddUserPage : ContentPage
    {
        AddUserViewModel AddUserViewModel;

        public AddUserPage()
        {
            InitializeComponent();

            AddUserViewModel = new AddUserViewModel();
            AddUserViewModel.AddUserPage = this;
            AddUserViewModel.Navigation = Navigation;

            BindingContext = AddUserViewModel;
        }

        public void ShowDateOfBirthPicker()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // get picker focus
                DOBPicker.Focus();
            });
        }

        public void ShowNationalityPicker()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // get picker focus
                NationalityPicker.Focus();
            });
        }

        public void ShowDOBPicker()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // get picker focus
                DOBPicker.Focus();
            });
        }

        public void ShowMaritalStatusPicker()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // get picker focus
                MaritalStatusPicker.Focus();
            });
        }

        public void ShowSexPicker()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // get picker focus
                SexPicker.Focus();
            });
        }

        public async void DisplayMsg(string msg)
        {
            await DisplayAlert("Error", msg, "Ok");
        }
    }
}
