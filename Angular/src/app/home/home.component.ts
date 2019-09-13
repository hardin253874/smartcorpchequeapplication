import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {cheque} from '../models/cheque';
import {HomeService} from './home.service';
import {HttpResponse} from '@angular/common/http';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { trigger, state, style, transition, animate } from '@angular/animations';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [
    trigger('slideInOut', [
      state('in', style({
        transform: 'translate3d(0, 0, 0)'
      })),
      state('out', style({
        transform: 'translate3d(100%, 0, 0)'
      })),
      transition('in => out', animate('400ms ease-in-out')),
      transition('out => in', animate('400ms ease-in-out'))
    ])
  ]
})
export class HomeComponent implements OnInit {
  public chequeForm: FormGroup;
  constructor(
    private homeService: HomeService
  ) { }
  cheque: any;
  chequeDate: Date;
  payee: string = 'test';
  amount: number;
  isCreated: boolean = false;
  errorMessage: string = '';
  ngOnInit() {
    this.isCreated = false;
    this.errorMessage = '';
    this.cheque = null;
    const numericNumberReg= '^-?[0-9]\\d*(\\.\\d{1,2})?$';
    this.chequeForm = new FormGroup({
      payee: new FormControl('', [Validators.required, Validators.minLength(2)]),
      chequeDate: new FormControl('', [Validators.required]),
      amount: new FormControl('', [Validators.required, Validators.pattern(numericNumberReg)])
    });
  }

  public hasError = (controlName: string, errorName: string) =>{
    return this.chequeForm.controls[controlName].hasError(errorName);
  }

  public createCheque = (ownerFormValue) => {
    if (this.chequeForm.valid) {
      this.isCreated = false;
      this.errorMessage = '';
      this.cheque = null;
      this.homeService.createCheque(ownerFormValue.chequeDate, ownerFormValue.payee, ownerFormValue.amount).then(result => {
        const response = result as HttpResponse<cheque>;
        this.isCreated = true;
        if (!response) {
          this.errorMessage = 'Cannot create cheque';
          return;
        }

        this.cheque = response;
      }).catch(error => {
        if (error) {
          this.isCreated = true;
          this.cheque = null;
          this.errorMessage = error.error;
        }
      });
    }
  }
}

export interface ChequeForCreation {
  payee: string;
  chequeDate: Date;
  amount: number;
}
