using System;

namespace FMCW.Template.Results
{
    public class BoolResult : BaseResult<bool, ErrorResult>, IBaseErrorResult
    {
        public static BoolResult Ok()
            => new()
            {
                ResultOk = true,
                ResultOperation = ResultOperation.Ok,
                Success = true
            };

        public static BoolResult Error(Exception ex)
           => new()
           {
               ResultError = ErrorResult.Build(ex),
               ResultOperation = ResultOperation.Error,
               Success = false
           };

        public static BoolResult Error(string err)
          => new()
          {
              ResultError = ErrorResult.Build(err),
              ResultOperation = ResultOperation.Error,
              Success = false
          };

        public static BoolResult Error(ErrorResult ex)
         => new()
         {
             ResultError = ex,
             ResultOperation = ResultOperation.Error,
             Success = false
         };

    }
}
