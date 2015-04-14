// Different Methods For Addresing Storage Locations

//--> File access using Windows.Storage API via URIs

// Installation Folder

ms.appx:///
// App data folder
ms-appdata:///local/
ms-appdata:///roaming/
ms-appdata:///temp/
// Example
var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/AppConfigSettings.xaml"));

//--> File access using Windows.Storage API via StorageFolder references

// Installation Folder

ApplicationModel.Package.Current.InstalledLocation
// App data folder

ApplicationData.Current
                             .LocalFolder /
                             .RoamingFolder /
                             .TempFolder
// Example

var localFolder = ApplicationData.Current.LocalFolder;

StorageFile storageFile = await localFolder.GetFileAsync("CaptainsLog.store");


//--> Windows.Storage.ApplicationData

// This namespace provides acces to the three storage folders in the app data
// store and the application settings containers:

// For file storage
StorageFolder roam = ApplicationData.Current.RoamingFolder;
StorageFolder local = ApplicationData.Current.LocalFolder;
StorageFolder temp = ApplicationData.Current.TemporaryFolder;

// For settings
ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;

// The StorageFolder object represents a folder and is used to acces the folder and itss contents
// The ApplicationDataContainer object represents a key-value pair settings dectionary

//--> Local Settings

// Create a simple settings
localSettings.Values["exampleSettings"] = "Hello Windows";

// Read data from a simple settings
Object value = localSettings.Values["exampleSettings"];

if(value == null)
{
    // No data
}
else
{
    //Access data in value
}

// Delete a simple settings
localSetting.Values.Remove("exampleSettings");

//--> Using the Roaming Settings

private void name_TextChange(object sender, TextChangedEventArgs e)
{
    ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;
    roamingSettings.Values["userName"]= name.Text;
}

// The Roaming Settings are exposed as a dectionary into which an application can save data
// The data is persisted on the device and also shared with other devices

//--> Reading the Roaming Settings

ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;

if(roamingSettings.Values.ContainsKey("userName"))
{
    name.Text= roamingSettings.Values["userName"].ToString();
}
// This code queries the roaming settings by using the key name
// The name will be reflected across multiple devices (including Windows 8.1 ones) 


//--> Example
// onNavigatedTo() method , write it on github
namespace AppDataTest
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var subfolder = await folder.CreateFolderAsync("MyFolder", CreationCollisionOption.OpenIfExists);
            var result = await subfolder.CreateFileAsync("MyFile.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(result, "lolz");
            var content = await FileIO.ReadTextAsync(result);
            myTextBlock.Text = content.ToString();
        }
    }

// namespace ends here
}
