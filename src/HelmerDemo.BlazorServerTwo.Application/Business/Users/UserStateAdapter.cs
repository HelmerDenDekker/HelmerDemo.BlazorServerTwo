namespace HelmerDemo.BlazorServerTwo.Application.Business.Users;

public static class UserStateAdapter
{
    public static UserStateDto ToDto(this UserStateProvider userState)
    {
        return new UserStateDto
        {
            State = userState.IsLoading ? ViewModelStateEnum.Loading : ViewModelStateEnum.Ready
        };
    }
}