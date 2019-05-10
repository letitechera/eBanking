import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EBankingService {

  public userId = 1;
  public headers: HttpHeaders;
  // Cambiar por el puerto local de la Web API:
  public baseUrl = 'http://localhost:57934/api';

  constructor(private http: HttpClient) { }

  public getUserAccounts(): Promise<any> {
    return new Promise<any>((resolve, reject) => {
      this.getCompleteEventData(this.userId)
        .pipe(map((results: any[]) => {
          if (results == null) {
            return null;
          }
          return results;
        })).subscribe((data: any[]) => {
          resolve(data);
        },
          (err) => {
            reject([]);
          });
    });
  }

  public postTransference(transference: any) {
    return new Promise<any>((resolve, reject) => {
      this.postEventData(transference).subscribe((result) => {
        resolve(result);
      }, (err) => {
        reject(err);
      });
    });
  }

  private getCompleteEventData(id) {
    this.setDefaultHeaders();
    const url = `${this.baseUrl}/transferences/user/${id}/accounts`;
    return this.commonHttpGet(url, this.headers);
  }

  private postEventData(data) {
    this.setDefaultHeaders();
    const url = `${this.baseUrl}/transferences/send`;
    return this.commonHttpPost(url, data, this.headers);
  }

  private setDefaultHeaders() {
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
  }

  private commonHttpGet(url: string, headers: HttpHeaders) {
    return this.http.get(url, { headers });
  }

  private commonHttpPost(url: string, data: any, headers: HttpHeaders) {
    return this.http.post(url, data, { headers });
  }

}
