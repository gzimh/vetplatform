import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material';
import { BookingsService } from 'src/app/services/bookings.service';

@Component({
  selector: 'app-change-status',
  templateUrl: './change-status.component.html',
  styleUrls: ['./change-status.component.scss'],
  providers: [BookingsService]
})
export class ChangeStatusComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) private data: any,
    public dialogRef: MatDialogRef<ChangeStatusComponent>,
    private bookingsService: BookingsService) { }

  ngOnInit() {
  }

  changeStatus(value:string){
    this.bookingsService.changeBookingStatus({
      bookingId: this.data.bookingId,
      status: value
    }).subscribe(result => {
      if(result && result.success) {
        this.dialogRef.close(result.payload);
      }
    }, error => {
      console.log(error);
      this.dialogRef.close();
    })
  }

}

