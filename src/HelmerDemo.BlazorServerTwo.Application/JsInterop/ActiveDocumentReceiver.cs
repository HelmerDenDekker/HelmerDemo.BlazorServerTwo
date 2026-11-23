using Microsoft.JSInterop;

namespace HelmerDemo.BlazorServerTwo.Application.JsInterop;

public class ActiveDocumentReceiver
{
    public event Action<string> DocumentStatusReceivedEvent;

    [JSInvokable]
    public void DocumentStatusReceived(string documentStatus)
    {
        try
        {
            DocumentStatusReceivedEvent?.Invoke(documentStatus);
        }
        catch
        {
            // ignore
        }
    }
}