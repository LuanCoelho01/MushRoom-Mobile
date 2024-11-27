using MushRoom.Helpers;
using MushRoom.Views;

namespace MushRoom
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper _db;


        public static SQLiteDataBaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "fornecedor.db3");

                    _db = new SQLiteDataBaseHelper(path);
                }

                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            //Current.MainPage.Navigation.PushAsync(new Login());

            MainPage = new NavigationPage(new Views.Login())
            {
               BarBackgroundColor = Colors.Chocolate
            };
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;


            return window;
        }
    }
}
