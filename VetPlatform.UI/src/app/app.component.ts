import { Component } from '@angular/core';
import { OAuthService, JwksValidationHandler, AuthConfig } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { AuthService } from './shared/auth.service';
import { authConfig } from './shared/auth.config';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'vetplatform-client';
  loading: boolean;

  constructor(private oauthService: OAuthService,
    private router: Router,
    private authService: AuthService) {
    if (!this.oauthService.hasValidAccessToken())
      this.auth(authConfig);
  }

  private auth(authConfig) {
    this.loading = true;
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    const discoveryDocUrl = `${authConfig.issuer}/.well-known/openid-configuration`;
    this.oauthService.loadDiscoveryDocument(discoveryDocUrl).then((doc) => {
      this.oauthService.tryLogin()
        .catch(err => {
          console.error(err);
        })
        .then(() => {
          if (this.oauthService.state) {
            this.router.navigate([this.oauthService.state]);
          }
          if (!this.oauthService.hasValidAccessToken()) {
            this.oauthService.initImplicitFlow()
          }
          else {
            this.initCurrentUser();
            this.loading = false;
          }

        });
    })
    this.oauthService.setupAutomaticSilentRefresh();
  }

  private initCurrentUser() {
    const claims = this.oauthService.getIdentityClaims();
    if (this.oauthService.hasValidAccessToken() && claims)
      this.authService.setUser(this.oauthService.getIdentityClaims());
  }

}
