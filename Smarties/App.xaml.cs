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

        private async Task InitDBAsync()
        {
            var fileHelperService = DependencyService.Get<IFileHelper>();
            if (fileHelperService == null)
            {
                return;
            }

            var databaseFilePath = fileHelperService.GetLocalFilePath("RoomSQLite.db3");

            AppContext.RoomDatabase = new RoomDatabase(databaseFilePath);

            Room room1 = new Room { RoomName = "Room 1", Beacon = "Beacon1", Hue = "Hue1" };
            Room room2 = new Room { RoomName = "Room 2", Beacon = "Bed Room Beacon", Hue = "Bed Room Hue" };
            Room room3 = new Room { RoomName = "Room 3", Beacon = "Office Beacon", Hue = "Office Hue" };

            await AppContext.RoomDatabase.SaveItemAsync(room1);
            await AppContext.RoomDatabase.SaveItemAsync(room2);
            await AppContext.RoomDatabase.SaveItemAsync(room3);

            var blub = await AppContext.RoomDatabase.GetItemsAsync();
            var roomList = blub.ToList();
            Debug.WriteLine(roomList);

            //var blub2 = await AppContext.RoomDatabase.GetItemsAsync();
            //var roomList2 = blub2.ToList();
            //Debug.WriteLine(roomList2);

            //await AppContext.RoomDatabase.SaveItemAsync(room1);
            //await AppContext.RoomDatabase.SaveItemAsync(room2);
            //await AppContext.RoomDatabase.SaveItemAsync(room3);

        }

        protected override void OnStart()
        {
            InitDBAsync();
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
