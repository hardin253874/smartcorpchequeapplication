import { Component, OnInit } from '@angular/core';
import {cheque} from '../models/cheque';
import {HomeService} from './home.service';
import {HttpResponse} from '@angular/common/http';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    private homeService: HomeService
  ) { }
  cheque: cheque;
  ngOnInit() {
    const that = this;
    this.homeService.getErrorCheque().then(result => {
      const response = result as HttpResponse<cheque>;
      if (response){

      }
    }).catch(error => {
      if (error) {
        const errorMessage = error.error;
      }
    });
  }

}
