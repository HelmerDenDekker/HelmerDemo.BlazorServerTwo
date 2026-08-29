using Microsoft.JSInterop;

namespace HelmerDemo.BlazorServerTwo.Application.JsInterop;

public class ClientActiveDocumentProvider : IClientActiveDocumentProvider
{
    private readonly DotNetObjectReference<ClientActiveDocumentProvider> _dotNetRef;
    private const string ModulePath = "./js/activedocument.js";
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;
    private bool _isActiveDocumentEventRegistered;

    public ClientActiveDocumentProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _dotNetRef = DotNetObjectReference.Create(this);
    }
    
    // TODO, maybe just create some kind of init task, 
    public async Task AddActiveDocumentListenerAsync()
    {
        await InitializeAsync();

        try
        {
            await _module.InvokeVoidAsync("addActiveDocumentListener");
        }
        catch
        {
            // ignore
        }
    }
    
    public ValueTask RegisterActiveDocumentReceiver(ActiveDocumentReceiver receiver)
        => _module.InvokeVoidAsync("registerActiveDocumentReceiver", DotNetObjectReference.Create(receiver));

    private async Task InitializeAsync()
    {
        if (_module != null)
            return;

        _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", ModulePath);
    }
    
}

public interface IClientActiveDocumentProvider
{
}