import { TestBed } from '@angular/core/testing';

import { FamilyTreeApiService } from './family-tree-api.service';

describe('FamilyTreeApiService', () => {
  let service: FamilyTreeApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FamilyTreeApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
