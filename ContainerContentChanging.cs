// Do it only if you are interested in performance not on designing

// Fire when item is realized 

<ListView ItemTemplate="{StaticResource SampleDataTemplate}"
    ContainerContentChanging="IncrementalUpdateHandler">

// Items can be rendered in phases
 // Phase Priorities
        // 1. Simple Shapes(Placeholder visuals)
        // 2. Key text (title)
        // 3. Other text (subtitle)
        // 4. Images
        
// performance tip 
// do not use visibility but use Opacity
private void IncrementalUpdateHandler(ListViewBase sender, ContainerContentChangingEventArgs args)
{
    args.Handled = true;
    if(args.Phase != 0)
         throw new Exception("we will always be in phase 0");
    else
      {
         // show a placeholder shape
         args.RegisterUpdateCallBack(ShowText);
      }
}

// Later phases will be skipped if too much time is needed

private void ShowText(ListViewBase sender, ContainerContentEventArgs args)
{
    args.Handled = true;
    if(args.Phase != 1)
         throw new Exception("we should always be in phase 1");
    else
      {
         // show text from the template
         args.RegisterUpdateCallback(ShowImage);
      }
}
.....
// Repeat another phase if you want to
