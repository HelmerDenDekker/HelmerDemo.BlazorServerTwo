using HelmerDemo.BlazorServerTwo.Application.Features.Counter.R3;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class CounterR3 : ComponentBase
{
    private CounterViewModel CounterViewModel { get; } = new();
}