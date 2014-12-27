//--> Writing a background task

// You need to declare them in the manifest
// NB: This is a WinRT component built in C#.Need to make a WinRT component project.
// Need to follow WinRT type system rules (e.g public members need to comply with 
// the WinRT type system ).

public sealed class TheTask : IBackgroundTask
{
  // Only one method to implement here.
  
  public async void Run(IBackgroungTaskInstance instance)
  {
    // Get a deferral if we're doing async work.
    var deferral = instance.GetDeferral();

    // Background Task infrastructure can send a Cancelation notification
    // if task is idle or hung, but if memory cap i execeeded,
    // task can be terminated without notification,
    // Your task needs to be resilient to rude terminations 
    // without a Canceled event firing.
    
    // Should do something to handle cancellation.
    instance.Canceled += (s, e)=> {};
    
    // Report progress to a foreground app if there and listening.
    instance.Progress = 0;

    // More properties avaible on IBackgroundTAskInstance -
    // InstanceId, TriggerDetails, SuspendedCount, Task
    
    deferral.Complete();
  }
} 


// Execution = Trigger + [Condition]

// Tasks run in response to triggers
// Triggers :
/* SystemTrigger, TimeTrigger, LocationTrigger, MaintanceTrigger, PushNotificationTrigger,
  RfcommConnetionTrigger, DeviceChangeTrigger, BluetoothSignalStrengthTrigger, GattCharacteristicNotificationTrigger,
  SessionStart, ControlChannelTrigger(), ServicingComplete, SessionConnected, SessionDisconnected, SmsReceives,
  TimeZoneChange, UserrAway/UserPresent, LockScreenApplicationAdded/Removed, InternetAvailable/InternetNotAvaible,
  NetworkStateChange, NetworkNotificationChannelReset */
  
// You can also add an condition
// Conditions:
/* InternetAvailable, InternetNotAvailable, SessionConnected, SessionDisconnected, UserNotPresent, UserPresent */

BackgroundTaskBuildr taskBuilder = new BackgroundBuilder();

// my task need the internet...
taskBuilder.AddCondition(new SystemCondition(SystemConditionType.InternetAvaible));


//--> Requesting background task access

async void RegisterBackgroundTasks()
{
  // On Windows, RequestAccessAsync presents the user with a confirmation
  // dialog that requests that an app be allowed on the lock screen.
  // On Windows Phone, RequestAccesAsync does not show any user confirmation UI
  // but *must* be called before registering any tasks
 
  var access = await BackgroundExecutionManager.RequestAccessAsync();
  
  // A 'good' status return on Phine is Background.AllowedMayUseActiveRealTimeConnectivity
  
  if(access == BackgroundAccessStatus.Denied)
  {
    // Either the user has explicitly denied background execution for this app
    // or the maximum number of background apps across the system has been reached
    // Display some informative message to the user...
  } 
}


//--> Registering a background task

BackgroundTaskBuilder taskBuilder = new BackgroundTasksBuilder();
taskBuilder.Name = "MyBackgroundTask";

// Many different triggers types could be used here
SystemTrigger trigger = new SystemTrigger(SystemTriggerType.TimeZoneChange, false);
taskBuilder.SetTrigger(trigger);
taskBuilder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));

// Entry point is the full name of our IBackgroundTAsk implementation
// Good practice to use reflection as here to ensure correct name
taskBuilder.TaskEntryPoint = typeof(MyBackgroundTask.TheTask).FullName;

BackgroundTaskRegistration registration = taskBuilder.Register();

// Optionally, handle the progress/completed events of the task
registration.Progress += registration_Progress;
registration.Completed += registration_Completed;


//--> Querying task registrations

// AllTasks is a dictianary <Guid, IBackgroundTAskRegistration> so you can get back
// to your registration by id or by position, or select First if you only have one registration.
var taskRegistration = BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault();

// We could then unregister the task, optionally cancelling any running instance
if(taskRegistration != null)
{
  taskRegistration.Unregister(true);
}

// Release the progress/completed event subcriptions
registration.Progress -= registration_Progress;
registration.Completed -= registration_Completed;
