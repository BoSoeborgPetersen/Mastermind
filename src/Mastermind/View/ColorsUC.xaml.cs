namespace Mastermind.View;

public sealed partial class ColorsUC : UserControl
{
    public ColorsUC()
    {
        InitializeComponent();
    }

    //private void Ellipse_PointerReleased_1(object sender, PointerRoutedEventArgs e)
    //{
    //    ColorField colorField = (ColorField)((Ellipse)sender).DataContext;
    //    Page MainPage = FindParentOfType<Page>((DependencyObject)sender);
    //    MainViewModel vm = (MainViewModel)MainPage.DataContext;
    //    vm.FieldColorSelected(colorField.Color);
    //}
}
