using AIUX.DTOs;

namespace AIUX.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsTakenEmailAsync(string email);
        Task RegisterAsync(RegisterUserDto dto);

        Task<string?> LoginAsync(LoginUserDto dto);
    }
}
