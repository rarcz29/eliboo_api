using System.Collections.Generic;

namespace Eliboo.Api.Contracts.Responses
{
    public class AuthFailResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
