import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class AuthService {
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
}

export interface CurrentUser{
    username?:string,
    role?:string
}