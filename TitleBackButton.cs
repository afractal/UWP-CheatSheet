// adding and removing a title bar back button

protected override void OnNavigatedFrom(NavigationEventArgs e)
{
    var currentView = SystemNavigationManager.GetForCurrentView();
    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
    currentView.BackRequested -= CurrentView_BackRequested;
}

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    var currentView = SystemNavigationManager.GetForCurrentView();
    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
    currentView.BackRequested += CurrentView_BackRequested;

    var feedData = e.Parameter as FeedData;
    reuseFeedData = feedData;
    this.DataContext = feedData;
}

private void CurrentView_BackRequested(object sender, BackRequestedEventArgs e)
{
    var frame = Window.Current.Content as Frame;
    if (frame != null && frame.CanGoBack)
    {
        Frame.GoBack();
        e.Handled = true;
    }
}
