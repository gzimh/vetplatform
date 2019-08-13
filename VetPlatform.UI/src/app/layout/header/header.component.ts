import { Component, OnInit, Input } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent implements OnInit {
  @Input()
  name:string;
  @Input()
  theme:string;

  loggedIn: boolean;

  constructor(private oauthService: OAuthService) { }

  ngOnInit() {
    this.loggedIn = this.oauthService.hasValidIdToken() &&
      this.oauthService.hasValidAccessToken();
  }

  logOut() {
    this.oauthService.logOut()
  }

  logIn(){
    alert("logged in clicked.")
  }

}
