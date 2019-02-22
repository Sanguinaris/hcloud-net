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
      ""error"": null
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

        }
    }
}
