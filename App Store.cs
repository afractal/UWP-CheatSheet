//---> How to Launch the Rate and Review Page from Windows Phone 8.1 App ?

// Below is a sample code snippet that uses the Windows.System.Launcher.LaunchUriAsync
// method to launch the Rate and Review Page from the Windows Phone App.

private async void Button_Click(object sender, RoutedEventArgs e)
{
  await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId));
}
