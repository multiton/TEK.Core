import { HttpClient } from "@angular/common/http";
import { HttpErrorResponse } from "@angular/common/http";

import { environment } from '@env/environment';

import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/catch';

export abstract class RestServiceBase<T>
{   
    private apiUrl : string;

    constructor(protected http: HttpClient, protected actionUrl: string)
    {
        this.apiUrl = `${environment.apiEndpoint}${this.actionUrl}`;
    }
  
    getAll() : Observable<T[]>
    {
        return this.http.get<T[]>(this.apiUrl).catch(this.handleError);
    }

    getSingle(id: number) : Observable<T>
    {
        return this.http.get<T>(`${this.apiUrl}/${id}`).catch(this.handleError);
    }

    getFiltered(filter: string) : Observable<T[]>
    {
        return this.http.get<T[]>(`${this.apiUrl}/${filter}`).catch(this.handleError);
    }

    post<T>(item: T) : Observable<T>
    {
        return this.http.post<T>(this.apiUrl, item).catch(this.handleError);
    }
    
    put<T>(id: number, item: T) : Observable<T>
    {
        return this.http.put<T>(`${this.apiUrl}/${id}`, item).catch(this.handleError);
    }
    
    delete(id: number) : Observable<T>
    {
        return this.http.delete(`${this.apiUrl}/${id}`).catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse)
    {
        console.log(err.message);
        return Observable.throw(err);
    }
}