

using MVVMSample.ViewModels;

namespace MVVMSample.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		this.BindingContext = new LoginPageViewModel();
		InitializeComponent();
		
	}
}