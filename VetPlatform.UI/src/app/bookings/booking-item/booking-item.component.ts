import { Component, OnInit, Input } from '@angular/core';
import { Booking } from 'src/app/models/bookings.response.model';
import { MatDialog } from '@angular/material';
import { ChangeStatusComponent } from '../change-status/change-status.component';

@Component({
  selector: 'app-booking-item',
  templateUrl: './booking-item.component.html',
  styleUrls: ['./booking-item.component.scss']
})
export class BookingItemComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  @Input()
  booking: Booking

  ngOnInit() {
  }

  changeStatus(): void {
    const dialogRef = this.dialog.open(ChangeStatusComponent, {
      data: {
        bookingId: this.booking.id
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.booking.status = result;
      }
    });
  }

}
