export interface Pagination {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
    offset: number;
}

export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
}
