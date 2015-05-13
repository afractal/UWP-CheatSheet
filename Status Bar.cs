
// By default, Status Bar is visible and displays with a transparent background
// The background color that displays is that of the containing Page
// Can program the BackgroundColor and BackgroundOpacity
// There is no way to control the Status Bar in Xaml-code only

// Add the code on the OnLaunched method App.cs to display it on every page in the application

StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();

//---> 1. Show Status Bar
await statusBar.ShowAsync();
// This one line of code will show the status bar.


//---> 2. Hiding Status Bar
await statusBar.HideAsync();
// This one line of code will hide the status bar. You can write this code in the OnNavigateTo() method 
// to hide the status bar when the app launch.


//---> 3. Change the background color of Status Bar
statusBar.BackgroundColor = Colors.Red;
// This one line of code will change the Background color of the status bar.
// You can replace “Red” with any color of your choice.

// If you want to use the theme background
statusBar.BackgroundColor = (App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush).Color;
statusBar.BackgroundOpacity = 1;


//---> 4. Change the foreground color of Status Bar
statusBar.ForegroundColor= Colors.Red;
// This one line of code will change the Background color of the status bar.
// You can replace “Red” with any color of your choice.


//---> 5. Change Opacity of Status Bar
statusBar.BackgroundOpacity = 0.5;
// This one line of code will change the opacity of the status bar.


//---> 6. Gets the size of Status Bar
statusBar.OccludedRect; 


//---> 7. Using the status bar for the title of your app
// Set the text on the ProgressIndicator, and show it.
statusBar.ProgressIndicator.Text = "Amazing App";
statusBar.ProgressIndicator.ShowAsync();
// If the progress value is null (which is the default value), the progress indicator is in an 
// indeterminate state (dots moving from left to right).
// Set it to 0 if you don't wish to show the progress bar.
await statusBar.ProgressIndicator.ProgressValue = 0;


// If you want to make use of the Status Bar part of the screen, use this code in the "MainPage() constructor" 
// (or whatever page you are displaying):

ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);


//--> Progress Indicator in Status Bar
StatusBar.GetForCurrentView().ShowAsync();
var progInd = Status.GetForCurrentView().ProgressIndicator;
progInd.Text = "Fetching...";
progInd.ShowAsync();
