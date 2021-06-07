using System;

namespace FMCW.Template.Results
{
    public class StringResult : BaseResult<string, ErrorResult>, IBaseErrorResult
    {
        public static StringResult Ok(string ok)
            => new()
            {
                ResultOk = ok,
                ResultOperation = ResultOperation.Ok,
                Success = true
            };

        public static StringResult Error(Exception ex)
           => new()
           {
               ResultError = ErrorResult.Build(ex),
               ResultOperation = ResultOperation.Error,
               Success = false
           };

        public static StringResult Error(ErrorResult ex)
             => new()
             {
                 ResultError = ex,
                 ResultOperation = ResultOperation.Error,
                 Success = false
             };

        public static StringResult Error(string ex)
           => new()
           {
               ResultError = ErrorResult.Build(ex),
               ResultOperation = ResultOperation.Error,
               Success = false
           };

        public static StringResult Error()
          => new()
          {
              ResultOperation = ResultOperation.Error,
              Success = false
          };

        public static StringResult Forbidden(string msg)
           => new()
           {
               ResultError = ErrorResult.Build(msg),
               ResultOperation = ResultOperation.Forbidden,
               Success = false
           };

    }
}
