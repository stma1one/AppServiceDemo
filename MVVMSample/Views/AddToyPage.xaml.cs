using MVVMSample.Models;
using MVVMSample.ViewModels;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace MVVMSample.Views;

public partial class AddToyPage : ContentPage
{
	
    public AddToyPage()
	{
        
		InitializeComponent();
        BindingContext = new AddToysPageViewModel();
       
	}




    
       
}