import { Component, OnInit } from '@angular/core';
import { AppService } from './services/app.service';
import { AuthService } from './shared/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'vetplatform-client';
  loading: boolean = true;
  appInfo: any;

  constructor(private appSevice: AppService, private authService: AuthService) {
  }

  ngOnInit(): void {
    this.appSevice.getStoreInfo().subscribe(result => {
      this.loading = false;
      this.appInfo = result;
    })
  }
}
