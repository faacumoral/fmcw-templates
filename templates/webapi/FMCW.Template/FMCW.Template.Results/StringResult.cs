﻿using System;

namespace FMCW.Template.Results
{
    public class StringResult : BaseResult<string, ErrorResult>, IBaseErrorResult
    {
        public static StringResult Ok(string ok)
            => new StringResult
            {
                ResultOk = ok,
                ResultOperation = ResultOperation.Ok,
                Success = true
            };

        public static StringResult Error(Exception ex)
           => new StringResult
           {
               ResultError = ErrorResult.Build(ex),
               ResultOperation = ResultOperation.Error,
               Success = false
           };

        public static StringResult Error(ErrorResult ex)
             => new StringResult
             {
                 ResultError = ex,
                 ResultOperation = ResultOperation.Error,
                 Success = false
             };

        public static StringResult Error(string ex)
           => new StringResult
           {
               ResultError = ErrorResult.Build(ex),
               ResultOperation = ResultOperation.Error,
               Success = false
           };

        public static StringResult Error()
          => new StringResult
          {
              ResultOperation = ResultOperation.Error,
              Success = false
          };

        public static StringResult Forbidden(string msg)
           => new StringResult
           {
               ResultError = ErrorResult.Build(msg),
               ResultOperation = ResultOperation.Forbidden,
               Success = false
           };

    }
}
