//---> How to display external web page with in a Windows Phone 8.1 App ?

// 1. Simply add the WebView control to the page from the toolbox or by adding the below tag .
// Provide a name to the WebView control . In this example , the control name is provided as “MobileOSGeekView”.

<Grid>
  <WebView x:Name="MobileOSGeekView">   
  </WebView>
</Grid>

// 2. Use the Navigate method of the WebView object by providing the necessary Uri which you need to display in a WebView.

private void LaunchMobileOSGeekWebsite()
{
   Uri NavigateUrl = new Uri(@"http://www.MobileOSGeek.com");
   // Navigate to the MobileOSGeek website within the webview
   MobileOSGeekView.Navigate(NavigateUrl);
}

// 3. When you call the above method , you will see the external webpage being loaded in to the WebView control of the page.
