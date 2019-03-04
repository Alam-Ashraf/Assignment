using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinAssignment.Constants;
using XamarinAssignment.Models;
using XamarinAssignment.Popups;
using XamarinAssignment.Services;

namespace XamarinAssignment.ViewModels
{
    public class UserListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get; set; }

        private List<Contact> _userList = new List<Contact>();
        private Contact _selectedUser;

        public List<Contact> UserList
        {
            get
            {
                return _userList;
            }
            set
            {
                _userList = value;

                OnPropertyChanged();
            }
        }

        public UserListViewModel()
        {
        }

        public async void GetUsers()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                // Show Indicator
                await PopupNavigation.Instance.PushAsync(new IndicatorView());

                GetUserService getUserService = new GetUserService();

                // Call Api to get user list
                var userList = await getUserService.GetUserList();

                await PopupNavigation.Instance.PopAsync();

                if (userList != null)
                {
                    if(Constant.ListOfNewAddedUser!=null && Constant.ListOfNewAddedUser.Count>0)
                    {
                        userList.AddRange(Constant.ListOfNewAddedUser);
                    }

                    UserList = userList;
                }
                else
                {
                    // Server Not Responding
                }
            }
            else
            {
                // No Internet
                
            }
        }


        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
