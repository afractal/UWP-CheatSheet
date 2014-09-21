// Tags, Groups, And Replacing Notifications
// Matching tag and Group will trigger replacement
// Scenario -hourly stock price

// Example: 
ToastNotification toasty = new ToastNotification(doc);
toasty.Tag = "Windows Phone";
toasty.Group = "JumpStart";


//---> Set Expiration for Notification

// Scenario - Limited time price, time - sensitive information

// Example:
ToastNotification toasty = new ToastNotification(doc);
toasty.Tag = "Windows Phone";
toasty.Group = "JumpStart";
toasty.ExpirationTime = (DateTimeOffset.Now + TimeSoan.FromHours(2));


//---> Remove Notifications

// Scenario - sold aou deal

// Example:
ToastNotificationHistory tnh = ToastNotificationManager.History;
tnh.Remove("WindowsPhone");
tnh.RemoveGroup("JumpStart");

// For testing use and help :

// Azure WNS Push Tester
// http://pushtesterserver.azurewebsites.net/wns/

// Client Sample Source:
// http://code.msdn,microsoft.com/WNS-Notifications-for-950d473b

// Azure Sample Source:
// http://code.msdn.microsoft.com/WNS-for-Windows-and-83fd21f6
