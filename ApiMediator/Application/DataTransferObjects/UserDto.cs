namespace ApiMediator.Application.DataTransferObjects
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProductLastFour { get; set; } = string.Empty;
    }
    
}