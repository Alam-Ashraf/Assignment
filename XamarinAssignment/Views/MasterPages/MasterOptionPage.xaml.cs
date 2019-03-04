using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinAssignment.ViewModels;
using XamarinAssignment.Views.NativePage;

namespace XamarinAssignment.Views.MasterPages
{
    public partial class MasterOptionPage : ContentPage
    {
        // Event Handler
        public event EventHandler<ContentPage> ChangeDetailPage;

        // View Model
        MasterOptionViewModel MasterOptionViewModel;


        public MasterOptionPage()
        {
            InitializeComponent();

            MasterOptionViewModel = new MasterOptionViewModel();
            MasterOptionViewModel.MasterOptionPage = this;

            // Bind Model to the Xaml
            BindingContext = MasterOptionViewModel;

            if (Device.RuntimePlatform == Device.iOS)
            {
                //Icon = "menu.png";
            }

        }

        public void UpdateMasterDetailPage(ContentPage DetailPage)
        {
            // Fire Event 
            if(ChangeDetailPage!=null)
            {
                ChangeDetailPage.Invoke(this, DetailPage);
            }
        }

        public async void OpenPlateformSpecificPage()
        {
            await Navigation.PushAsync(new PlateformSpecificPage());
        }
    }
}
