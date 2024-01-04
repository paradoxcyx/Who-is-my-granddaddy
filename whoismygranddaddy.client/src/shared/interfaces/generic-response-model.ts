export interface GenericResponseModel<T> {
  success: boolean;
  message: string;
  data: T;
  page: number;
  maxPages: number;
}
