namespace Entelect.Encentivize.Sdk
{
    public class BaseSearchCriteria
    {
        public BaseSearchCriteria(long pageNumber = 1, long pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public long PageNumber { get; set; }
        public long PageSize { get; set; }
    }
}