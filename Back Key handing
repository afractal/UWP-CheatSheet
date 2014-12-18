// This Must be coded in app.cs

// Blank App does not include Back key handling but Hub App,Pivot App does
// Included in 
// /Common/NavigationHelper class
// Couses a backwards Page navigation
// If you need to override this, replace 
// with your own code for custom navigation handling

public App()
{
    this.InitializeComponent();
    this.Suspending += OnSuspending;
    // Initializing the method in the constructor
    HardwareButtons.BackPressed += HardwareButtons_BackPressed;
}

...
...

private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
{
    Frame frame = Window.Current.Content as Frame;
    if(frame==null)
        {
            return;
        }

    if(frame.CanGoBack)
        {
            frame.GoBack();
            e.Handled = true;
        }
}
