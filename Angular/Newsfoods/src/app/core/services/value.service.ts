import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

import { environment } from '../../../environments/environment';


@Injectable({ providedIn: 'root' })
export class ValueService {
    constructor(private http: HttpClient){}

    getAll(): Observable<any>{
        return this.http.get<any>(`${environment.apiUrl}/api/Values`);
    }
}