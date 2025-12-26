namespace AIUX.DTOs
{
    public sealed class LoginResponseDto
    {
        public string Token { get; }

        public LoginResponseDto(string token)
        {
            Token = token;
        }
    }
}
