using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinAssignment.Dependencies;
using XamarinAssignment.Views.DetailPages;

namespace XamarinAssignment.Views
{
    public partial class HomeMasterDetailPage : MasterDetailPage
    {
        public HomeMasterDetailPage()
        {
            InitializeComponent();

            // Hide Default Toolbar
            NavigationPage.SetHasNavigationBar(this, false);

            HandleClickEvent();

        }

        /// <summary>
        /// Handles the click event.
        /// </summary>
        private void HandleClickEvent()
        {
            MasterPage.ChangeDetailPage += ChangeDetailPage;
        }

        /// <summary>
        /// Changes the detail page.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="detailPage">Detail page.</param>
        public void ChangeDetailPage(object sender, ContentPage detailPage)
        {
            HideShownavigationDrawer(false);

            // Hide Default Toolbar
            //NavigationPage.SetHasNavigationBar(detailPage, false);

            Detail = new NavigationPage(detailPage);
        }

        /// <summary>
        /// Ons the appearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            HideShownavigationDrawer(false);
        }

        /// <summary>
        /// Hides the shownavigation drawer.
        /// </summary>
        /// <param name="isShowDrawer">If set to <c>true</c> is show drawer.</param>
        private void HideShownavigationDrawer(bool isShowDrawer)
        {
            IsPresented = isShowDrawer;
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("", "Do you really want to exit from app ?", "Yes", "No");

                if (result)
                {
                    Kill();
                }

            });

            return true;
        }

        protected internal void Kill()
        {
            if (Device.Android == Device.RuntimePlatform)
            {
                DependencyService.Get<ICloseApplication>().closeApplication();
            }
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }

        }


    }
}
