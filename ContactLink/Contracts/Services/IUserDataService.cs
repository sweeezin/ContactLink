using ContactLink.ViewModels;

namespace ContactLink.Contracts.Services;

public interface IUserDataService
{
    event EventHandler<UserViewModel> UserDataUpdated;

    void Initialize();

    UserViewModel GetUser();
}
