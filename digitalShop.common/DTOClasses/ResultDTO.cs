using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.common.DTOClasses
{
    public class ResultDTO
    {
        public bool IsSuccess {  get; set; }
        public string message { get; set; }
    }
    public class ResultDTO<T>
    {
        public bool IsSuccess { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }


}
