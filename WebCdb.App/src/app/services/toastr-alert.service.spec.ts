import { TestBed } from '@angular/core/testing';

import { ToastrAlertService } from './toastr-alert.service';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';

describe('CdbCalculationService', () => {
  let service: ToastrAlertService;
  let ServiceMock: ToastrService;
  const message = 'teste';
  const title = 'teste';

  beforeEach(() => {
    ServiceMock = jasmine.createSpyObj(ToastrService, {
      success: new Subject(),
      error: new Subject(),
      warning: new Subject(),
    });

    TestBed.configureTestingModule({
      providers: [
        { provide: ToastrService, useValue: ServiceMock },
        ]
    });
    service = TestBed.inject(ToastrAlertService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('call success', () => {
    service.showToasterSuccess(message, title);
    expect(ServiceMock.success).toHaveBeenCalled();
  });

  it('call error', () => {
    service.showToasterError(message, title);
    expect(ServiceMock.error).toHaveBeenCalled();
  });

  it('call warning', () => {
    service.showToasterWarning(message, title);
    expect(ServiceMock.warning).toHaveBeenCalled();
  });
});
