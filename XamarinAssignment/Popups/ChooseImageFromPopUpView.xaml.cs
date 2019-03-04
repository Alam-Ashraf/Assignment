using System;
using System.Collections.Generic;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinAssignment.ViewModels;

namespace XamarinAssignment.Popups
{
    public partial class ChooseImageFromPopUpView : PopupPage
    {
        // Event Handler
        public event EventHandler<MediaFile> SelectedImage;

        ChooseImageFromPopUpViewModel ChooseImageFromPopUpViewModel;

        public ChooseImageFromPopUpView()
        {
            InitializeComponent();

            ChooseImageFromPopUpViewModel = new ChooseImageFromPopUpViewModel();
            ChooseImageFromPopUpViewModel.ChooseImageFromPopUpView = this;

            BindingContext = ChooseImageFromPopUpViewModel;

            //CloseWhenBackgroundIsClicked = false;

        }

        public async void SetPickedImage(MediaFile mediaFile)
        {
            // Fire Event 
            if (SelectedImage != null)
            {
                await PopupNavigation.Instance.PopAsync();

                SelectedImage.Invoke(this, mediaFile);
            }
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return true;
        }
    }
}
