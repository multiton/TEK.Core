import { HttpClient } from "@angular/common/http";
import { HttpErrorResponse } from "@angular/common/http";

import { environment } from "../environments/environment";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/catch';

export abstract class RestServiceBase<T>
{   
    private baseUrl : string;

    constructor(protected http: HttpClient, protected actionUrl: string)
    {
        this.baseUrl = `${environment.apiEndpoint}${this.actionUrl}`;
    }
  
    getAll() : Observable<T[]>
    {
        return this.http.get<T[]>(this.baseUrl).catch(this.handleError);
    }

    getSingle(id: number) : Observable<T>
    {
        return this.http.get<T>(`${this.baseUrl}/${id}`).catch(this.handleError);
    }

    post<T>(item: T) : Observable<T>
    {
        return this.http.post<T>(this.baseUrl, item).catch(this.handleError);
    }
    
    put<T>(id: number, item: T) : Observable<T>
    {
        return this.http.put<T>(`${this.baseUrl}/${id}`, item).catch(this.handleError);
    }
    
    delete(id: number) : Observable<T>
    {
        return this.http.delete(`${this.baseUrl}/${id}`).catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse)
    {
        console.log(err.message);
        return Observable.throw(err);
    }
}