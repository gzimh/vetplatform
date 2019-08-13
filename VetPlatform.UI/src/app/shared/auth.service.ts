import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { authConfig } from './auth.config';

@Injectable()
export class AuthService {
    loading: boolean;
    constructor(private oauthService: OAuthService){
    }

    private $source = new BehaviorSubject<CurrentUser>({});
    public user = this.$source.asObservable();
    public setUser = (claims:any) => {
        if(claims == null) throw new Error("Claims are required to build the current user instance.");
        const user = {
            username: claims.username,
            role: claims.role
        }
        this.$source.next(user);
        return user;
    }

    public auth() {
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
            // if (this.oauthService.state) {
            //   this.router.navigate([this.oauthService.state]);
            // }

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

    public isAuthenticated(){
      return this.oauthService.hasValidAccessToken() && this.oauthService.hasValidIdToken();
    }

    private initCurrentUser() {
      const claims = this.oauthService.getIdentityClaims();
      if (this.oauthService.hasValidAccessToken() && claims)
        this.setUser(this.oauthService.getIdentityClaims());
    }
}

export interface CurrentUser{
    username?:string,
    role?:string
}
