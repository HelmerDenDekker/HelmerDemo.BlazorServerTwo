using System.Security.Cryptography;
using HelmerDemo.BlazorServerTwo.Shared;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using Serilog;

namespace HelmerDemo.BlazorServerTwo.Application.JsInterop;

public class LocalStorageProvider : ILocalStorageProvider
{
	private readonly ProtectedLocalStorage _localStorage;

	public LocalStorageProvider(ProtectedLocalStorage localStorage)
	{
		_localStorage = localStorage;
	}

	public async Task<bool> IsEnabledAsync()
	{
		try
		{
			var key = "local-storage-enabled";
			var id = "unique-id";
			await _localStorage.SetAsync(key, id);
			var result = await _localStorage.GetAsync<string>(key);

			if (result.Success && result.Value == id)
			{
				await _localStorage.DeleteAsync(key);
				return true;
			}

			return false;
		}
		catch (JSException jse) when (jse.Message.Contains("Access is denied"))
		{
			Log.Warning(jse, "JS error while checking if LocalStorage is enabled, localstorage is disabled by the user.");
			return false;
		}
		catch (TaskCanceledException tce)
		{
			Log.Warning(tce, "JS runtime task was cancelled while checking if LocalStorage is enabled.");
			return false;
		}
		catch (CryptographicException cge)
		{
			Log.Warning(cge, "Cryptographic error while checking if LocalStorage is enabled");
			return false;
		}
		catch (Exception e)
		{
			Log.Error(e, "Error while checking if LocalStorage is enabled");
			return false;
		}
	}

	public async Task<ValueResult<T>> GetAsync<T>(string key)
	{
		try
		{
			var protectedBrowserStorageResult = await _localStorage.GetAsync<T>(key);

			if (!protectedBrowserStorageResult.Success || protectedBrowserStorageResult.Value is null)
				return ValueResult<T>.NoContent;

			return ValueResult<T>.Ok(protectedBrowserStorageResult.Value);
		}
		catch (JSException jse) when (jse.Message.Contains("Access is denied"))
		{
			Log.Warning(jse, "JS error while getting value from local storage for {key}, localstorage is disabled by the user.", key);
			return ValueResult<T>.Forbidden;
		}
		catch (TaskCanceledException tce)
		{
			Log.Warning(tce, "JS runtime task was cancelled while getting value from local storage for {key}.", key);
			return ValueResult<T>.Forbidden;
		}
		catch (CryptographicException cge)
		{
			Log.Warning(cge, "Cryptographic error while getting value from local storage for {key}", key);
			return ValueResult<T>.Conflict;
		}
		catch (Exception e)
		{
			Log.Error(e, "Error while getting value from local storage for {key}", key);
			return ValueResult<T>.InternalServerError;
		}
	}

	public async ValueTask SetAsync<T>(string key, T value)
	{
		if (value is null)
		{
			try
			{
				await _localStorage.DeleteAsync(key);
			}
			catch (TaskCanceledException tce)
			{
				Log.Warning(tce, "JS runtime task was cancelled while deleting key {key}.", key);
				// swallow cancellation to avoid unhandled exceptions during shutdown/navigation
			}

			return;
		}

		try
		{
			await _localStorage.SetAsync(key, value);
		}
		catch (TaskCanceledException tce)
		{
			Log.Warning(tce, "JS runtime task was cancelled while setting value for {key}.", key);
			// swallow cancellation to avoid unhandled exceptions during shutdown/navigation
		}
	}

	public async ValueTask DeleteAsync(string key)
	{
		try
		{
			await _localStorage.DeleteAsync(key);
		}
		catch (TaskCanceledException tce)
		{
			Log.Warning(tce, "JS runtime task was cancelled while deleting key {key}.", key);
			// swallow cancellation to avoid unhandled exceptions during shutdown/navigation
		}
	}
}
