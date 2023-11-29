import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CdbRequest } from '../core/interfaces/request/cdb-request';
import { tap } from 'rxjs';
import { ToastrAlertService } from './toastr-alert.service';
import { CdbResponse } from '../core/interfaces/response/cdb-response';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CdbCalculationService {


  constructor(private http: HttpClient,
              private toastr: ToastrAlertService) { }

  calculate(request: CdbRequest) {
    return this.http.post<CdbResponse>(environment.API_URL + 'calculate', request).pipe(
      tap(() => {},
      error => {
        const message = 'Erro ao calcular o valor do CDB. Status: ' + error.status;
        this.toastr.showToasterError(message, 'Error');
      }
      )
    );
  }
}
