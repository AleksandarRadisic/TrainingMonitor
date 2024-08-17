import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { stringify } from 'querystring';
import { User } from '../model/user';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl: string = environment.backendBaseUrl + "Users/"

  constructor(private http: HttpClient, private router: Router) { }

  login(model: any): any {
    return this.http.post<string>(this.baseUrl + 'login', model, { responseType: 'text' as 'json' }).pipe(
      map((response: string) => {
        localStorage.setItem('token', response)
        return response
      })
    );
  }

  loggedUser(): any {
    const token = localStorage.getItem('token')
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`)
    return this.http.get(this.baseUrl + 'logged', { headers }).pipe(
      map((response: any) =>{
        console.log(response)
        if (!response){
          this.router.navigate(['/login']);
        }
        return response
      }),
      catchError(err => {
        console.log(err)
        this.router.navigate(['/login']);
        return throwError(err);
      })
    )
  }
}
