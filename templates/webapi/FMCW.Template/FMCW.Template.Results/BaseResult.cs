namespace FMCW.Template.Results
{
    public class BaseResult<Tok, Terror> : IBaseResult
    {
        public Tok ResultOk { get; set; } = default;
        public Terror ResultError { get; set; } = default;
        public ResultOperation ResultOperation { get; set; } = ResultOperation.Ok; 
        public bool Success { get; set; } = true;

    }
}
