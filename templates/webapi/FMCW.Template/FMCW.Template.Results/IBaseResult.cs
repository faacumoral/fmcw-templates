namespace FMCW.Template.Results
{
    public interface IBaseResult
    {
        ResultOperation ResultOperation { get; set; }
        bool Success { get; set; }
    }
}

