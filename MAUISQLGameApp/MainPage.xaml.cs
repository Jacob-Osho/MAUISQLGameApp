namespace MAUISQLGameApp;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Navigation.PushAsync(new GamePage(btn.Text));
    }

    private void PreviouseGamesButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PreviouseGamesPage());
    }
}

