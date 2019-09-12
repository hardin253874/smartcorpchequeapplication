import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';
import {Observable} from "rxjs";
import { environment } from '../../environments/environment';
import {cheque} from '../models/cheque';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Access-Control-Allow-Origin': '*'
  })
};
const webApiUrl = environment.serverUrl + 'api/cheque/';
@Injectable()
export class HomeService {
  constructor(private http: HttpClient) { }

  public getTestCheque(): Promise<HttpResponse<cheque>> {
    return this.http.get<HttpResponse<cheque>>(webApiUrl + 'test', httpOptions ).toPromise();
  }

  public getErrorCheque(): Promise<HttpResponse<cheque>> {
    return this.http.get<HttpResponse<cheque>>(webApiUrl + 'error', httpOptions ).toPromise();
  }

  public createCheque(chequeDate: Date, payee: string, amount: number): Promise<HttpResponse<cheque>> {
    const requestDto = { ChequeDate: chequeDate, Payee: payee, Amount: amount };

    return this.http.post<HttpResponse<cheque>>(webApiUrl + 'create', requestDto, httpOptions ).toPromise();
  }
}
