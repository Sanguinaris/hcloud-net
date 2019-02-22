using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace hcloud_net.API.Request
{
    /// <summary>
    /// An action resource
    /// </summary>
    [DataContract]
    public class ActionResource
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    public class ActionError
    {
        /// <summary>
        /// The error code
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// additional error message
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }

    /// <summary>
    /// Action Data
    /// </summary>
    [DataContract(Name = "actions")]
    public class Actions
    {
        /// <summary>
        /// The ID
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The Command
        /// </summary>
        [DataMember(Name = "command")]
        public string Command { get; set; }

        /// <summary>
        /// The Progress
        /// </summary>
        [DataMember(Name = "progress")]
        public int Progress { get; set; }

        /// <summary>
        /// Started TimeStamp (YEAR-MONTH-DAYTHOUR:MINUTES:SECONDS+TIMEZONE)
        /// </summary>
        [DataMember(Name = "started")]
        public string Started { get; set; }

        /// <summary>
        /// Started TimeStamp (YEAR-MONTH-DAYTHOUR:MINUTES:SECONDS+TIMEZONE)
        /// </summary>
        [DataMember(Name = "finished")]
        public string Finished { get; set; }

        /// <summary>
        /// Resources
        /// </summary>
        [DataMember(Name = "resources")]
        public ActionResource[] Resources { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [DataMember(Name = "error")]
        public ActionError Error { get; set; }
    }

    [DataContract]
    public class ActionRequest
    {
        [DataMember(Name = "actions")]
        public Actions[] Actions { get; set; }
    }
}
