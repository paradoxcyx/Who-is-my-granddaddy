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
  abstract reset(): void;

  initLoading() {
    this.page.isLoading = true;
    this.page.hasError = false;
    this.page.error = '';
  }

  showError(message: string) {
    this.page.hasError = true;
    this.page.error = message;
  }
}
