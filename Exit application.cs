// to exit from an application just write the following code to the main page

public MainPage()
{
    this.InitializeComponent();
    this.NavigationCacheMode = NavigationCacheMode.Required;
    
    HardwareButtons.BackPressed += HardwareButtons_BackPressed;
}

// define the page name you want to exit in the -> "YourApp.MainPage"
// if the page name is equal to the current page than it exits overwise it doesn't
private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
{
    if (!e.Handled && Frame.CurrentSourcePageType.FullName == "YourApp.MainPage")
        Application.Current.Exit();
}

// or if you want to encapsulate the action within a button use the below method
// this is useful when your are using it as an appbar button, also it is much easy to do

private void closeButton_Click(object sender, RoutedEventArgs e)
{
    Application.Current.Exit();
}
