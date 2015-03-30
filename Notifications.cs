// Lots of ways to display notifications
// 1- Tile
// 2- Badge
// 3- Toast
// 4- Raw(background task)
// For Toast Notifications we must enable toast in the manifest


//---> Send a toast notification

<toast>
  <visual>
    <binding template="ToastText02">
      <text id="1">headline text</text>
      <text id="2">body text</text>
    </binding>
  </visual>
</toast>

// User taps on toast notification to launch app

//Loats of ways to send notifications
// 1- Scheduled
// -Set tile template and time
//  ScheduledTileNotification
//  ScheduledTileNotification

// 2- Periodic
// pull from URL every half hour/hour/6 hours/12 hours/day

// 3- Local
// Update from within application(foreground or background)

// 4- Push
// Using WNS Push Services


//---> Schendules updates

var scheduleToast = new ScheduledToastNotification(
                        xmlDoc,
                        DateTimeOffset.UtcNow + TimeSpan.FromDays(1.0) );
var toastNotify = ToastNotificationmanager.CreateToastNotifier();
toastNotify.AddToSchedule(scheduleToast);


//---> Periodic Updates

var periodic = TileUpdateManager.CreateTileUpdaterForApplication();
Uri myTileFeed = new Uri("http://mysite.com/tileRSS.xml");
periodic.StartPeriodicUpdate(myTileFeed, PeriodicUpdateRecurrence.Hour);

//  or the easy way

// 1- Open Package.appxmanifest
// 2- Select Recurrence
// 3- Select Template


//---> Local Updates

BadgeNotification newBadge = new BadgeNotification(badgeDoc);
BadgeUpdater update = BadgeUpdateManager.CreateBadgeUpdaterFroApplication();
update.Update(newBadge);


//---> WNS Platform Options

Notification type || Schedules || Local || Push ||
Tile              || yes       || yes   || yes  ||      
Badge             || no        || yes   || yes  ||     
Toast             || yes       || no    || yes  ||      
Raw               || no        || no    || yes  ||       


//--> Windows Nofication Service

// Associate Your App with the Windows Phone Store

// Get Channel URL

var channel = await
    PushNotificationChannelManager.CreatePushNotificationChannelFroApplicationAsync();
SaveUriForNotificationService(Channel.Uri);

channel.PushNotificationReceived += channel_PushNotificationReceived;

void gotNotification(PushNitificationChannel sender, PushNotificationReceivedEventArgs args)
{
  Debug.WriteLine(args.NotificationType.ToString());
}

// Sending Push Notifications

// Sample Project for Push Notifications
// [URL for notification sample project, visible at
// http://pushtestserver.azurewebsites.net/wns/ ]
// or 
// Use Azure Notification Hub
// Cross device notifications
// http://aka.ms/notifyhub


//--> Send TileNitification
private void SendTileNotification()
{
  // get an XML DOM varsion of a specific template by using getTemplateContext
  var tileXml = TileUpdateManger.GetTemplateContent(TileTemplate.TileSquare);
  
  //you will need tolock at the template documentation to know how many text field a paricular template has
  // get the text attribute for this template and fill it in
  var tileAttributes = tileXml.GetElementByTagName("Hello World");
  
  // create the notificatiob from the XML
  var tileNotification = new TileNotification(tileXml);
  
  // send the notification to the calling apps tile
  TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
}

// for more information write tile notification template on your favorite webbrowser
