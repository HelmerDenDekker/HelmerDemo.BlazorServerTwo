namespace HelmerDemo.BlazorServerTwo.Application.Features.Users;

public static class UserStateAdapter
{
    public static UserStateDto ToDto(this UserStateService userState)
    {
        return new UserStateDto
        {
            State = userState.IsLoading ? ViewModelStateEnum.Loading : ViewModelStateEnum.Ready
        };
    }
}