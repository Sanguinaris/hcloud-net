using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace hcloud_net.API.Response
{
    /// <summary>
    /// Error Codes
    /// </summary>
    [DataContract]
    public enum ErrorCodes
    {
        /// <summary>
        /// Insufficient permissions for this request
        /// </summary>
        [EnumMember(Value = "forbidden")]
        Forbidden,

        /// <summary>
        /// Error while parsing or processing the input
        /// </summary>
        [EnumMember(Value = "invalid_input")]
        InvalidInput,

        /// <summary>
        /// Invalid JSON input in your request
        /// </summary>
        [EnumMember(Value = "json_error")]
        InvalidJson,

        /// <summary>
        /// The item you are trying to access is locked (there is already an action running)
        /// </summary>
        [EnumMember(Value = "locked")]
        Locked,

        /// <summary>
        /// Entity not found
        /// </summary>
        [EnumMember(Value = "not_found")]
        NotFound,

        /// <summary>
        /// Error when sending too many requests
        /// </summary>
        [EnumMember(Value = "rate_limit_exceeded")]
        RateLimitExceeded,

        /// <summary>
        /// Error when exceeding the maximum quantity of a resource for an account
        /// </summary>
        [EnumMember(Value = "resource_limit_exceeded")]
        ResourceLimitExceeded,

        /// <summary>
        /// The requested resource is currently unavailable
        /// </summary>
        [EnumMember(Value = "resource_unavailable")]
        ResourceUnavailable,

        /// <summary>
        /// Error within a service
        /// </summary>
        [EnumMember(Value = "service_error")]
        ServiceError,

        /// <summary>
        /// One or more of the objects fields must be unique
        /// </summary>
        [EnumMember(Value = "uniqueness_error")]
        UniquenessError,

        /// <summary>
        /// The action you are trying to start is protected for this resource
        /// </summary>
        [EnumMember(Value = "protected")]
        Protected,

        /// <summary>
        /// Cannot perform operation due to maintenance
        /// </summary>
        [EnumMember(Value = "maintenance")]
        Maintenance
    }

    /// <summary>
    /// Name and eventually a message(s)
    /// </summary>
    [DataContract]
    public class FieldDetail
    {
        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Optional Messages
        /// </summary>
        [DataMember(Name = "messages")]
        public string[] Messages { get; set; }
    }

    [DataContract]
    public class LimitDetail
    {
        /// <summary>
        /// Name
        /// (might get change to an enum at some point)
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Basic Details in the Error Response
    /// </summary>
    [DataContract]
    public class BaseDetails
    {
        /// <summary>
        /// Field Details
        /// </summary>
        [DataMember(Name = "fields")]
        public FieldDetail[] Fields { get; set; }

        /// <summary>
        /// Limit Details
        /// </summary>
        [DataMember(Name = "limits")]
        public LimitDetail[] Limits { get; set; }
    }

    /// <summary>
    /// Error Response
    /// </summary>
    [DataContract(Name = "error")]
    public class Error
    {
        /// <summary>
        /// The Error Code Send
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Additional Message
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Details
        /// </summary>
        [DataMember(Name = "details")]
        public BaseDetails Details { get; set; }
    }

    /// <summary>
    /// Main Error response
    /// </summary>
    [DataContract]
    public class ErrorResponse
    {
        /// <summary>
        /// Error
        /// </summary>
        [DataMember(Name = "error")]
        public Error Error { get; set; }
    }
}
