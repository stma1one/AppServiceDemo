using MVVMSample.Views;

namespace MVVMSample
{
    public partial class App : Application
    {
        public App(LoginPage page)
        {
            InitializeComponent();
            //שינוי הצבעה ל 
            //SHELL
            MainPage = page;
        }
    }
}
