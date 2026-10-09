namespace HelmerDemo.BlazorServerTwo.Application.Features.Users;

public class UserDto
{
    public UserDto(Guid id)
    {
        Id = id;
    }
    
    /// <summary>
    ///     The id for the user
    /// </summary>
    public Guid Id { get; set; }
}