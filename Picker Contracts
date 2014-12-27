//--> Picker Contracts-Pick a File

private void myPickPhotoButton_ClickEventHandler(object sender, RoutedEventArgs e)
{
  // Create the picker object
  FileOpenPicker openPicker = new FileOpenPicker();
  openPicker.ViewMode = PickerViewMode.Thumbnail;
  openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

  // Users expect to have a filtered view of their folders
  openPicker.FileTypeFilter.Add(".bmp");
  openPicker.FileTypeFilter.Add(".jpg");
  openPicker.FileTypeFilter.Add(".jpeg");
  openPicker.FileTypeFilter.Add(".png");

  // Open the picker for the user to pick a file
  openPicker.ContinuationData["Operation"]= "SomeDataOrOther"
  openPicker.PickSingleFileAndContinue();
}
// App suspended, may be terminated
                 |
App activated when file picked


//--> Activation after File Picker

// 1 of 2- App.cs

protected override async void OnActivated(IActivatedEventArgs args)
{
  if(args is FileOpenPickerContinuationEventArgs)
    {
      Frame rootFrame= Windows.Current.Content as Frame;
      
      ... // Standard Frame initialization code ...
      
      if(!rootFrame.Navigate(typeof(ProfilePage)))
        {
          throw new Exeption("Failed to create target page");
        }

      var p= rootFrame.Content as ProfilePage;
      p.FilePickerEvent= (FileOpenPickerContinuationEventArgs)args;

      // Ensure the current windows is active
      Window.Current.Activate();
    }
}


// 2 of 2- Page where picker was initiated

private FileOpenPickerContinuationEventArgs _filePickerEventArgs= null;
public FileOpenPickerContinuationEventArgs FilePickerEvent
{
  get{ return _filePickerEventArgs; }
  set{
     _filePickerEventArgs= value;
     ContinueFileOpenPicker(_filePickerEventArgs); }
}

public async void ContinueFileOpenPicker(FileOpenContinuationEventArgs)
{
  if((args.ContinuationData["Operation"] as string)== "SomeDataOrOther" && args.Filer != null && args.Files.Count > 0)
  {
    StorageFile file = Args.Files[0];
    IRandomAccesStream fileStream= await file.OpenAsync(Windows.Storage.FileAccesMode.Read);
    BitmapImage bitmapImage = new BitmapImage();
    bitmapImage.SetSource(fileStream);
    ProfilePic.Source = bitmapImage;
  } 
}


//--> Save a File

// Create the picker object
FileSavePicker savePicker = new FileSavePicker();

// Dropdown of file types the user can save the file as
savePicker.FileTypeChoices.Add("Plain Text",new List<string>(){ ".txt" });
// Default file name if the user does not type one in or select
// a file to replace
savePicker.SuggestedFileName = "New Document";

// Open the picker for the user to pick a file
savePicker.ContinuationData["Operation"] = "SomeDataOrOther";
savePicker.PickSingleFileAndContinue();

// App suspended, may be terminated
                 |
// App actiavted when file picked

