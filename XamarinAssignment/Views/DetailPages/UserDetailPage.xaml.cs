using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinAssignment.ViewModels;

namespace XamarinAssignment.Views.DetailPages
{
    public partial class UserDetailPage : ContentPage
    {
        public UserDetailPage(AddUserViewModel AddUserViewModel)
        {
            InitializeComponent();

            BindingContext = AddUserViewModel;
        }
    }
}
