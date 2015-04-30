// use this technique to give an UI context for the time of the task being worked on

// showing progress during async operation
private async void DisplayButton_Click(object sender, RoutedEventArgs e)
{
    myProgressRing.IsActive = true;
    var result = await DeviceInformation.FindAllAsync(DeviceClass.All);
    foreach (var item in result)
    {
        await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            myListView.Items.Add(item.Name);
        });
    }
    myProgressRing.IsActive = false;
}


