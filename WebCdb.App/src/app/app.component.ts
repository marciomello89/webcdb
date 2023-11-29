import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CdbResponse } from './core/interfaces/response/cdb-response';
import { CdbCalculationService } from './services/cdb-calculation.service';
import { CdbRequest } from './core/interfaces/request/cdb-request';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'WebCdbApp';
  form: FormGroup;
  cdbResponse: CdbResponse;
  cdbRequest: CdbRequest;
  calculation$: Subscription;

  constructor(
    private fb: FormBuilder,
    private calculationService: CdbCalculationService) {

  }

  ngOnInit(): void {
    this.form = this.fb.group({
      value: ['', [Validators.required, Validators.min(0.01)]],
      period: ['', [Validators.required, Validators.min(2)]],
    });
  }

  calculate() {
    this.bindCdbRequest();
    this.calculation$ = this.calculationService.calculate(this.cdbRequest).subscribe(response => {
      this.cdbResponse = response;
    });
  }

  bindCdbRequest() {
    this.cdbRequest = {
      value: this.form.get('value')?.value,
      period: this.form.get('period')?.value
    };
  }

  ngOnDestroy() {
    if(this.calculation$)
      this.calculation$.unsubscribe();
  }
}
