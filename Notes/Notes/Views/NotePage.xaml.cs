

namespace Notes.Views;

//Adding the queryProperty attribute to the class keyword, providing the name of the query string
//property, and the class property it maps to, ItemId and ItemId Respectivly
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    // The below line constructs a path to the file, storing it in the app's local data directory.
    // the file name is notes.txt
    //combine method below just combines 2 strings into a path
    //string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

	//new string property named ItemId
	// this property calls the LoadNote method, passing the value of the property
	// which in turn should be the filename of the note.
    public string ItemId
    {
        set { LoadNote(value); }
    }



    //Constructor of the notePage class
    public NotePage()
	{
		InitializeComponent();

		string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		// path.getRandomFileName just gets a random file?
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
		//our created method
		LoadNote(Path.Combine(appDataPath,randomFileName));

		//old 
		//if (File.Exists(_fileName))
		//{
		//	read the file from the device and store it within the < Editor >/ TextEditor control's text property
		//	TextEditor.Text = File.ReadAllText(_fileName);
		//}

	}

	


	//METHODS ------------------------

	public void LoadNote(string fileName)
	{
		Models.Note noteModel = new Models.Note();
		noteModel.Filename = fileName;

		if (File.Exists(fileName))
		{
			noteModel.Date = File.GetCreationTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}

		BindingContext = noteModel;
	}



    //BUTTONS --------------------------

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }


    //old
    /*private void SaveButton_Clicked(object sender, EventArgs e)
	{
		//save the file
		File.WriteAllText(_fileName, TextEditor.Text);
	}

	private void DeleteButton_Clicked(object sender, EventArgs e)
	{
		//delete the file
		if (File.Exists(_fileName))
		{
			File.Delete(_fileName);
		}
		// empty control text property 
		TextEditor.Text = String.Empty;
	}*/



    //handle click events





}