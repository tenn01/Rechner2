using Rechner2.ViewModels;

namespace Rechner2;

public partial class MainPage : ContentPage
{


    public MainPage(RechnerViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    

}

