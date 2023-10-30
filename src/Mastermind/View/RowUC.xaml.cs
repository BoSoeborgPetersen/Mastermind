namespace Mastermind.View;

public sealed partial class RowUC : UserControl
{
    public RowUC()
    {
        InitializeComponent();
    }

    //private void Ellipse_PointerReleased_1(object sender, PointerRoutedEventArgs e)
    //{
    //    Field field = (Field)((Ellipse)sender).DataContext;
    //    Page MainPage = FindParentOfType<Page>((DependencyObject)sender);
    //    MainViewModel vm = (MainViewModel)MainPage.DataContext;
    //    vm.FieldSelected(field);
    //}

    //private void Button_Click_1(object sender, RoutedEventArgs e)
    //{
    //    Row row = (Row)((Button)sender).DataContext;
    //    Page MainPage = FindParentOfType<Page>((DependencyObject)sender);
    //    MainViewModel vm = (MainViewModel)MainPage.DataContext;
    //    vm.BidConfirmed(row);
    //}
}
