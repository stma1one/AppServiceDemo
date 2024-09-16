using MVVMSample.Views;

namespace MVVMSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //שינוי הצבעה ל 
            //SHELL
            MainPage = new LoginPage();
        }
    }
}
