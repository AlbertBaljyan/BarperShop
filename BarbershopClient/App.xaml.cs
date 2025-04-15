using BarbershopClient.Views;
namespace BarbershopClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new HomePage());

          
        }
    }
}
