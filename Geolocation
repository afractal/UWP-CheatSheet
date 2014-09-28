/* To show a map in XAML, you can use the Bing Maps SDK for Windows 8.1 Store apps (because this SDK adds a control for XAML),
 which is available here: http://visualstudiogallery.msdn.microsoft.com/224eb93a-ebc4-46ba-9be7-90ee777ad9e1
 Before you can use Map control in your app, you need a Bing Maps key that you can get in this way:
 1. Connect to http://www.bingmapsportal.com/.
 2. Log on with a Windows Live account.
 3. Create a new Bing Maps key. Don’t worry about the application name; you can use a key on every app.
 4. Inside the App.xaml file, create a resource identified by the BingCredentials key in this way:
 <x:String x:Key="BingMapKey">your key</x:String>, where “your key” is the  Bing Maps key created before.
 This is a good practice if your app uses this control in  other pages,
 and it is a good way to keep only information about how to draw the view inside the XAML. */
 
/* After the installation, add a reference to Bing Maps so you can import the Bing.Maps namespace into your code
 If your solution is configured to build for Any CPU, your project won’t compile and will notify you that something has gone wrong 
 You must import the Bing.Maps namespace inside the page of your app where you want to add the Map control.
 You can do so by adding the bold XAML as an attribute of the Page element in XAML:   xmlns:maps="using:Bing.Maps"
 In this way, you have imported the Bing.Maps namespace, and then you are ready to add the Map control on your user interface (UI).
 You will do it using the map element that you can find in the maps namespace (that you have imported): 
 <maps:Map x:Name="MapControl" Credentials="{StaticResource BingMapKey}" ShowBuildings="False" />  */
 
// To declare that your application will use Location capability,
//you must open the app manifest and,  in Capabilities tab, check Location


//--> How to get the current location

Geolocator geolocator = new Geolocator();
geolocator.DesiredAccuracyInMeters = 50;
// DesiredAccuracy property, which you can use to express the accuracy needed by your app
try
{
  Geoposition geoposition = await geolocator.GetGeopositionAsync(
      maximumAge: TimeSpan.FromMinutes(5),
      timeout: TimeSpan.FromSeconds(10) );
  
  LatitudeTextBlock.Text = geoposition.Coordinate.Latitude.ToString("0.00");
  LongitudeTextBlock.Text = geopositon.Coordinate.Longitude.ToString("0.00");
}
catch(UnauthorizedAccesException)
{
  // the app does not have the right capability or the location master switch is off
  StatusTextBlock.Text = "location is disabled in phone settings.";
}


//--> How to track location

private void TrackLocation_Click(object sender, RoutedEventArgs e)
{
  if(!tracking)
    {
      geolocator = new Geolocator();
      geolocator.DiredAccuracy = PositionAccuracy.High;
      geolocator.MovementThreshold = 100; // The units are meters.
      // MovementThreshold property, which you can set to specify the threshold before the PositionChanged event fires

      geolocator,StatusChanged += geolocator_StatusChanged;
      geolocator.PositionChanged += geolocator_PositionChanged;
      tracking = true;     
    }
  else
    {
geolocator.PositionChanged -=geolocator_PositionChanged;
geolocator.StatusChanged -= geolocator_StatusChanged;
geolocator = null;
tracking false;
    }
}

