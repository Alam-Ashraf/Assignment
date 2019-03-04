using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinAssignment.Views.DetailPages;
using XamarinAssignment.Views.MasterPages;

namespace XamarinAssignment.ViewModels
{
    public class MasterOptionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand UserListCommand { get; private set; }
        public ICommand AddUserCommand { get; private set; }
        public ICommand NativeCommand { get; private set; }

        public MasterOptionPage MasterOptionPage;

        UserListPage userListPage;
        AddUserPage addUserPage;

        public MasterOptionViewModel()
        {
            UserListCommand = new Command(OnUserListClick);
            AddUserCommand = new Command(OnAddUserClick);
            NativeCommand = new Command(OnNativePageClick);

            userListPage = new UserListPage();
            addUserPage = new AddUserPage();
        }

        public void OnUserListClick()
        {
            if(MasterOptionPage!=null)
            {
                MasterOptionPage.UpdateMasterDetailPage(userListPage);
            }
        }

        public void OnAddUserClick()
        {
            if (MasterOptionPage != null)
            {
                MasterOptionPage.UpdateMasterDetailPage(addUserPage);
            }
        }

        public void OnNativePageClick()
        {
            if (MasterOptionPage != null)
            {
                MasterOptionPage.OpenPlateformSpecificPage();
            }
        }


        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
