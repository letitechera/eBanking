import { TestBed } from '@angular/core/testing';

import { EBankingService } from './e-banking.service';

describe('EBankingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EBankingService = TestBed.get(EBankingService);
    expect(service).toBeTruthy();
  });
});
