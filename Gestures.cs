// make a moving rect with gestures 

 TranslateTransform _moveTrans = new TranslateTransform();

public MainPage()
{
    this.InitializeComponent();
    myRect.ManipulationDelta += myRect_ManipulationDelta;
    myRect.ManipulationStarted += myRect_ManipulationStarted;
    myRect.ManipulationCompleted += myRect_ManipulationCompleted;
    myRect.RenderTransform = _moveTrans;
}

void myRect_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
{
    myRect.Fill = new SolidColorBrush(Colors.Blue);
}

void myRect_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
{
    myRect.Fill = new SolidColorBrush(Colors.Azure);
}

void myRect_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
{
    _moveTrans.X += e.Delta.Translation.X;
    _moveTrans.Y += e.Delta.Translation.Y;
}

