import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import * as moment from 'moment';

@Component({
  selector: 'app-custom-date-picker',
  templateUrl: './custom-date-picker.component.html',
  styleUrls: ['./custom-date-picker.component.scss']
})
export class CustomDatePickerComponent implements OnInit {

  constructor() { }

  @Output()
  date: EventEmitter<string> = new EventEmitter<string>();

  selectedDate:Date;

  ngOnInit() {
    // this.selectedDate = new Date()
    this.selectedDate = new Date('2019-05-12')
    this.emmitDateEvent();
  }

  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.emmitDateEvent();    
  }  

  prev() {
    this.selectedDate = moment(this.selectedDate).add(-1,'days').toDate()
    this.emmitDateEvent();    
  }

  next() {
    this.selectedDate = moment(this.selectedDate).add(1,'days').toDate()
    this.emmitDateEvent();
  }

  emmitDateEvent(){
    this.date.emit(moment(this.selectedDate).format('YYYY-MM-DD'));
  }
}
