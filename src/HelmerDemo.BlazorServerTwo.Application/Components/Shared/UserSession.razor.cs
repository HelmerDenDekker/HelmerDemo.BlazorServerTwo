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
    private IUserStateService UserStateService{ get; set; } = default!;

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
        await GetUserIdAsync();

        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task GetUserIdAsync()
    {
        var result = await LocalStorageProvider.GetAsync<UserDto>(Key);
        await ProcessUser(result);
    }

    private async Task ProcessUser(ValueResult<UserDto> result)
    {
        // No Id Found
        if (result.Result == Result.NoContent)
        {
            await StoreUserIdAsync();
            return;
        }
        
        if (result.Result.IsSuccess())
        {
            UserStateService.Rehydrate(result.Value);
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
            await StoreUserIdAsync();
            return;
        }
        
        ShowErrorPage("An unexpected error occurred while trying to access Local Storage. Please try again later.");
    }

    private async Task StoreUserIdAsync()
    {
        var enabled = await LocalStorageProvider.IsEnabledAsync();

        if (!enabled)
        {
            ShowErrorPage("Local Storage is disabled by the user. Please enable Local Storage to use this application.");
            return;
        }
        
        // TODO: Edge case: If the browser restarts (f.e. after update), AND user just cleared storage, it wil set multiple user states for the same user.
        await SetUserState();
    }

    private async Task SetUserState()
    {
        var userDto = UserStateService.Create();

        await LocalStorageProvider.SetAsync(Key, userDto);
    }

    private void ShowErrorPage(string message)
    {
        var encodedMessage = Uri.EscapeDataString(message);
        NavigationManager.NavigateTo($"/ErrorMessage?message={encodedMessage}");
    }
}