using HelmerDemo.BlazorServerTwo.Application.Business.Users;
using HelmerDemo.BlazorServerTwo.Application.JsInterop;
using HelmerDemo.BlazorServerTwo.Shared;
using HelmerDemo.BlazorServerTwo.Shared.Extensions;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Shared;

public partial class UserSession : ComponentBase
{
    private const string Key = "HelmerDemoUser";

    [Inject]
    private ILocalStorageProvider LocalStorageProvider { get; set; } = default!;
    
    [Inject]
    private IUserStateProvider UserStateProvider { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            return;
        }

        // It should get the UserId from LocalStorage
        var result = await LocalStorageProvider.GetAsync<UserDto>(Key);
        await ProcessUser(result);
        
        
        await base.OnAfterRenderAsync(firstRender);
    }
    
    private async Task ProcessUser(ValueResult<UserDto> result)
    {
        // No Id Found
        if (result.Result == Result.NoContent)
        {
            await CheckLocalStorageEnabled();
            return;
        }
        
        if (result.Result.IsSuccess())
        {
            UserStateProvider.Rehydrate(result.Value);
            return;
        }
        
        // In case of a forbidden-error => local storage is disabled by the user
        if (result.Result == Result.Forbidden)
        {
            ShowErrorPage("Local Storage is disabled by the user. Please enable Local Storage to use this application.");
            return;
        }

        // In case of a cryptographic-error => remove the stored data and try again
        if (result.Result == Result.Conflict)
        {
            await LocalStorageProvider.DeleteAsync(Key);
            await CheckLocalStorageEnabled();
            return;
        }
        
        ShowErrorPage("An unexpected error occurred while trying to access Local Storage. Please try again later.");
    }

    private async Task CheckLocalStorageEnabled()
    {
        var enabled = await LocalStorageProvider.IsEnabledAsync();

        if (!enabled)
        {
            ShowErrorPage("Local Storage is disabled by the user. Please enable Local Storage to use this application.");
            return;
        }
        
        await SetUserState();
    }

    private async Task SetUserState()
    {
        var userDto = UserStateProvider.Create();

        await LocalStorageProvider.SetAsync(Key, userDto);
        // TODO: Edge case: If the browser restarts (f.e. after update), AND user just cleared storage, it wil set multiple user states for the same user.
    }

    private void ShowErrorPage(string message)
    {
        var encodedMessage = Uri.EscapeDataString(message ?? string.Empty);
        NavigationManager.NavigateTo($"/ErrorMessage?message={encodedMessage}");
    }
}