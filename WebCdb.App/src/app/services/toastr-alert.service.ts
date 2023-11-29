import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToastrAlertService {

  constructor(private toastrService: ToastrService) { }

  showToasterSuccess(message: string, tittle: string) {
    this.toastrService.success(message, tittle, {
      timeOut: 30000,
      progressBar: true,
      extendedTimeOut: 30000,
      closeButton: true,
      positionClass: 'toast-center-center'

    });
  }

  showToasterError(message: string, tittle: string) {
    this.toastrService.error(message, tittle, {
      disableTimeOut: true,
      progressBar: false,
      closeButton: true,
      positionClass: 'toast-center-center'

    });
  }


  showToasterWarning(message: string, tittle: string) {
    this.toastrService.warning(message, tittle, {
      closeButton: true,
      progressBar: true,
      positionClass: 'toast-center-center',
      timeOut: 30000,
      extendedTimeOut: 30000
    });
  }


}
