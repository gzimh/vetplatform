import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookingsService } from '../services/bookings.service';
import { ScheduleOption } from '../models/schedule-option';
import * as moment from 'moment';
import { MatSnackBar } from '@angular/material';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-book-now',
  templateUrl: './book-now.component.html',
  styleUrls: ['./book-now.component.scss'],
  providers: [BookingsService]
})
export class BookNowComponent implements OnInit {

  form: FormGroup;
  minDate: Date = new Date();
  scheduleOptions: ScheduleOption[];

  constructor(private fb: FormBuilder,
    private bookingsService: BookingsService,
    private snackbar: MatSnackBar) { }

  ngOnInit() {
    this.form = this.fb.group({
      date: [null, [Validators.required]],
      time: [null, [Validators.required]],
      reason: [null, []]
    });
  }

  public dateChanged(){
    let selectedDate = this.form.controls.date.value;
    if(selectedDate) {
      let date = moment(selectedDate).format('YYYY-MM-DD');
      this.bookingsService.getSchedule(date).subscribe(result => {
        this.scheduleOptions = result;
        console.log(result)
      }, error => console.log(error));
    }
  }

  save() {
    let formValue = this.form.value;
    console.log(formValue);
    // this.bookingsService.bookNow(formValue).subscribe(result => {
    //   if (result) {
    //     this.snackbar.open("Success: booked!", 'OK', {
    //       duration: 3000
    //     });
    //   }
    // }, error => {
    //   console.log(error);
    //   this.snackbar.open('Something went wrong.', 'OK', {
    //     duration: 3000
    //   });
    // });
  }

}
