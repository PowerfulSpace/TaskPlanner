namespace PS.TaskPlanner.Application.Dtos
{
    public class AppUserDto
    {
        public Guid Id { get; set; } // ID пользователя
        public string UserName { get; set; } = string.Empty; // Имя пользователя
        public string Email { get; set; } = string.Empty; // Email пользователя
        public string FullName { get; set; } = string.Empty; // Полное имя (если есть)
        public bool IsActive { get; set; } // Статус активности пользователя
        public DateTime CreatedAt { get; set; } // Дата создания пользователя
    }
}
