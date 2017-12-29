using Kampus.Models;
using Kampus.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kampus.ViewModels
{
    public class LoginViewModel
    {
        private LoginModel _selectedLogin = new LoginModel();
        private StudentApi _message;
        private INavigation _navigation;



        public StudentApi Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public LoginModel _loginModel { get; set; }

        public LoginModel LoginModel
        {
            get { return _loginModel; }
            set
            {
                _loginModel = value;
                OnPropertyChanged();
            }

        }

        public LoginModel SelectedLoginModel
        {
            get { return _selectedLogin; }
            set
            {
                _selectedLogin = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand
        {
            get
            {
                return new Command((async () =>
                {
                    var loginService = new LoginServices();
                    var result = await loginService.LoginAsync(_selectedLogin);
                    Message = result;


                }));
            }
        }

        public async Task<StudentApi> MakeLogin(LoginModel model)
        {
            var loginService = new LoginServices();
            var result = await loginService.LoginAsync(model);
            return result;
            //await _navigation.PushAsync(new RegisterStudent());
        }



        public LoginViewModel()
        {

            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var employeesService = new EmployeeServices();
            //LoginModel = await employeesService.GetEmployeesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
