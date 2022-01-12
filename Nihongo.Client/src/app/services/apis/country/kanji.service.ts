import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Kanji } from 'src/app/interfaces/Kanji';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class KanjiService {

  UNAUTHORIZED : number = 401;

  baseUrl = "https://localhost:44366/"

  constructor(private _httpClient: HttpClient) { }

  getKanji(): Observable<Kanji[]> {
    return this._httpClient.get<Kanji[]>(this.baseUrl + "Kanji").pipe(
      catchError(
        this.handleError<Kanji[]>("fetch Kanji", [])
      )
    )
  }
  login(credentials: any): Observable<any> {
    return this._httpClient.post(this.baseUrl + "api/Auth/login", credentials)
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      if(!error.ok) {
        const statusCode = error.status
        if(statusCode == this.UNAUTHORIZED)
          this.refreshToken().subscribe({
            next: (response) => {
              console.log("helloer");
              localStorage.setItem("jwt", JSON.stringify(response))
            },
            error: (error) => {
              console.log("REFESH TOKEN ERROR", error)
            }
          })
      }

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  private refreshToken(): Observable<any> {
    try {
      const jwt = JSON.parse(localStorage.getItem("jwt")!)

      return this._httpClient.post(this.baseUrl + "api/Auth/refresh", {
        token: jwt.token,
        refreshToken: jwt.refreshToken
      })
    }
    catch (err) {
        throw(err)
    }

  }
}
