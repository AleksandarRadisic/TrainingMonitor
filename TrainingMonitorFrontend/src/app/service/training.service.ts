import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrainingService {
  baseUrl: string = environment.backendBaseUrl + "Training/"

  constructor(private http: HttpClient, private router: Router) { }

  addTraining(model: any): any{
    const token = localStorage.getItem('token')
    if(!token){
      this.router.navigate(['/login']);
    }
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`)
    return this.http.post(this.baseUrl, model, {headers, responseType: "text" as "json"})
  }
}
