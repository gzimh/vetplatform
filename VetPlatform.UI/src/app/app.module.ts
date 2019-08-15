import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material.module'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './layout/header/header.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChangeStatusComponent } from './bookings/change-status/change-status.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AdminModule } from './admin/admin.module';
import { AppService } from './services/app.service';
import { BookNowComponent } from './book-now/book-now.component';
import { AuthGuardService } from './shared/auth.guard';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    RegisterComponent,
    BookNowComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    AdminModule
  ],
  providers: [
    AppService,
    AuthGuardService],
  bootstrap: [AppComponent],
  entryComponents: [ChangeStatusComponent]
})
export class AppModule { }
