import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CdbCalculationService } from './services/cdb-calculation.service';
import { Subject, of } from 'rxjs';

describe('AppComponent', () => {
  const formBuilder: FormBuilder = new FormBuilder();
  let fixture: ComponentFixture<AppComponent>;
  let component: AppComponent;
  let ServiceMock: CdbCalculationService;
  const responseMock = {
    rawValue: 222,
    liquidValue: 200
  };

  beforeEach(async () => {
    ServiceMock = jasmine.createSpyObj(CdbCalculationService, {
      calculate: new Subject(),
    });

    await TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
      providers: [
        { provide: FormBuilder, useValue: formBuilder },
        { provide: CdbCalculationService, useValue: ServiceMock },
      ],
    }).compileComponents()
    .then(() => {
      fixture = TestBed.createComponent(AppComponent);
      component = fixture.componentInstance;

      fixture.detectChanges();
    });
  });

  beforeEach(() => {
    component.form = new FormGroup({
      value: new FormControl(123, Validators.required),
      period: new FormControl(2, [Validators.required, Validators.min(2)]),
    });
    component.bindCdbRequest();

    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should initiate the component', () => {
    component.ngOnInit();
    expect(component.form).not.toBeUndefined();
  });

  it(`should have as title 'WebCdbApp'`, () => {
    expect(component.title).toEqual('WebCdbApp');
  });

  it(`should calculate and return response`, () => {
    component.calculate();

    expect(ServiceMock.calculate).toHaveBeenCalled();
  });

  it('should unsubscribe when component is destroyed', () => {
    component.calculate();
    component.ngOnDestroy();

    expect(component.calculation$.closed).toBeTrue();
  });
});
