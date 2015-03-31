// This must be coded in App.cs

// Managing the Suspending event in C# is really simple. The first thing that you need is an event handler in  App.xaml.cs:
// In the first line of code, you get an object of the SuspendingDeferral class in order to notify the OS that your
// operations ended in the last line of code. Now that you have an event handler,you can attach your handler to the event: 

this.Suspending += OnSuspending; 
// app is an instance of your application that you can refer to by using the this keyword 
// if you are working in  App.xaml.cs or 
// using the Current static property of the Application object: 

Application.Current.Suspending += OnSuspending; 
// SuspensionManager Saves State During Suspension
// Whenever the app is suspended, the SuspensionManager needs to save state such that it can get it back for the case
// where the app needs to restore itself after a termination.

// This is easy enough from a code perspective – I can edit the Application.OnSuspending handler that the templates 
// give me to ask the SuspensionManager to save its state to disk.
private async void OnSuspending(object sender, SuspendingEventArgs e)
{  
    var deferral = e.SuspendingOperation.GetDeferral();
    // you must have the SuspensionManager class in your project(often in common folder)
    await SuspensionManager.SaveAsync();
    deferral.Complete(); 
} 


// --> you can also create a suspension callback in MainPage
// this is particially useful when you want to save some items that are on the MainPage.xaml.cs like rootImage
public MainPage()
{
    this.InitializeComponent();
    App.Current.Suspending += Current_Suspending;
}

private async void Current_Suspending(object sender, SuspendingEventArgs e)
{
    var deferral = e.SuspendingOperation.GetDeferral();
    //rootImage.Source.....
    deferral.Complete();
}
    
