import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material.module';
import { OAuthModule } from 'angular-oauth2-oidc';
import { AuthService } from '../shared/auth.service';
import { AuthInterceptor } from '../shared/auth.interceptor';
import { Routes, RouterModule } from '@angular/router';
import { BookingsComponent } from '../bookings/bookings.component';
import { CustomDatePickerComponent } from '../custom-date-picker/custom-date-picker.component';
import { BookingItemComponent } from '../bookings/booking-item/booking-item.component';
import { ChangeStatusComponent } from '../bookings/change-status/change-status.component';

const routes: Routes = [
  {
    path: 'bookings',
    component: BookingsComponent
  },
];

@NgModule({
  declarations: [
    AdminComponent,
    BookingsComponent,
    CustomDatePickerComponent,
    BookingItemComponent,
    ChangeStatusComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule.forRoot(routes),
    OAuthModule.forRoot()
  ],
  exports: [],
  providers: [AuthService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
})
export class AdminModule { }
