namespace ProjectFlow.Domain.Entities
{
    public class Issue
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DateCreation { get; private set; }
        public DateTime? DateUpdate { get; private set; }
        public DateTime DueDate { get; private set; }

        // FK
        public Guid ProjectId { get; private set; }
        public Guid CreatorId { get; private set; }
        public Guid AssignedToId { get; private set; }
        public Guid StateId { get; private set; }
        public Guid PriorityId { get; private set; }

        // 🔥 NAVEGACIONES (CLAVE PARA EF)
        public Project Project { get; private set; }
        public User Creator { get; private set; }
        public User AssignedTo { get; private set; }
        public State State { get; private set; }
        public Priority Priority { get; private set; }

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments;

        private Issue() { }

        public Issue(string name, string description, DateTime dueDate,
                     Guid projectId, Guid creatorId, Guid assignedToId,
                     Guid stateId, Guid priorityId)
        {
            if (dueDate < DateTime.UtcNow)
                throw new Exception("Due date cannot be in the past.");

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            DueDate = dueDate;
            ProjectId = projectId;
            CreatorId = creatorId;
            AssignedToId = assignedToId;
            StateId = stateId;
            PriorityId = priorityId;
            DateCreation = DateTime.UtcNow;
        }

        public void Rename(string name)
        {
            Name = name;
            DateUpdate = DateTime.UtcNow;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
            DateUpdate = DateTime.UtcNow;
        }

        public void ChangeDueDate(DateTime dueDate)
        {
            if (dueDate < DateTime.UtcNow)
                throw new Exception("Due date cannot be in the past.");

            DueDate = dueDate;
            DateUpdate = DateTime.UtcNow;
        }

        public void ChangeState(Guid stateId)
        {
            StateId = stateId;
            DateUpdate = DateTime.UtcNow;
        }

        public void Reassign(Guid userId)
        {
            AssignedToId = userId;
            DateUpdate = DateTime.UtcNow;
        }

        public void ChangePriority(Guid priorityId)
        {
            PriorityId = priorityId;
            DateUpdate = DateTime.UtcNow;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}