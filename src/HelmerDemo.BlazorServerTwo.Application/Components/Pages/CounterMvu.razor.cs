using HelmerDemo.BlazorServerTwo.Application.Business.Counter.MVU;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class CounterMvu : ComponentBase
{
    private CounterModel _model;

    protected override void OnInitialized()
    {
        _model = new CounterModel(Count: 0);
    }

    private void IncrementCount()
    {
        _model = CounterUpdate.Update(_model, CounterMessageEnum.Increment);
    }
}