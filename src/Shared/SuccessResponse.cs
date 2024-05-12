using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork
{
    public class SuccessResponse
    {
        public object Data { get; set; }
        public List<string> Errors { get; } = null;

        public SuccessResponse(object data)
        {
            Data = data;
        }

    }
}