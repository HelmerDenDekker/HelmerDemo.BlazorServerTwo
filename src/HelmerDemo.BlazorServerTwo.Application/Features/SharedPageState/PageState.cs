namespace HelmerDemo.BlazorServerTwo.Application.Features.SharedPageState;

public class PageState : IPageState
{
    public string Message { get; set; }  = string.Empty;
}