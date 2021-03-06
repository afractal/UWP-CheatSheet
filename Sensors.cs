// There are a lot of sensors: Accelerometer, Compass, Inclinometer, Gyrometer, Device Orientation, Light Sensor

//--------------------->Gyrometer<-------------------

//--> Determining Sensor Availability

// Determine whether we have a gyro on the phone
_gyrometer= Gyrometer.GetDefault();

if(_gyrometer != null)
{
  // Establish the report interval (units are milliseconds)
  _gyrometer.reportInterval = 100;
  _gyrometer.ReadingVhanged += _gyrometer_ReadingChanged;
}
else
{
  MessageBox.Show("No gyrometer found");
}
// All the sensor classes have a GetDefault() method
// This methos only returns a non-null value if the hardware is avaible on the device


//---> Activating and Deactivating a Sensor

// Establish the report (units are milliseconds)
uint reportInterval = 100;
if(_gyrometer.MinimumReportInterval > reportInterval)
{
  reportInterval = _gyrometer.MinimumReportInterval;
}

_gyrometer.ReportInterval = reportInterval;

// Application must set the report interval to a non-zero value
// prior to registering an event handler or calling
// GetCurrentReading() to activate it
// When finished with the sensor, set it to zero


//---> Using the SEnsor ReadingChanged event

_gyrometer.ReportInterval = 100;
_gyrometer.ReadingChanged += _gyrometer_ReadingChanged;
// ...

private void _gyrometer_ReadingChanged(Gyrometer sender, GyrometerReadingChangedEventArgs args)
{
  await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
  {
    GyrometerReading reading = args.Reading;
    X_Reading.Text = String.Format("{0,5:0.00}", reading.AngularVelocityX);
    Y_Reading.Text = String.Format("{0,5:0.00}", reading.AngularVelocityY);
    Z_Reading.Text = String.Format("{0,5:0.00}", reading.AngularVelocityZ);
  });
}
// Register the ReadingChanged event handler to obtain sensor readings
// Must set the ReportInterval property first


//---> Getting Readings By Polling a Sensor

// Altenative to ReadingChanged event, call GetCurrentReading() to poll the sensor
GyrometerReading reading = _gyrometer.GetCurrentReading();

if(reading != null)
{
  X_Reading.Text = String.Format("{0,5:0.00}", reading.AngularVelocityX);
  Y_Reading.Text = String.Format("{0,5:0.00}", reading.AngularVelocityY);
  Z_Reading.Text = String.Format("{0,5:0.00}", reading.AngularVelocityZ);
}

// Aa appliccation can poll the sensor for the current reading as an altenative
// to registering a ReadingChanged event handler
// The preferred altenative for an application that updates its user interface at a specific frame rate
// Must still establish a desired ReportInterval before polling in order to
// activate the sensor.


//--------------------->Accelerometer<-------------------

namespace ShakeFeatureTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            SensorAvaibility();
            Meth();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs args){ }

        private Accelerometer sensor;

        public async void SensorAvaibility()
        {
            sensor = Accelerometer.GetDefault();
            if (sensor != null)
            {
                sensor.ReportInterval = 100;
                sensor.ReadingChanged += sensor_ReadingChanged;
            }
            else
                await new MessageDialog("Accelerometer not found!").ShowAsync();
        }

        public void Meth()
        {
            uint reportInterval = 100;
            if (sensor.MinimumReportInterval > reportInterval)
            {
                reportInterval = sensor.MinimumReportInterval;
            }
            sensor.ReportInterval = reportInterval;
        }

        async void sensor_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                AccelerometerReading reading = args.Reading;
                corX.Text = String.Format("{0,5:0.00}", reading.AccelerationX);
                corY.Text = String.Format("{0,5:0.00}", reading.AccelerationY);
                corZ.Text = String.Format("{0,5:0.00}", reading.AccelerationZ);
            });
        }
    }

// namespace ends here
}


//--------------------->Compass<-------------------

using Windows.Devices.Sensors; 

private void OnGetDataButtonClick(object sender, RoutedEventArgs e)        
{            
  var compass = Compass.GetDefault();            
  if (compass == null)
  { 
    this.DefaultViewModel["CompassData"] =
    new    
     {
       MagneticNorth = "Compass not found",
       TrueNorth= "Compass not found",
       Accuracy = "Compass not found"                
     }; 
  }
  else
  {   var reading = compass.GetCurrentReading();
      compass.ReadingChanged += OnCompassReadingChanged;
       SetCompassReading(reading);
  } 
}


private void SetCompassReading(CompassReading reading)
{
  this.DefaultViewModel["CompassData"] =
  new
  {
    MagneticNorth = reading.HeadingMagneticNorth,
    TrueNorth = reading.HeadingTrueNorth,
    Accuracy = reading.HeadingAccuracy
  };
}


 private void OnCompassReadingChanged(Compass sender, CompassReadingChangedEventArgs args)
 {
   SetCompassReading(args.Reading);
 }
