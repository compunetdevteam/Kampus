using Kampus.Models;
using Kampus.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kampus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterStudent : ContentPage
    {
        private readonly SignUpViewModel _loginViewModel = new SignUpViewModel();

        public RegisterStudent(SignUpModel model)
        {

            InitializeComponent();
            if (model != null)
            {
                UserIdEntry.Text = model.UserId;
                FirstNameEntry.Text = model.FirstName;
                LastNameEntry.Text = model.LastName;
                DeptNameEntry.Text = model.Department;
            }

        }

        private async void BtnRegister(object sender, EventArgs e)
        {
            //var emailPattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            if (string.IsNullOrEmpty(EmailEntry.Text)
                || string.IsNullOrEmpty(PasswordEntry.Text) || string.IsNullOrEmpty(ConfirmPasswordEntry.Text))
            {
                await DisplayAlert("Validation Error", "Please fill both username or password", "Ok");
            }
            //if (string.IsNullOrEmpty(EmailEntry.Text) && Regex.IsMatch(EmailEntry.Text, emailPattern))
            //{

            //}
            if (!PasswordEntry.Text.Trim().Equals(ConfirmPasswordEntry.Text.Trim()))
            {
                await DisplayAlert("Validation Error", "Password and Password confirm do not match", "Ok");
            }
            var registerVm = new RegisterModel
            {
                StudentId = UserIdEntry.Text.Trim(),
                FirstName = FirstNameEntry.Text.Trim(),
                LastName = LastNameEntry.Text.Trim(),
                Email = EmailEntry.Text.Trim(),
                Department = DeptNameEntry.Text.ToString(),
                Password = PasswordEntry.Text.Trim(),
                ConfirmPassword = ConfirmPasswordEntry.Text.Trim()
            };
            var respose = await _loginViewModel.RegisterStudent(registerVm);
            if (respose.Equals("\"Registration Successful\""))
            {
                await DisplayAlert("Alert", "Registration Successful, Please Check your email and confirm ", "Ok");
                //await Navigation.PushAsync(new MainPage());
                Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
                await Application.Current.MainPage.Navigation.PushAsync(new Login());
                //Application.Current.MainPage = new MainPage();
                Application.Current.MainPage.Navigation.RemovePage(originalPage);
            }
            else
            {
                await DisplayAlert("Validation Error", respose, "Ok");

            }
        }

        private async void BtnLogin(object sender, EventArgs e)
        {
            Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
            await Application.Current.MainPage.Navigation.PushAsync(new Login());
            //Application.Current.MainPage = new MainPage();
            Application.Current.MainPage.Navigation.RemovePage(originalPage);
        }
    }
}