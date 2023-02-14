namespace MyDocU.Client.Views;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViewModels;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

	private void btnLogin_Clicked(object sender, EventArgs e)
	{
		string userName = txtUserName.Text;
		string password = txtPassword.Text;
		if (userName == null || password == null)
		{
			DisplayAlert("Message", "Please Input Username & Password", "Ok");
			return;
		}
    }
}