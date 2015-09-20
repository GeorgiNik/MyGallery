using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TestProject.Tasks
{
    /// <summary>
    /// Excecution status of the Task
    /// </summary>
    [DataContract]
    public enum Execution
    {
        [EnumMember]
        Stopped = 0,
        [EnumMember]
        Pending = 1,
        [EnumMember]
        InProgress = 2,
        [EnumMember]
        Finished = 3,
        [EnumMember]
        Failed = 4,
        [EnumMember]
        Disabled = 5
    }
}
