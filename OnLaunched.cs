protected override async void OnLaunched(LaunchActivatedEventArgs e)    
{
#if DEBUG     
    // Show graphics profiling information while debugging.   
    if (System.Diagnostics.Debugger.IsAttached)     
    {          
        // Display the current frame rate counters     
        this.DebugSettings.EnableFrameRateCounter = true;   
    } 
#endif
    Frame rootFrame = Window.Current.Content as Frame;
 
    // Do not repeat app initialization when the Window already has content, 
    // just ensure that the window is active 
        
    if (rootFrame == null)
    {    
        // Create a Frame to act as the navigation context and navigate to the first page      
        rootFrame = new Frame();         
        //Associate the frame with a SuspensionManager key      
        SuspensionManager.RegisterFrame(rootFrame, "AppFrame");  
        // Set the default language           
        rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0]; 
    
        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)  
        {                
            // Restore the saved session state only when appropriate        
            try             
            {                  
                await SuspensionManager.RestoreAsync();           
            }            
            catch (SuspensionManagerException)         
            {                   
            //Something went wrong restoring state.   
            //Assume there is no state and continue        
            }             
        } 
        // Place the frame in the current Window       
        Window.Current.Content = rootFrame;    
    }       
    if (rootFrame.Content == null)      
    {      
        // When the navigation stack isn't restored navigate to the first page, 
        // configuring the new page by passing required information as a navigation     
        // parameter           
        if (!rootFrame.Navigate(typeof(GroupedItemsPage)))       
        {                  
          throw new Exception("Failed to create initial page");      
        }         
    }        
    // Ensure the current window is active        
    Window.Current.Activate();  
}
