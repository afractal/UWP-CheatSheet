// Scenarios

// Content streaming app
// - Example: Netflix; Hulu like app
// File sharing app
// - Example: Ondrive; Dropbox like app
// Wifi only app
// -Example: background sync

//---> Content Straming Scenario 

ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
if(internetConnectionProfile != null)
{
	if(internetConnectionProfile.IsWlanConnectionProfile)
  	{
    	// connected on WiFi interface; double check it is not metered WiFi hotspot
    	ConnectionCost cc = internetConnectionProfile.GetConnectionCost();
    	if((NetworkCostType.Unknown == cc.NetworkCostType) || (NetworkCostType.Unrestricted == cc.NetworkCostType)
      	// assume free network; connect and start streaming content
  	} 
	else if (internetConnectionProfile.IsWwanConnectionProfile)
  	{
  		ConnectionCost cc = InternetConnectionProfile.GetConnectionCost();
    	// check the type of data plan - make sure is not currently roaming
    	if(!cc.Roaming)
      	// assume free network; connect and start streaming content
		else if(NetworkCostType.Fixed == cc.NetworkCostType)
    	{
      		// make sure user not currently over limit or near limit
      		if ((!cc.OverDataLimit) && (!cc.ApproachingDataLimit))
        	// connect and start streaming content
    	}
  	}
}
