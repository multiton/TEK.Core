import { HttpClient } from "@angular/common/http";
import { HttpErrorResponse } from "@angular/common/http";

import { environment } from "../environments/environment";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/catch';

export abstract class RestServiceBase<T>
{   
    constructor(protected http: HttpClient, protected actionUrl: string) { }
  
    getAll() : Observable<T[]>
    {
        return this.http
            .get<T[]>(`${environment.apiEndpoint}${this.actionUrl}`)
            .catch(this.handleError);
    }

    getSingle(id: number) : Observable<T>
    {
        return this.http
            .get<T>(`${environment.apiEndpoint}${this.actionUrl}/${id}`)
            .catch(this.handleError);
    }

    post<T>(item: T)
    {
        return this.http
            .post<T>(`${environment.apiEndpoint}${this.actionUrl}`, item)
            .catch(this.handleError);
    }
    
    put<T>(id: number, item: T)
    {
        return this.http
            .put<T>(`${environment.apiEndpoint}${this.actionUrl}/${id}`,item)
            .catch(this.handleError);;
    }
    
    delete(id: number) : Observable<T>
    {
        return this.http
            .delete(`${environment.apiEndpoint}${this.actionUrl}/${id}`)
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse)
    {
        console.log(err.message);
        return Observable.throw(err);
    }
}