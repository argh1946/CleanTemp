using Core.Filter;

namespace Core.Contracts
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
