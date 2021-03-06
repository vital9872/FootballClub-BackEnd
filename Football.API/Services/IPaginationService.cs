using Football.API.Dto;
using Football.API.Dto.QueryParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Services
{
    public interface IPaginationService
    {
        /// <summary>
        /// Takes IQueryable and creates Pagination wrapper around TDto based on FullPaginationQueryParams
        /// </summary>
        /// <typeparam name="TDto">Data type to be returned wrapped into Pagination</typeparam>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <param name="query">IQueryable to be paginated</param>
        /// <param name="parameters">Pagination and filtering is performed based on these query parameters</param>
        /// <returns>Returns single page encapsulated in PaginationDto based on QueryParameters</returns>
        Task<PaginationDto<TDto>> GetPageAsync<TDto, TEntity>(IQueryable<TEntity> query, FullPaginationQueryParams parameters)
            where TDto : class where TEntity : class;
        /// <summary>
        /// Takes IQueryable and creates Pagination wrapper around TDto based on PageableParams
        /// </summary>
        /// <typeparam name="TDto">Data type to be returned wrapped into Pagination</typeparam>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <param name="query">IQueryable to be paginated</param>
        /// <param name="parameters">Pagination is performed based on page and pageSize in PageableParams</param>
        /// <returns>Returns single page encapsulated in PaginationDto</returns>
        Task<PaginationDto<TDto>> GetPageAsync<TDto, TEntity>(IQueryable<TEntity> query, PageableParams parameters)
            where TDto : class where TEntity : class;

    }
}
