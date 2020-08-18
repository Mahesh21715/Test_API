using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Test__API;

namespace Test_API.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {

        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private string userId;
        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserId"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private void Login()
        {
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Password))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            { 
                if (UserId == "mahesh2020" && Password == "Silicus@123")
                {
                    App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                    //Navigate to Wellcom page after successfully login  
                    
                    App.Current.MainPage.Navigation.PushAsync(new user_page());

                }
                else
                    App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
            }
        }
    }
}
