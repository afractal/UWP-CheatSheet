// So what can we customise? Most things thankfully. 
// The code below sets the text on the left to <app name> - My Custom Title.
// So it could be a good idea to update this each page of your app.

var applicationView = ApplicationView.GetForCurrentView();
applicationView.Title = "My Custom Title";


// The most likely thing we're going to want to do is customise the colours.
// We can do that using the TitleBar property of ApplicationView.

var applicationView = ApplicationView.GetForCurrentView();
var titleBar = applicationView.TitleBar;

titleBar.BackgroundColor = (Color) Resources["SidebarBackgroundColor"];
titleBar.ForegroundColor = Colors.White;

titleBar.ButtonBackgroundColor = (Color) Resources["LightSidebarBackgroundColor"];
titleBar.ButtonForegroundColor = Colors.White;


// A third option is to remove the title bar altogether for that chrome-less look.
// We can use the ExtendViewIntoTitleBar property.

var applicationView = ApplicationView.GetForCurrentView();
var titleBar = applicationView.TitleBar;

titleBar.ExtendViewIntoTitleBar = true;

titleBar.ButtonBackgroundColor = (Color) Resources["LightSidebarBackgroundColor"];
titleBar.ButtonForegroundColor = Colors.White;
