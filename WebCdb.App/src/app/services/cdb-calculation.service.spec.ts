import { TestBed, inject } from '@angular/core/testing';

import { CdbCalculationService } from './cdb-calculation.service';
import { HttpErrorResponse, HttpClientModule } from '@angular/common/http';
import { ToastrAlertService } from './toastr-alert.service';
import { Subject, throwError } from 'rxjs';

describe('CdbCalculationService', () => {
  let calcService: CdbCalculationService;
  let serviceSpy: CdbCalculationService;
  let toastrSpy: ToastrAlertService;

  beforeEach(() => {
    serviceSpy = jasmine.createSpyObj(CdbCalculationService, {
      calculate: new Subject(),
    });
    toastrSpy = jasmine.createSpyObj(ToastrAlertService, {
      showToasterSuccess: new Subject(),
      showToasterError: new Subject(),
      showToasterWarning: new Subject(),
    });

    TestBed.configureTestingModule({
      imports:[HttpClientModule],
      providers: [
        CdbCalculationService,
        { provide: CdbCalculationService, useValue: serviceSpy },
        { provide: ToastrAlertService, useValue: toastrSpy },
      ]
    });
  });

  beforeEach(inject([CdbCalculationService], (service: CdbCalculationService) => {
    calcService = service;
  }));

  it('should be created', () => {
    expect(calcService).toBeTruthy();
  });

  it('calculate', () => {
      let request = { value: 111, period: 2 };
      serviceSpy.calculate = jasmine.createSpy().and.callThrough();
      calcService.calculate(request);

      expect(serviceSpy.calculate).toHaveBeenCalled();
  });

  it('calculate with error', () => {
      let request = { value: 111, period: 2 };
      serviceSpy.calculate = jasmine.createSpy().and.returnValue(throwError(() => new HttpErrorResponse({status: 404})));
      calcService.calculate(request);

      expect(serviceSpy.calculate).toHaveBeenCalled();
  });
});
