export abstract class Page {

  protected page = {
    isLoading: false,
    hasError: false,
    error: '',
    paging: {
      pageNumber: 1,
      maxPages: 1
    }
  }

  abstract search(): void;
  abstract clearSearch(): void;
}
