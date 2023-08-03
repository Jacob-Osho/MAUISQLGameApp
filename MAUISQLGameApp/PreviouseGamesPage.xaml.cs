namespace MAUISQLGameApp;

public partial class PreviouseGamesPage : ContentPage
{
    public PreviouseGamesPage()
    {
        InitializeComponent();
        gamesList.ItemsSource = App.GameRepository.GetAllData();


    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        App.GameRepository.DeleteGame( (int)btn.BindingContext);
        gamesList.ItemsSource = App.GameRepository.GetAllData();
    }
}