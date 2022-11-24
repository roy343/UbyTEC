import { TestBed } from '@angular/core/testing';

import { APICommunicationService } from './apicommunication.service';

describe('APICommunicationService', () => {
  let service: APICommunicationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(APICommunicationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
