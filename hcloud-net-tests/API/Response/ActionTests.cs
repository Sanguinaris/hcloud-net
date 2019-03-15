using hcloud_net.API.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Xunit;

namespace hcloud_net_tests.API.Request
{
    public class ActionsTests
    {
        const string ActionResponse = @" { ""actions"": [
    {
      ""id"": 3091918,
      ""command"": ""create_server"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-06-20T10:51:40+00:00"",
      ""finished"": ""2018-06-20T10:51:54+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3092187,
      ""command"": ""request_console"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-06-20T11:01:11+00:00"",
      ""finished"": ""2018-06-20T11:01:11+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3092276,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-06-20T11:04:42+00:00"",
      ""finished"": ""2018-06-20T11:04:43+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3445177,
      ""command"": ""request_console"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-04T16:23:59+00:00"",
      ""finished"": ""2018-07-04T16:23:59+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3445188,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-04T16:24:16+00:00"",
      ""finished"": ""2018-07-04T16:24:16+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3519114,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-07T15:09:57+00:00"",
      ""finished"": ""2018-07-07T15:09:57+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3561791,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-09T15:53:03+00:00"",
      ""finished"": ""2018-07-09T15:53:03+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3597896,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-10T14:15:29+00:00"",
      ""finished"": ""2018-07-10T14:15:29+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3628197,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-11T08:56:22+00:00"",
      ""finished"": ""2018-07-11T08:56:23+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3663384,
      ""command"": ""request_console"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-12T15:12:51+00:00"",
      ""finished"": ""2018-07-12T15:12:51+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3669009,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-12T19:48:10+00:00"",
      ""finished"": ""2018-07-12T19:48:10+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3684841,
      ""command"": ""shutdown_server"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-13T06:32:58+00:00"",
      ""finished"": ""2018-07-13T06:33:43+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3689858,
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-13T06:53:12+00:00"",
      ""finished"": ""2018-07-13T06:53:29+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3701638,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-13T15:14:17+00:00"",
      ""finished"": ""2018-07-13T15:14:17+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3763768,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-16T09:04:46+00:00"",
      ""finished"": ""2018-07-16T09:04:46+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3885489,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-20T13:13:09+00:00"",
      ""finished"": ""2018-07-20T13:13:10+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 3947709,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-23T07:40:18+00:00"",
      ""finished"": ""2018-07-23T07:40:18+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 4018561,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-07-25T10:32:34+00:00"",
      ""finished"": ""2018-07-25T10:32:35+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 4232793,
      ""command"": ""request_console"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-08-02T14:58:01+00:00"",
      ""finished"": ""2018-08-02T14:58:01+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 4232853,
      ""command"": ""reset_server_password"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-08-02T14:58:52+00:00"",
      ""finished"": ""2018-08-02T14:58:52+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": null
    },
    {
      ""id"": 8628074,
      ""command"": ""start_server"",
      ""status"": ""success"",
      ""progress"": 100,
      ""started"": ""2018-11-26T07:04:53+00:00"",
      ""finished"": ""2018-11-26T07:06:18+00:00"",
      ""resources"": [
        {
          ""id"": 798217,
          ""type"": ""server""
        }
      ],
      ""error"": {
            ""code"": ""forbidden"",
            ""message"": ""Insufficient permissions for this request""
        }
    }
  ],
  ""meta"": {
    ""pagination"": {
      ""page"": 1,
      ""per_page"": 25,
      ""previous_page"": null,
      ""next_page"": null,
      ""last_page"": 1,
      ""total_entries"": 21
    }
  }
}";

        [Fact]
        public void CanParseThisMess()
        {
            var sr = new DataContractJsonSerializer(typeof(ActionRequest));
            var error = sr.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(ActionResponse))) as ActionRequest;

            Assert.NotNull(error);

            Assert.Equal(21, error.Actions.Length);

            Assert.Equal(3091918, error.Actions[0].Id);
            Assert.Equal("create_server", error.Actions[0].Command);
            Assert.Equal("success", error.Actions[0].Status);
            Assert.Equal(100, error.Actions[0].Progress);
            Assert.Equal("2018-06-20T10:51:40+00:00", error.Actions[0].Started);
            Assert.Equal("2018-06-20T10:51:54+00:00", error.Actions[0].Finished);

            Assert.Single(error.Actions[0].Resources);
            Assert.Equal(798217, error.Actions[0].Resources[0].Id);
            Assert.Equal("server", error.Actions[0].Resources[0].Type);

            Assert.Null(error.Actions[0].Error);


            Assert.Equal(8628074, error.Actions[20].Id);
            Assert.Equal("start_server", error.Actions[20].Command);
            Assert.Equal("success", error.Actions[20].Status);
            Assert.Equal(100, error.Actions[20].Progress);
            Assert.Equal("2018-11-26T07:04:53+00:00", error.Actions[20].Started);
            Assert.Equal("2018-11-26T07:06:18+00:00", error.Actions[20].Finished);

            Assert.Single(error.Actions[20].Resources);
            Assert.Equal(798217, error.Actions[20].Resources[0].Id);
            Assert.Equal("server", error.Actions[20].Resources[0].Type);

            Assert.NotNull(error.Actions[20].Error);
            Assert.Equal("forbidden", error.Actions[20].Error.Code);
            Assert.Equal("Insufficient permissions for this request", error.Actions[20].Error.Message);
        }
    }
}
