using System.ComponentModel.DataAnnotations;
using R3;

namespace HelmerDemo.BlazorServerTwo.Application.Features.SimpleForm.R3;

public class MessageR3ViewModel : IDisposable
{
    private CompositeDisposable _disposables = new();
    
    public MessageR3ViewModel()
    {
        Content = new ReactiveProperty<string>(string.Empty).AddTo(_disposables);
    }
    
    [Required(AllowEmptyStrings = false)]
    [MaxLength(1000)]
    public ReactiveProperty<string> Content { get; }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}