import { Component, OnInit } from '@angular/core';
import { AppService } from './services/app.service';
import { authConfig } from './shared/auth.config';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';

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

  constructor(private oauthService: OAuthService, private appSevice: AppService) {
    this.configureOAuthService();
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

  private configureOAuthService() {
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin()
  }

  accessToken(){
    return this.oauthService.getAccessToken();
  }
}
