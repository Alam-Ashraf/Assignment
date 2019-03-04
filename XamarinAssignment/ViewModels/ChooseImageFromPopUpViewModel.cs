using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.Media;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinAssignment.Popups;

namespace XamarinAssignment.ViewModels
{
    public class ChooseImageFromPopUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CameraCommand { get; private set; }
        public ICommand GalleryCommand { get; private set; }
        public ICommand BackgroundCommand { get; private set; }

        public ChooseImageFromPopUpView ChooseImageFromPopUpView { get; set; }

        public ChooseImageFromPopUpViewModel()
        {
            CameraCommand = new Command(OnCameraClick);
            GalleryCommand = new Command(OnGalleryClick);
            BackgroundCommand = new Command(OnBackgroundClick);
        }

        public async void OnBackgroundClick()
        {
            // Close popup
            await PopupNavigation.Instance.PopAsync();
        }

        public void OnCameraClick()
        {
            // Click photo
            TakePhoto();
        }

        public void OnGalleryClick()
        {
            // choose image from gallery
            ChooseImageFromGallery();
        }

        private async void TakePhoto()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await ChooseImageFromPopUpView.DisplayAlert("No Camera available", ":( no camera available.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                        SaveToAlbum = true,
                    });
                if (file == null)
                {
                    return;
                }

                // Set picked image
                ChooseImageFromPopUpView.SetPickedImage(file);

            }
            catch (Exception e)
            {

            }
        }

        private async void ChooseImageFromGallery()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    if(ChooseImageFromPopUpView!=null)
                    {
                        await ChooseImageFromPopUpView.DisplayAlert("Oops...", "Pick photo is not supported.", "Ok");
                    }
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                    return;

                // Set picked image
                ChooseImageFromPopUpView.SetPickedImage(file);

            }
            catch (Exception e)
            {
            }
        }

        public byte[] ConvertStramToByteArray(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
