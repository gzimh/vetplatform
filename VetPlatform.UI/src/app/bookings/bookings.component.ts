import { Component, OnInit } from '@angular/core';
import { BookingsService } from '../services/bookings.service';
import { Booking } from '../models/bookings.response.model';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.scss'],
  providers: [BookingsService]
})
export class BookingsComponent implements OnInit {
  bookings: Booking [];
  hasMore: boolean;
  loading:boolean;

  constructor(private bookingsService: BookingsService) {
  }

  date:string;
  skip: number = 0;
  take: number = 3;
  status:string[] = ["pending", "done", "canceled"];

  ngOnInit() {
  }

  onDateChange(date:string) {
    this.date = date;
    this.skip = 0;
    this.bookings = [];
    this.loadBookings();
  }

  loadBookings() {
    this.loading = true;

    if(this.status.length < 1){
      this.bookings = [];
      this.hasMore = false;
      this.loading = false;
      return;
    }

    this.bookingsService.getBookings({
      date: this.date,
      skip: this.skip,
      take: this.take,
      status:this.status
    }).subscribe(res => {
      console.log(res)
      if(res && res.success){
        if(this.bookings)
          this.bookings = [...this.bookings, ...res.payload];
        else
          this.bookings = res.payload;

        this.hasMore = res.hasMore;
      }
      this.loading = false;
    },error => {
      this.loading = false;
      console.log(error)
    })
  }

  loadMore () {
    this.skip = this.skip + this.take;
    this.loadBookings();
  }

  onFilterChange(){
    this.bookings = [];
    this.loadBookings();
  }
}
