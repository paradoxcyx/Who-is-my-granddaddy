import { Injectable } from '@angular/core';
import {Service} from "../service";
import { HttpClient } from '@angular/common/http';
import {GenericResponseModel} from "../../interfaces/generic-response-model";
import {FamilyMember} from "../../interfaces/family-member";
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

  getDescendants(identityNumber: string | null, pageNumber: number | null) {
    let url = `${this.baseApiUrl}/familytree/getDescendants`;

    if (identityNumber) {
      url += `?identityNumber=${identityNumber}`;
    }

    if (pageNumber && identityNumber) {
      url += `&pageNumber=${pageNumber}`;
    }
    else if (pageNumber && !identityNumber) {
      url += `?pageNumber=${pageNumber}`;
    }

    return this.httpClient.get<GenericResponseModel<FamilyMember[]>>(url);
  }
}
