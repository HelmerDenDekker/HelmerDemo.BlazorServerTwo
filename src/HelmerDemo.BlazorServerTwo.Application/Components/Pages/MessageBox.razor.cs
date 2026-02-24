using HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class MessageBox : ComponentBase
{
    [Inject]
    private IMessageBoxViewModel ViewModel { get; set; }

    protected override void OnInitialized()
    {
	    ViewModel.Initialize();
    }
}