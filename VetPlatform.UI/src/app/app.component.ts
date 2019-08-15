import { Component, OnInit } from '@angular/core';
import { AppService } from './services/app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'vetplatform-client';
  loading: boolean = true;
  appInfo: any;
  error: boolean;

  constructor(private appSevice: AppService) {
  }

  ngOnInit(): void {
    this.appSevice.getStoreInfo().subscribe(result => {
      this.loading = false;
      this.appInfo = result;

    },error => {
      this.error = true;
      this.loading = false;
      console.log(error);
    })
  }
}
