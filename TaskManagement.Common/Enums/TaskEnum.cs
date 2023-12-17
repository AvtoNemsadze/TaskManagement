using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Common.Enums
{
    public enum TaskPriorityEnum
    {
        Low,
        Medium,
        High,
        Urgent
    }

    public enum TaskStatusEnum
    {
        NotStarted = 1,
        Started = 2,
        InProgress = 3,
        Failed = 4,
        Completed = 5
    }

    public enum TaskLevel
    {
        Easy = 1,
        Medium = 2,
        Difficult = 3
    }
}
