// Uri association
Windows.System.Launcher.LaunchUriAsync(new Uri("jumpstart:NewSession?ID=aea6"));

// File association
Windows.System.Launcher.LaunchFileAsync(myStorageFile);

// Share contract
Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();

//--> Custom URI Associantions

// Launch other apps to complete tasks
// Launch another app and pass it data
// Play an album on Spotify
// Play a video in YouTube
// Launch device settings

// Link into core experiences
// Browser(http)
// Messaging
// Email(mailto:)

await Launcher.LaunchUriAsync(new Uri("fb://profile/1234"))

//--> File Type Associations

// Launch files in the right app
// Microsoft Office
// Adobe Reader

// Handle custom files in your app from
//Another app
//Browser
//Email
//Office Hub

var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata://Local/mydoc.pdf"));
await Launcher.LaunchFileAsync(file);


// This must be coded in app.cs

//--> Handling File Activation(Windows Runtime Apps)

protected override async void OnFileActivated(FileActivatedEventArgs args)
{
  // Handle file actication. The number of files received is args.Files.Size. First file is args.Files[0].Name 
  Frame rootframe= Window.Current.Content as Frame;

  ... // Standard Frame initialization code ...

  if(rootframe.Content==null)
  {
    if(!rootFrame.Navigate(typeof(BugQueryPage))){ throw new Exception("Failed to create initial page");}
  }
  
  var p= rootFrame.Content as BugQueryPage;

  // Pass the File Activation args to a property you've implemented on the target page
  p.FileEvent= args;

  Windows.Current.Activate();
} 

//--> Handiling Uri Activation(Windows Runtime Apps)

public partial class App
{
   ... 
  protected override void OnActivated(IActivatedEventArgs args)
  {
    if (args.Kind == ActivationKind.Protocol)
      {
        ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;
        
        // TODO: Handle URI activation
        // The received URI is eventArgs.Uri.AbsoluteUri 
        ... 
      } 
   }
 ... 
} 

//--> Implementing share source

protected override void OnNavigatedTo(NavigationEventArgs e)
{
  navigationHelper.OnNavigatedTo(e);
  DataTransferManager.GetForCurrentView().DataRequested += OnShareDataRequested;
}

protected override void OnNavigatedFrom(NavigationEventArgs e) 
{
  navigationHelper.OnNavigatedFrom(e);
  DataTransferManager.GetForCurrentView().DataRequested -= OnShareDataRequested; 
}

 private void AppBarButton_Click(object sender, RoutedEventArgs e) 
{
  DataTransferManager.ShowShareUI();
}
 
// ! Always remove your event handlers
// Always tear down your event handlers when you’re done with them

//--> Implementing share source vazhdim

// Handle DataRequested event and provide DataPackage
void OnShareDataRequested(DataTransferManager sender, DataRequestedEventArgs args) 
{
	var deferral = args.Request.GetDeferral();
   	var request = args.Request; 

	 request.Data.Properties.Title = "Share example";
   	//You MUST set a Title!
  	request.Data.Properties.Description = "This demonstrates how to share text to another app";
  	request.Data.SetText(TextToShare.Text.Trim()); 
  	deferral.Complete();
}

// Title
// You must set a Title on the Data Package.
// If you do not, the Share operation silently fails (no exception).
// Description
// Not used by the Share UI on Windows Phone (used by the Windows Share UI), but is available to the Share target.


//--> Share Contract in windows phone 8.1
private void ShareButton_Click(object sender, RoutedEventArgs e)
{
	var manager = DataTransferManager.GetForCurrentView();
	manager.DataRequested += DataTransferManager_DataRequested;
	DataTransferManager.ShowShareUI();
}

// if you want to share a text
private void DataTransferManager_DataRequested(DataTranferManager sender, DataRequestesEventArgs e)
{
	e.Request.Data.Properties.Title="Share Contract";
	e.Request.Data.setText("Hello World");
	// there are more methods like setText, look it up
}

// or if you want to share a BitmapImage
namespace ProjectAve
{

    public sealed partial class MainPage : Page
    {
        StorageFile file;
        BitmapImage bitmap = new BitmapImage();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void shareButton_Click(object sender, RoutedEventArgs e)
        {
            var manager = DataTransferManager.GetForCurrentView();
            manager.DataRequested += manager_DataRequested;
            DataTransferManager.ShowShareUI();
        }

        private void manager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            args.Request.Data.Properties.Title = "Share Contracts!";
            args.Request.Data.Properties.Description = "description";

            if (args != null)
                args.Request.Data.SetBitmap(RandomAccessStreamReference.CreateFromFile(file));
            else
                args.Request.FailWithDisplayText("Select an image first !");
        }

        private async void uploadButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".gif");
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.ViewMode = PickerViewMode.Thumbnail;

            file = await openPicker.PickSingleFileAsync();
            IRandomAccessStream filestream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            await bitmap.SetSourceAsync(filestream);
            rootImage.Source = bitmap;
        }
    }

// namespace ends here
}
