export interface GenericResponseModel<T> {
  success: boolean;
  message: string;
  data: T;
  paging: Paging;
}

export interface Paging {
  page: number;
  maxPages: number;
}
