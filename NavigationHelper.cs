//--> SuspensionManager Meet Frame

Frame rootFrame = Window.Current.Content as Frame;  
  
// Do not repeat app initialization when the Window already has content,  
// just ensure that the window is active  
if (rootFrame == null)  
{  
  // Create a Frame to act as the navigation context and navigate to the first page  
  rootFrame = new Frame();  
  
  // MT: Register the Frame with the SuspensionManager.  
  SuspensionManager.RegisterFrame(rootFrame, "rootFrameKey");  //********
  .....
  
// What does the SuspensionManager actually do with this Frame?
// It effectively adds it onto a list such that it can get back to it at a later point in time.  

//--> SuspensionManager Restores Frame

// Having introduced the Frame to the SuspensionManager we can ask that SuspensionManager to attempt to restore the 
// Frame back to a state which it was in at the point where the operating system chose to terminate the application 
// without the user’s knowledge as part of the regular suspend/resume/terminate application lifecycle
// management that it performs.We’d only want to do this in that specific scenario where the app has been
// terminated and the template Application.OnLaunchedoverride already has a check in there for this condition;

if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)  
{  
  //TODO: Load state from previously suspended application  
}  

// and we can wire that up with our SuspensionManager by making an async method and making the call;
if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)  
{  
  //TODO: Load state from previously suspended application  
  await SuspensionManager.RestoreAsync();  
}  

// This call ends up being async because the SuspensionManager stores its state to disk so it’s going to be an
// async call on WinRT to get that state back. By making this call, one of the things we’re asking the SuspensionManager
// to do is to attempt to load from disk any Frame navigation history that it has stored and to put it back onto the
// right Frame via the SetNavigationState method on the Frame.

//--> Or you can do the MainPage_Loaded evet handler in main page (same result)

// On the contructor fire the loaded event
public MainPage()
{
  this.InitializeComponent();
  this.NavigationCacheMode = NavigationCacheMode.Required;  
  Loaded += MainPage_Loaded;
}

async void MainPage_Loaded(object sender, RoutedEventArgs e)
{
  SuspensionManager.RegisterFrame(MyFrame, "AppFrame");
  try{ await SuspensionManager.RestoreAsync(); }
  catch(SuspensionManagerException){ /* error */}
  MyFrame.Navigate(typeof(views.GrandParent) );
}
