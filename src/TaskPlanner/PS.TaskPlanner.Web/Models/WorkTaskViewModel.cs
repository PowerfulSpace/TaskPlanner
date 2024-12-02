namespace PS.TaskPlanner.Web.Models
{
    public class WorkTaskViewModel
    {
        public Guid Id { get; set; } // ID задачи
        public string Title { get; set; } = string.Empty; // Название задачи
        public string Description { get; set; } = string.Empty; // Описание задачи
        public string Status { get; set; } = string.Empty; // Статус задачи (строка для удобства отображения)
        public string Priority { get; set; } = string.Empty; // Приоритет задачи (строка для удобства отображения)
        public DateTime? DueDate { get; set; } // Крайний срок выполнения
        public Guid? AssignedToUserId { get; set; } // ID назначенного пользователя
        public string? AssignedToUserName { get; set; } // Имя назначенного пользователя
        public Guid ProjectId { get; set; } // ID связанного проекта
        public string ProjectTitle { get; set; } = string.Empty; // Название связанного проекта
    }
}
