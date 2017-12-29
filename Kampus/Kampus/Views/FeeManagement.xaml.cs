
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kampus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeeManagement : ContentPage
    {
        //private Label labelLoading;
        public FeeManagement()
        {
            InitializeComponent();
            Browser.Source = "https://ebsuportal.azurewebsites.net/SchoolFeepayments/MakePayment";
            LoadingLabel.IsVisible = true;
            //var layout = new StackLayout();
            //labelLoading = new Label()
            //{
            //    Text = "Loading",
            //    IsVisible = true,
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand
            //};

            //webView.Navigated += WebViewNavigated;
            //webView.Navigating += WebViewNavigation;

            //layout.Children.Add(webView);
            //layout.Children.Add(labelLoading);
            //Content = layout;
        }

        private void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            LoadingLabel.IsVisible = true;

        }

        private void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            LoadingLabel.IsVisible = false;
        }

        private void backClicked(object sender, EventArgs e)
        {
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }
            else
            { // If not, leave the view
                Navigation.PopAsync();
            }
        }

        private void forwardClicked(object sender, EventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }
    }
}