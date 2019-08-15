import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookingsComponent } from './bookings/bookings.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { BookNowComponent } from './book-now/book-now.component';
import { AuthGuardService } from './shared/auth.guard';

const routes: Routes = [
  {
    path:'',
    component: HomeComponent
  },
  {
    path:'register',
    component: RegisterComponent
  },
  {
    path:'book-now',
    component: BookNowComponent,
    canActivate:[AuthGuardService]
  },
  {
    path: 'admin',
   loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
