﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibition.Common.Response
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<ErrorResponseFieldInfo> FieldErrors { get; set; }
    }

    public class ErrorResponseFieldInfo
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
