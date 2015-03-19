//---> How to Send SMS in Windows Phone 8.1 XAML(Windows Runtime) App ?

// If you are targeting the Windows Phone 8.1 XAML App(Windows Runtime App) , 
// you can use the ChatMessage class defined in the Windows.ApplicationModel.Chat namespace.
// Below is a sample code snippet demonstrating how to send SMS from a Windows Phone 8.1 App.

async private void Button_Click(object sender, RoutedEventArgs e)
{
    ChatMessage chat = new ChatMessage();
    chat.Body = "Subject : This is a Test SMS from MobileOSGeek.com";
    chat.Recipients.Add("000000");
    await Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(chat);
}


//---> How to make a Phone Call in Windows Phone 8.1 XAML App ?

// If you are targeting the Windows Phone 8.1 XAML App (Windows Runtime App) ,
// you can use the ShowPhoneCallUI static method that is defined in the PhoneCallManager class .
// Below is a method that demonstrates how to show the Phone Call UI / Dialler programmatically from your app.

// Make a phone call using the PhoneCallManager in Windows Phone 8.1 WinRT App
public void MakePhoneCall(string PhoneNumber,string DisplayName)
{
   Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(PhoneNumber, DisplayName);
}

// When the above method is called by passing the phone number and the display name as shown below ,
// you will see the Phone Call UI.
MakePhoneCall("0000000000", "Senthil Kumar");


//--->How to Programatically Send Emails with attachment in Windows Phone 8.1 Apps ?

// The Windows Phone 8.1 SDK provides an option for the developer to send emails with attachment
// using the EmailMessageand EmailManager class .

//Note that the Minimum supported phone version for the EmailMessage and the EmailManager is Windows Phone 8.1  .
// 1. EmailMessage
// The EmailMessage class defines the actual email that will be sent.
// You can specify the recipients (To , CC , BC) , Subject and the Body of the email .
// 2. EmailManager
// The EmailManager class is defined in the Windows.ApplicationModel.Email namespace .
// The EmailManager class provides a static method ShowComposeNewEmailAsync which accepts the EmailMessage as argument .
// The ShowComposeNewEmailAsync will launch the Compose email Screen with the EmailMessage
// which allows the users to send an email message.

// Step 1 : Lets create a file called “mobileosgeek.txt” within your application and return it .
// This will be the file that will be attached with the email.

//Below is a sample code snippet on how to create a text file programmatically in Windows Phone 8.1.

// Creates a text file and returns it
private static async Task<StorageFile> GetTextFile()
{
     var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
     var file = await localFolder.CreateFileAsync("mobileosgeek.txt", 
                                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
     await Windows.Storage.FileIO.WriteTextAsync(file, "This is a MobileOSGeek File");
     return file;
}

// Step 2 : The next step would be create the instance of the EmailMessage and prepopulate the necessary fields.
// Lets attach the file that we received from the GetTextFile().

// Send an Email with attachment
EmailMessage email = new EmailMessage();
email.To.Add(new EmailRecipient("test@mobileosgeek.com"));
email.Subject = "Blog post by @isenthil";
var file = await GetTextFile();
email.Attachments.Add(new EmailAttachment(file.Name, file));
await EmailManager.ShowComposeNewEmailAsync(email);

// Step 3 : When the EmailManager.ShowComposeNewEmailAsync method is called ,
// You will be listed with the apps / email accounts that are configured on your phone .
// Select the email account from which you need to send email from .

// Step 4 : This will display the Email Compose Dialog with the screen already filled with
// the EmailMessage data that was passed to the ShowComposeNewEmailAsync method.
// Clicking on the Send button in the application bar will send the email with the attachment .


//--> Example
// sending te content of file via email,  write it on github
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        this.NavigationCacheMode = NavigationCacheMode.Required;
    }

    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        var folder = ApplicationData.Current.LocalFolder;
        var subfolder = await folder.CreateFolderAsync("MyFolder", CreationCollisionOption.OpenIfExists);
        var file = await subfolder.CreateFileAsync("MyFile.txt", CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteTextAsync(file, "lolz");
        var content = await FileIO.ReadTextAsync(file);

        EmailMessage email = new EmailMessage();
        email.Subject = "File is Attached";
        email.To.Add(new EmailRecipient("hermesxgjini@gmail.com") );
        email.Attachments.Add(new EmailAttachment(file.Name, file) );
        await EmailManager.ShowComposeNewEmailAsync(email);
    }
}
