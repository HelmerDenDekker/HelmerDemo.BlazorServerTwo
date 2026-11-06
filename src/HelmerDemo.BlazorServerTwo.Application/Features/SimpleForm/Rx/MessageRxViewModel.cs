

using System.ComponentModel.DataAnnotations;
using System.Reactive.Subjects;

namespace HelmerDemo.BlazorServerTwo.Application.Features.SimpleForm.Rx;

public class MessageRxViewModel : IDisposable
{
    private readonly BehaviorSubject<string> _messageChangedSubject = new BehaviorSubject<string>(string.Empty);

    public IObservable<string> WhenMessageChanged() => _messageChangedSubject;

    public void Dispose()
    {
        _messageChangedSubject.Dispose();
    }
    
    [Required(AllowEmptyStrings = false)]
    [MaxLength(1000)]
    public string Content { 
        get; 
        set
        {
            if (field != value)
            {
                field = value;
                _messageChangedSubject.OnNext(value);
            }
        } 
    }= string.Empty;
}