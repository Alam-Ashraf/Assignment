using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinAssignment.Constants;
using XamarinAssignment.Helpers;
using XamarinAssignment.Models;
using XamarinAssignment.Popups;
using XamarinAssignment.Views;
using XamarinAssignment.Views.DetailPages;

namespace XamarinAssignment.ViewModels
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AddUserPage AddUserPage {get; set;}

        public INavigation Navigation { get; set; }

        public List<string> NationalityList { get; set;}
        public List<string> MaritalStatusList  { get; set;}
        public List<string> SexList { get; set; }

        private ImageSource _image = ImageSource.FromFile("user.png");
        private string _name="";
        private string _email="";
        private string _phone="";
        private DateTime _selectedDate = DateTime.Now;
        private string _selectedDateInString;
        private string _selectedNationality = "India";
        private string _selectedMaritalStatus = "Single";
        private string _selectedSex = "Male";

        // Error Msg
        private bool isImagePicked = false;

        private Color _imageBoarderColor = (Color) Application.Current.Resources["ColorRed"];

        public ICommand AddToListCommand { get; private set; }
        public ICommand SubmitCommand { get; private set; }
        public ICommand PickImageCommand { get; private set; }
        public ICommand ChooseDateOfBirthCommand { get; private set; }
        public ICommand ChooseNationalityCommand { get; private set; }
        public ICommand ChooseMaritalStatusCommand { get; private set; }
        public ICommand ChooseSexCommand { get; private set; }

        ChooseImageFromPopUpView ChooseImageFromPopUpView;

        public AddUserViewModel()
        {
            AddToListCommand = new Command(AddUser);
            SubmitCommand = new Command(SubmitForm);
            PickImageCommand = new Command(PickImage);
            ChooseDateOfBirthCommand = new Command(ChooseDateOfBirth);
            ChooseNationalityCommand = new Command(ChooseNationality);
            ChooseMaritalStatusCommand = new Command(ChooseMaritalStatus);
            ChooseSexCommand = new Command(ChooseSex);

            // Set Picker Value
            MakePickerList();
        }

        private void AddUser()
        {
            // Add New User to the main list

            Contact contact = new Contact();
            contact.name = Name;
            contact.email = Email;
            contact.gender = SelectedSex;
            contact.image = PickedImageSource;

            if (Constant.ListOfNewAddedUser==null)
            {
                Constant.ListOfNewAddedUser = new List<Contact>();
            }

            Constant.ListOfNewAddedUser.Add(contact);

            Navigation.PushAsync(new HomeMasterDetailPage());
            //Navigation.PopToRootAsync();

        }

        private void SubmitForm()
        {
            if(IsValidForm())
            {
                Navigation.PushAsync(new UserDetailPage(this));
            }
        }

        private bool IsValidForm()
        {
            if (!IsImagePicked)
            {
                AddUserPage.DisplayMsg("Pick image.");
                return false;
            }
            else if (string.IsNullOrEmpty(Name))
            {
                AddUserPage.DisplayMsg("Enter name.");
                return false;
            }
            else if (!Utils.IsValidEmail(Email))
            {
                AddUserPage.DisplayMsg("Enter valid email.");
                return false;
            }
            else if (string.IsNullOrEmpty(Phone))
            {
                AddUserPage.DisplayMsg("Enter phone.");
                return false;
            }

            return true;
        }

        private async void PickImage()
        {
            ChooseImageFromPopUpView = new ChooseImageFromPopUpView();
            ChooseImageFromPopUpView.SelectedImage+= ChooseImageFromPopUpViewSelectedImage;

            // Show Indicator
            await PopupNavigation.Instance.PushAsync(ChooseImageFromPopUpView);
        }

        void ChooseImageFromPopUpViewSelectedImage(object sender, Plugin.Media.Abstractions.MediaFile file)
        {
            PickedImageSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();

                IsImagePicked = true;

                return stream;
            });
        }


        private void ChooseDateOfBirth()
        {
            if (AddUserPage != null)
            {
                AddUserPage.ShowDOBPicker();
            }
        }

        private void ChooseNationality()
        {
            if(AddUserPage!=null)
            {
                AddUserPage.ShowNationalityPicker();
            }
        }

        private void ChooseMaritalStatus()
        {
            if (AddUserPage != null)
            {
                AddUserPage.ShowMaritalStatusPicker();
            }
        }

        private void ChooseSex()
        {
            if (AddUserPage != null)
            {
                AddUserPage.ShowSexPicker();
            }
        }

        public bool IsImagePicked
        {
            get
            {
                return isImagePicked;
            }
            set
            {
                isImagePicked = value;

                if(isImagePicked)
                {
                    ImageBoarderColor = (Color)Application.Current.Resources["ColorNavyBlue"];
                }
                else
                {
                    ImageBoarderColor = (Color)Application.Current.Resources["ColorRed"];
                }

                OnPropertyChanged();
            }
        }

        public Color ImageBoarderColor
        {
            get
            {
                return _imageBoarderColor;
            }
            set
            {
                _imageBoarderColor = value;

                OnPropertyChanged();
            }
        }


        public ImageSource PickedImageSource
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;

                OnPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;

                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;

                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;

                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }

            set
            {
                _selectedDate = value;

                SelectedDateInString = _selectedDate.ToString("yyyy-MM-dd");

                OnPropertyChanged();

            }
        }

        public string SelectedDateInString
        {
            get
            {
                return _selectedDateInString;
            }

            set
            {
                _selectedDateInString = value;
                OnPropertyChanged();
            }
        }

        public string SelectedNationality
        {
            get
            {
                return _selectedNationality;
            }
            set
            {
                _selectedNationality = value;

                OnPropertyChanged();
            }
        }

        public string SelectedMaritalStatus
        {
            get
            {
                return _selectedMaritalStatus;
            }
            set
            {
                _selectedMaritalStatus = value;

                OnPropertyChanged();
            }
        }

        public string SelectedSex
        {
            get
            {
                return _selectedSex;
            }
            set
            {
                _selectedSex = value;

                OnPropertyChanged();
            }
        }

        private void MakePickerList()
        {
            NationalityList = new List<string>();
            MaritalStatusList = new List<string>();
            SexList = new List<string>();

            // Nationality List
            NationalityList.Add("India");
            NationalityList.Add("Cameroon");
            NationalityList.Add("China");
            NationalityList.Add("Brazil");

            // Marital Status List
            MaritalStatusList.Add("Single");
            MaritalStatusList.Add("Married");

            // Sex List
            SexList.Add("Male");
            SexList.Add("Female");

        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
