import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MaterialModule} from './material.module'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { HeaderComponent } from './layout/header/header.component';
import { BookingsComponent } from './bookings/bookings.component';
import { HttpClientModule } from '@angular/common/http';
import { CustomDatePickerComponent } from './custom-date-picker/custom-date-picker.component';
import { FormsModule } from '@angular/forms';
import { BookingItemComponent } from './bookings/booking-item/booking-item.component';
import { ChangeStatusComponent } from './bookings/change-status/change-status.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { AuthService } from './shared/auth.service';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BookingsComponent,
    CustomDatePickerComponent,
    BookingItemComponent,
    ChangeStatusComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    OAuthModule.forRoot()
  ],
  providers: [AuthService],
  bootstrap: [AppComponent],
  entryComponents: [ChangeStatusComponent]
})
export class AppModule { }
