using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.ModelDTO
{
    public class ModelBase
    {
        public ResponseMessage Message { get; set; } = new();
    }
    public class ResponseMessage
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
