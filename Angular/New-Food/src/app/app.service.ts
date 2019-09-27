import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  url: string;
  constructor(
    private http: HttpClient
  ) 
  {
    this.url = environment.url;
  }
  //  getDataWithId(id: number) : Observable<any> {
  //    const apiUrl = `${this.url}/api/Values/${id}`;
  //   return this.http.get(apiUrl);
  //  } 
  //  getData() : Observable<any> { 
  //   const apiUrl = `${this.url}/api/Values`
  //  return this.http.get(apiUrl);
  // } 

}
