import { Injectable } from '@angular/core';
import {Service} from "../service";
import { HttpClient, HttpParams } from '@angular/common/http';
import {GenericResponseModel} from "../../interfaces/generic-response-model";
import {FamilyMember} from "../../interfaces/family-member";
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class FamilyTreeApiService extends Service {

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  getRootAscendants(identityNumber: string) {
    return this.httpClient.get<GenericResponseModel<FamilyMember[]>>(`${this.baseApiUrl}/familytree/getRootAscendants?identityNumber=${identityNumber}`)
  }

  getDescendants(identityNumber: string | null, pageNumber: number | null): Observable<GenericResponseModel<FamilyMember[]>> {
    let params = new HttpParams();

    if (identityNumber) {
      params = params.set('identityNumber', identityNumber);
    }

    if (pageNumber != null) {
      params = params.set('pageNumber', pageNumber.toString());
    }

    const url = `${this.baseApiUrl}/familytree/getDescendants`;
    return this.httpClient.get<GenericResponseModel<FamilyMember[]>>(url, { params });
  }
}
