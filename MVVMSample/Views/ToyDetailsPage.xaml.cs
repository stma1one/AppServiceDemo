using MVVMSample.ViewModels;
namespace MVVMSample.Views;

public partial class ToyDetailsPage : ContentPage
{
	public ToyDetailsPage()
	{
		InitializeComponent();
		BindingContext = new ToyDetailsPageViewModel();
	}
}