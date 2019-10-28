import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User, Login } from '../model/user';
import { HttpClient, JsonpInterceptor } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User>; // Subject in rxjs
  private currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentToken')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get CurrnetUserHasValue(): User { // check isLogin
    var userValue = this.currentUserSubject.value;
    return userValue;
  }

  login(body: Login) {
    return this.http.post<any>(`${environment.url}/api/Accounts/Login`, body)
      .pipe(map(res => {
        localStorage.setItem('currentToken', JSON.stringify(res.data.AuthToken)); // add output to localStogae 
        // 
        //this.currentUserSubject.next(res.data.AuthToken)
      }))
  }

  logout() {
    localStorage.removeItem('currentToken');
    this.currentUserSubject.next(null);
  }
}
