using Notes.Models;

namespace Notes.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}





    //Notice that the async keyword was added to the method declaration,
    //which allows the use of the await keyword when opening the system
    //browser
    //private void LearnMore_Clicked(object sender, EventArgs e)
    //{

    //}
    private async void LearnMore_Clicked(object sender, EventArgs e)
	{
        // the below if checks if the BindingContext is Models.About and if it is assigns
        // its assigned to the about variable..    <-- not bad gramar that is how it is written in the documentation
        if (BindingContext is Models.About about)
        {
            //navigate to the specified URL in the system browser
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
        
	}
}