using hcloud_net.API.Response;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Xunit;

namespace hcloud_net_tests
{
    public class ErrorTests
    {
        /// <summary>
        /// https://docs.hetzner.cloud/#overview-errors
        /// </summary>
        private const string InvalidInputResponse = @"{
  ""error"": {
    ""code"": ""invalid_input"",
    ""message"": ""invalid input in field 'broken_field': is too long"",
    ""details"": {
      ""fields"": [
        {
          ""name"": ""broken_field"",
          ""messages"": [""is too long""]
    }
      ]
    }
  }
}";

        private const string UniquenessErrorResponse = @"{
  ""error"": {
    ""code"": ""uniqueness_error"",
    ""message"": ""SSH key with the same fingerprint already exists"",
    ""details"": {
      ""fields"": [
        {
          ""name"": ""public_key""
        }
      ]
    }
  }
}";

        private const string ResourceLimitExceededResponse = @"{
  ""error"": {
    ""code"": ""resource_limit_exceeded"",
    ""message"": ""project limit exceeded"",
    ""details"": {
      ""limits"": [
        {
          ""name"": ""project_limit""
        }
      ]
    }
  }
}";


        [Fact]
        public void CanParseInvalidInputSample()
        {
            var sr = new DataContractJsonSerializer(typeof(ErrorResponse));
            var error = sr.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(InvalidInputResponse))) as ErrorResponse;

            Assert.NotNull(error.Error);
            Assert.Equal("invalid_input", error.Error.Code);
            Assert.Equal("invalid input in field 'broken_field': is too long", error.Error.Message);
            Assert.NotNull(error.Error.Details);
            Assert.NotNull(error.Error.Details.Fields);
            Assert.Null(error.Error.Details.Limits);
            Assert.Single(error.Error.Details.Fields);
            Assert.Equal("broken_field", error.Error.Details.Fields[0].Name);
            Assert.Single(error.Error.Details.Fields[0].Messages);
            Assert.Equal("is too long", error.Error.Details.Fields[0].Messages[0]);
        }

        [Fact]
        public void CanParseUniquenessErrorSample()
        {
            var sr = new DataContractJsonSerializer(typeof(ErrorResponse));
            var error = sr.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(UniquenessErrorResponse))) as ErrorResponse;

            Assert.NotNull(error.Error);
            Assert.Equal("uniqueness_error", error.Error.Code);
            Assert.Equal("SSH key with the same fingerprint already exists", error.Error.Message);
            Assert.NotNull(error.Error.Details);
            Assert.NotNull(error.Error.Details.Fields);
            Assert.Null(error.Error.Details.Limits);
            Assert.Single(error.Error.Details.Fields);
            Assert.Equal("public_key", error.Error.Details.Fields[0].Name);
            Assert.Null(error.Error.Details.Fields[0].Messages);
        }

        [Fact]
        public void CanParseResourceLimitExceededSample()
        {
            var sr = new DataContractJsonSerializer(typeof(ErrorResponse));
            var error = sr.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(ResourceLimitExceededResponse))) as ErrorResponse;

            Assert.NotNull(error.Error);
            Assert.Equal("resource_limit_exceeded", error.Error.Code);
            Assert.Equal("project limit exceeded", error.Error.Message);
            Assert.NotNull(error.Error.Details);
            Assert.Null(error.Error.Details.Fields);
            Assert.NotNull(error.Error.Details.Limits);
            Assert.Single(error.Error.Details.Limits);
            Assert.Equal("project_limit", error.Error.Details.Limits[0].Name);
        }
    }
}
