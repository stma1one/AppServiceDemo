
using MVVMSample.ViewModels;

namespace MVVMSample.Views;

public partial class ViewToysPage : ContentPage
{
	public ViewToysPage()
	{
		InitializeComponent();
		BindingContext = new ViewToysPageViewModel();
		
	}
  //  protected override void OnAppearing()
  //  {
  //      base.OnAppearing();
		//var vm=this.BindingContext as ViewToysPageViewModel;
		//if (vm != null)
		//{
		//	 vm.RefreshCommand.Execute(null);
		//}
  //  }
}