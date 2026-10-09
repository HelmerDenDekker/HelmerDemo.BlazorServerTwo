using HelmerDemo.BlazorServerTwo.Shared;

namespace HelmerDemo.BlazorServerTwo.Application.JsInterop;

public interface ILocalStorageProvider
{
    public Task<bool> IsEnabledAsync();

    public Task<ValueResult<T>> GetAsync<T>(string key);

    public ValueTask SetAsync<T>(string key, T value);

    public ValueTask DeleteAsync(string key);
}