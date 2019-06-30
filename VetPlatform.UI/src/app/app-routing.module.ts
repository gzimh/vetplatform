import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookingsComponent } from './bookings/bookings.component';

const routes: Routes = [
  {
    path:'',
    redirectTo:'bookings',
    pathMatch:'full'
  },
  {
    path: 'bookings',
    component: BookingsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }