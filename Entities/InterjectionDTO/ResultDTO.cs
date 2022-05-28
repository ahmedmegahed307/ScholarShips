using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities.InterjectionDTO
{
    public class ResultDTO<T>:IDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
