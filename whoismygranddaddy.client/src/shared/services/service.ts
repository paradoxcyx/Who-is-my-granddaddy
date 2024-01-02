import { HttpClient } from '@angular/common/http';

export class Service {
  protected baseApiUrl = 'https://localhost:7258';

  constructor(protected httpClient: HttpClient) {}
}
