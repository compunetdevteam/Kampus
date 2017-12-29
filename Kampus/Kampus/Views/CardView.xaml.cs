using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kampus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardView : ContentView
    {
        public CardView()
        {
            InitializeComponent();
            //var model = new CardViewModel();
            //BindingContext = model.CardDataModels;
        }
    }
}