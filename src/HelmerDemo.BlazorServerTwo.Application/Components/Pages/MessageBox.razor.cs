using HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;
using HelmerDemo.BlazorServerTwo.Application.Business.MessageBox.NotifyChanged;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class MessageBox : ComponentBase, IDisposable
{
    [Inject]
    private IMessageBoxViewModel ViewModel { get; set; }

    private IDisposable? _stateSubscription;

    protected override void OnInitialized()
    {
        ViewModel.Initialize();
        // For any changes coming from the State, we need to notify the component to update the UI. We can do this by subscribing to the state changes of the ViewModel.
        _stateSubscription = ViewModel.WhenStateChanged().Subscribe(_ => InvokeAsync(() => StateHasChanged()));
        
    }

    void IDisposable.Dispose()
    {
        _stateSubscription?.Dispose();
    }
}