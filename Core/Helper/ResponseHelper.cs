using Core.Contracts;

namespace Core.Helper
{
    public class ResponseHelper
    {
        //public static PagedResponse<IEnumerable<T>> CreatePagedReponse<T>(IEnumerable<T> pagedData, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
        //{
        //    var respose = new PagedResponse<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
        //    var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
        //    int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        //    respose.NextPage =
        //        validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
        //        ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
        //        : null;
        //    respose.PreviousPage =
        //        validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
        //        ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
        //        : null;
        //    respose.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
        //    respose.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
        //    respose.TotalPages = roundedTotalPages;
        //    respose.TotalRecords = totalRecords;
        //    return respose;
        //}

        
        public static ResponseMessage<T> CreateReponse<T>(T data, bool success, string[]? Errors = null, string? message = null)
        {
            var respose = new ResponseMessage<T>(data)
            {
                Succeeded = success,
                Errors = Errors,
                Message = message
            };
            return respose;
        }

        public static ResponseMessage<IEnumerable<T>> CreateReponse<T>(IEnumerable<T> data, bool success, string[]? Errors = null,  string? message = null) 
        {
            var respose = new ResponseMessage<IEnumerable<T>>(data)
            {
                Succeeded = success,
                Errors = Errors,
                Message = message
            };
            return respose;
        }

        public static ResponseMessage<IEnumerable<T>> CreateReponse<T>(IEnumerable<T> pagedData)
        {
            var respose = new ResponseMessage<IEnumerable<T>>(pagedData);           
            return respose;
        }
    }
}
