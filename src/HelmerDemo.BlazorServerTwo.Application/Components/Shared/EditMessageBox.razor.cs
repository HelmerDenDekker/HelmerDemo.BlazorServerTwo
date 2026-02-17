using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Shared;

/// <summary>
/// In web, it is possible to have multiple tabs open, having the same content.
/// In n tabs, I want to show the same message box with the same content.
/// </summary>
public partial class EditMessageBox : ComponentBase
{
    protected EditContext _editContext;
}