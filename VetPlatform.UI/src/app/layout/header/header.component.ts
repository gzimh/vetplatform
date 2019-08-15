import { Component, OnInit, Input } from '@angular/core';
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

  constructor() { }

  ngOnInit() {
  }

  logOut() {
    alert("log out in clicked.")
  }

  logIn(){
    alert("log in clicked.")
  }

}
