﻿using System;
using System.Collections.Generic;

namespace FMCW.Template.Results
{ 
    public class ListResult<T> : BaseResult<List<T>, ErrorResult>, IBaseErrorResult
    {
        public static ListResult<T> Ok(List<T> ok)
            => new ListResult<T>
            {
                ResultOk = ok,
                ResultOperation = ResultOperation.Ok,
                Success = true
            };

        public static ListResult<T> Error(Exception ex)
           => new ListResult<T>
           {
               ResultOperation = ResultOperation.Error,
               ResultError = ErrorResult.Build(ex),
               Success = false
           };

        public static ListResult<T> Error(ErrorResult er)
          => new ListResult<T>
          {
              ResultOperation = ResultOperation.Error,
              ResultError = er,
              Success = false
          };

        public static ListResult<T> Error(string ex)
           => new ListResult<T>
           {
               ResultOperation = ResultOperation.Error,
               ResultError = ErrorResult.Build(ex),
               Success = false
           };

        public static implicit operator ListResult<T>(List<T> t)
          => new ListResult<T>
          {
              ResultOk = t,
              ResultOperation = ResultOperation.Ok,
              Success = true
          };
    }
}
