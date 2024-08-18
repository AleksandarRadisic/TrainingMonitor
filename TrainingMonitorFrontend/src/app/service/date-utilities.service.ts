import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DateUtilitiesService {

  constructor() { }
  GetDateString(trainingDateTime: Date) : string {
    var date = new Date(trainingDateTime);
    date = new Date(date.getTime() + date.getTimezoneOffset() * 60000);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    return `${year}-${month}-${day} ${hours}:${minutes}`;
  }
}
