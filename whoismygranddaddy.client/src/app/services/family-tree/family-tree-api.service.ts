import { Injectable } from '@angular/core';
import {GenericResponseModel} from "../../interfaces/generic-response-model";
import {Service} from "../service";
import { HttpClient } from '@angular/common/http';
import {FamilyMember} from "../../interfaces/family-member";
@Injectable({
  providedIn: 'root'
})
export class FamilyTreeApiService extends Service {

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  getFamilyTree() {
    return this.httpClient.get<GenericResponseModel<FamilyMember[]>>(`${this.baseApiUrl}/familytree`);
  }

  getRootAscendants(identityNumber: string) {
    return this.httpClient.get<GenericResponseModel<FamilyMember[]>>(`${this.baseApiUrl}/familytree/getRootAscendants?identityNumber=${identityNumber}`)
  }

  getDescendants(identityNumber: string | null) {
    let url = `${this.baseApiUrl}/familytree/getDescendants`;

    if (identityNumber) {
      url += `?identityNumber=${identityNumber}`;

    }
    return this.httpClient.get<GenericResponseModel<FamilyMember[]>>(url)
  }
}
