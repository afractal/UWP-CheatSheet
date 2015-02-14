// Add a reference to the ShakGesturesLibraryRuntime which is the new version that supports winRT 8.1
// you can do that by clicking on the right mouse and choose Manage NuGet Packages, after that write Shake Gesture 
// on the searchbox and click ok, install it and it is done.

namespace ThirdTest
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            
            ShakeGesturesHelper.Instance.ShakeGesture += Instance_ShakeGesture;
            ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 5;
            ShakeGesturesHelper.Instance.Active = true;
        }

        async void Instance_ShakeGesture(object sender, ShakeGestureEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame.Navigate(typeof(TheShakenPage) );
            });
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e){  }
    }

// namespace ends here
}
