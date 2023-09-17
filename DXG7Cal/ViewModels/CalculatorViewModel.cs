using System.Drawing;
using System.Windows;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DXG7Cal.ViewModels;

public class CalculatorViewModel : ObservableObject
{
	private int m_currentBl;
	private int m_appReadingLow;
	private int m_appReadingHigh;
	private Color m_resultForground;
	private Color m_resultBackground;
	private Visibility m_resultVisibility;
	private string m_resultText;
	private int m_meterBl;

	public int CurrentBl { get => m_currentBl; set => SetProperty(ref m_currentBl, value); }
	public int MeterBl { get => m_meterBl; set => SetProperty(ref m_meterBl, value); }
	public int AppReadingLow { get => m_appReadingLow; set =>SetProperty(ref m_appReadingLow, value); }
	public int AppReadingHigh { get => m_appReadingHigh; set => SetProperty(ref m_appReadingHigh, value); }
	public Color ResultForground { get => m_resultForground; set => SetProperty(ref m_resultForground, value); }
	public Color ResultBackground { get => m_resultBackground; set => SetProperty(ref m_resultBackground, value); }
	public Visibility ResultVisibility { get => m_resultVisibility; set => SetProperty(ref m_resultVisibility, value); }
	public String ResultText { get => m_resultText; set => SetProperty(ref m_resultText, value); }
	/// <summary>
	/// Do the Calculation 
	/// </summary>
	public IRelayCommand DoCalculation { get; }

	public CalculatorViewModel()
	{
		CurrentBl = 0;
		DoCalculation = new RelayCommand(DoCalculationExecute, DoCalculationCanExecute);
		ResultVisibility = Visibility.Hidden;
		PropertyChanged += CalculatorViewModel_PropertyChanged;
	}
	/// <summary>
	/// Can the Calculation Execute
	/// </summary>
	/// <returns></returns>
	private bool DoCalculationCanExecute()
	{
		return (CurrentBl > 0 && MeterBl > 0);
	}
	/// <summary>
	/// A Value was chaged
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	/// <exception cref="NotImplementedException"></exception>
	private void CalculatorViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "CurrentBl" || e.PropertyName == "MeterBl")
		{
			DoCalculation.NotifyCanExecuteChanged();
			AppReadingHigh = 0;
			AppReadingLow = 0;
			ResultVisibility = Visibility.Hidden;
		}
	}

	/// <summary>
	/// Perform the Calculation
	/// </summary>
	private void DoCalculationExecute()
	{
		if (CurrentBl > 60)
			Calculate(CurrentBl, Convert.ToInt32(Math.Floor(CurrentBl * 0.20)));
		else
			Calculate(CurrentBl, 20);
	}
	/// <summary>
	/// Do the calculation
	/// </summary>
	/// <param name="currentBl"></param>
	/// <param name="offset"></param>
	/// <exception cref="NotImplementedException"></exception>
	private void Calculate(int currentBl, int offset)
	{
		AppReadingLow = currentBl - offset;
		AppReadingHigh = currentBl + offset;
		ResultVisibility = Visibility.Visible;

		if (MeterBl < AppReadingLow || MeterBl > AppReadingHigh)
		{
			ResultText = Properties.Resources.NeedsCalibration;
			ResultBackground = Color.Red;
			ResultForground = Color.White;
		}
		else
		{
			ResultText = Properties.Resources.WithinLimits;
			ResultBackground = Color.Transparent;
			ResultForground = Color.Black;
		}
	}
}
