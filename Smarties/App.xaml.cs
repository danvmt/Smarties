using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace Smarties
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var tabs = new TabbedPage();

            //var tab1 = new NavigationPage(new SmartiesPage());
            //tab1.Title = "Home";


            //var generalSettingsPage = new GeneralSettingsPage();
            //generalSettingsPage.BindingContext = AppContext.GeneralSettings;
            //var tab2 = new NavigationPage(generalSettingsPage);
            //tab2.Title = "Settings";

            //tabs.Children.Add(tab1);
            //tabs.Children.Add(tab2);

            MainPage = new NavigationPage(new SmartiesPage());
        }

        protected override void OnStart()
        {


        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
