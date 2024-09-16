using MVVMSample.Views;
using System.Windows.Input;

namespace MVVMSample
{
    public partial class AppShell : Shell
    {
      public ICommand LogoutCommand
        {
            get; private set;   
        }
        public AppShell()
        {
            InitializeComponent();
            BindingContext=this;    
            #region רישום מסכים פנימיים
            Routing.RegisterRoute("Details", typeof(ToyDetailsPage));
            LogoutCommand=new Command(async()=> await this.DisplayAlert("טרם פותח", "טרם פותח", "ביטול"));
            #endregion
        }

        
    }
}
