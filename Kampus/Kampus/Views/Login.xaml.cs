using Kampus.Models;
using Kampus.ViewModels;
using Plugin.Connectivity;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kampus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private readonly LoginViewModel _loginViewModel = new LoginViewModel();
        public Login()
        {
            InitializeComponent();

            this.InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;
            //BindingContext = _loginViewModel;


        }

        private async void BtnLogin(object sender, EventArgs e)
        {
            //var isConnected = CrossConnectivity.Current.IsConnected;
            //if (isConnected != true)
            //{
            //    await DisplayAlert("Network", "No Network Available, Please Check your Internet Connection Settings", "Ok");
            //}
            //else
            //{
            this.IsBusy = true;
            if (string.IsNullOrEmpty(EmailEntry.Text)
                || string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await DisplayAlert("Validation Error", "Please fill both username or password", "Ok");
                this.IsBusy = false;
            }
            else
            {
                var loginModel = new LoginModel()
                {
                    Email = EmailEntry.Text.Trim(),
                    Password = PasswordEntry.Text.Trim()
                };

                var respose = await _loginViewModel.MakeLogin(loginModel);

                if (string.IsNullOrEmpty(respose.StudentId))
                {
                    await DisplayAlert("Validation Error", respose.Message, "Ok");
                    this.IsBusy = false;
                }
                else
                {
                    //await Navigation.PushAsync(new MainPage());
                    this.IsBusy = false;
                    Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                    //Application.Current.MainPage = new MainPage();
                    Application.Current.MainPage.Navigation.RemovePage(originalPage);

                }
            }


            // }
        }

        private async void BtnSignUp(object sender, EventArgs e)
        {

            Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
            await Application.Current.MainPage.Navigation.PushAsync(new SearchStudent());
            Application.Current.MainPage.Navigation.RemovePage(originalPage);

        }

        private async void CheckConnectivity()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected != true)
            {
                await DisplayAlert("Network", "No Network Available, Please Check your Internet Connection Settings", "Ok");
            }

        }
    }
}