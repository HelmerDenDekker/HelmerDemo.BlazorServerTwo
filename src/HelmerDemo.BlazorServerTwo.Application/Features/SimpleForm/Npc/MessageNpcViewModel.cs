using System.ComponentModel;

namespace HelmerDemo.BlazorServerTwo.Application.Features.SimpleForm.Npc;

public class MessageNpcViewModel : INotifyPropertyChanged
{
    public string Content
    {
        get;
        set
        {
            if (field != value)
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Content)));
            }
        }
    } = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;
}