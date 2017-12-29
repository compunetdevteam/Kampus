using Kampus.MenuItems;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Kampus.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }



        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Navigation.RemovePage(new Login());



            menuList = new List<MasterPageItem>();
            var pageDashboard = new MasterPageItem() { Title = "DashBoard", Icon = "iconcourse.png", TargetType = typeof(ViewMain) };

            var page1 = new MasterPageItem() { Title = "Course Registration", Icon = "iconcourse.png", TargetType = typeof(CourseRegistration) };
            var page2 = new MasterPageItem() { Title = "Pay Fee", Icon = "iconmoney.png", TargetType = typeof(FeeManagement) };
            var page3 = new MasterPageItem() { Title = "Accommodation", Icon = "iconhouse.png", TargetType = typeof(Accommodation) };
            var page4 = new MasterPageItem() { Title = "Result", Icon = "iconresult.png", TargetType = typeof(Result) };
            var page5 = new MasterPageItem() { Title = "E learning", Icon = "iconelearning.png", TargetType = typeof(ELearning) };

            menuList.Add(pageDashboard);
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ViewMain)));

            this.BindingContext = new
            {
                Header = "",
                Image = "schcap.jpg",
                Footer = "Welcome to SwiftKampus"

            };

        }



        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;


            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
