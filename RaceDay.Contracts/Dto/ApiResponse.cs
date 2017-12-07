using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceDay.Contracts.Dto
{
    public class ApiResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
