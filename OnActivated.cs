protected override void OnActivated(IActivatedEventArgs args)
{
    switch (args.Kind)    
    {
        case ActivationKind.CachedFileUpdater:  
            //Do something here           
            break;      
        case ActivationKind.CameraSettings:       
            //Do something here        
            break;     
        case ActivationKind.ContactPicker:        
            //Do something here       
            break;    
        case ActivationKind.Device:      
            //Do something here      
            break;   
        case ActivationKind.File:    
            //Do something here      
            break;
        case ActivationKind.FileOpenPicker: 
            //Do something here    
            break;  
        case ActivationKind.FileSavePicker:       
            //Do something here        
            break;        
        case ActivationKind.PrintTaskSettings:   
            //Do something here      
            break;     
        case ActivationKind.Protocol:   
            //Do something here       
            break;    
        case ActivationKind.Search:   
            //Do something here       
            break;     
        case ActivationKind.ShareTarget:      
            //Do something here        
            break;  
    }
} 
