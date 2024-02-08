using System.Collections.Generic;
using System.Text.Json;

namespace Domain.Core.Models
{
    public class ErrorDetails
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public override string ToString()
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, serializeOptions);
        }
    }
}
