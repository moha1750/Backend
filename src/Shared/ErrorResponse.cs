using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork
{
    public class ErrorResponse
    {
        public object Data { get; } = null;
        public List<string> Errors { get; set; }

        public ErrorResponse(List<string> errors)
        {
            Errors = errors;
        }
    }
}