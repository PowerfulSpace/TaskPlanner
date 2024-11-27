namespace PS.TaskPlanner.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Уникальный идентификатор
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Время создания
        public DateTime? UpdatedAt { get; set; } // Время последнего обновления

        /// <summary>
        /// Обновляет поле UpdatedAt текущим временем.
        /// </summary>
        protected void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
