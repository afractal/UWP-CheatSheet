//--> for windows 10 apps use the Popup intead of the MessageDialog 
// also use more ContentDialog

//--> Shfaqja e textit me ane te nje "MessageDialog"

private async void Button_Click(object sender, RoutedEventArgs e)
{
    //Creating instance for the MessageDialog Class and passing the message in its Constructor  
    var dialog = new MessageDialog("Hello World");
    // or just | await new MessageDialog("Hi!");
    dialog.Title="Button Clicked Handler";
    //Calling the Show method of MessageDialog class which will show the MessageBox  
    await dialog.ShowAsync();
}

//Shfaqja e textit duke perdorur nje button dhe nje textbox

private void Button_Click(object sender,RoutedEventArgs e)
{
    myTextbox.Text = "Hello world";
}

//--> Perdorimi i nje MessageDialog ne nje menyre me te avancuar

private async void CancelCommandButton_Click(object sender, RoutedEventArgs e)
{
    // Create the message dialog and set its content
    var messageDialog = new MessageDialog("No internet connection has been found.");

    // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
    messageDialog.Commands.Add(new UICommand(
        "Try again", 
        new UICommandInvokedHandler(this.CommandInvokedHandler)));
    messageDialog.Commands.Add(new UICommand(
        "Close", 
        new UICommandInvokedHandler(this.CommandInvokedHandler)));

    // Set the command that will be invoked by default
    messageDialog.DefaultCommandIndex = 0;

    // Set the command to be invoked when escape is pressed
    messageDialog.CancelCommandIndex = 1;

    // Show the message dialog
    await messageDialog.ShowAsync();
}

private void CommandInvokedHandler(IUICommand command)
{
    // Display message showing the label of the command that was invoked
    rootPage.NotifyUser("The '" + command.Label + "' command has been selected.", 
        NotifyType.StatusMessage);
}


//--> Example
var ok = new UICommand("ok", x=>{//ToDo});
var cancel = new UICommand("cancel");

var dialog = new MessageDialog("message", "title");
dialog.Commands.Add(ok);
dialog.Commands.Add(cancel);
await dialog.ShowAsync();
