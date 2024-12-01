using MediatR;
using PS.TaskPlanner.Domain.Entities;
using PS.TaskPlanner.Domain.Enums;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.CreateWorkTask
{
    public class CreateWorkTaskCommand : IRequest<WorkTask>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorkTaskStatus Status { get; set; }
        public WorkTaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
