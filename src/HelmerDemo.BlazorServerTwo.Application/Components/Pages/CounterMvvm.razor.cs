using HelmerDemo.BlazorServerTwo.Application.Business.Counter.MVVM;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class CounterMvvm : ComponentBase
{
    private CounterViewModel _model;
    
    protected override void OnInitialized()
    {
        // This might be moved to the ViewModel itself, in an Initialize function, or even to a factory, but for simplicity we just initialize it here.
        _model = new CounterViewModel();
    }
}