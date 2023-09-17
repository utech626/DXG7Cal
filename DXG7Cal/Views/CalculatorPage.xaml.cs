using System.Windows.Controls;

using DXG7Cal.ViewModels;

namespace DXG7Cal.Views;

public partial class CalculatorPage : Page
{
    public CalculatorPage(CalculatorViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
		this.Loaded += CalculatorPage_Loaded;
    }

	private void CalculatorPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
	{
		txtCurrentBl.Focus();
	}
}
