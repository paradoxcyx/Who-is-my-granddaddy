export abstract class Page {

  protected page = {
    isLoading: false,
    hasError: false,
    error: ''
  }

  abstract search(): void;
  abstract clearSearch(): void;
}
