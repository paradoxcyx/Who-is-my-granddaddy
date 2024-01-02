export interface GenericResponseModel<T> {
  success: boolean;
  message: string;
  data: T;
}
