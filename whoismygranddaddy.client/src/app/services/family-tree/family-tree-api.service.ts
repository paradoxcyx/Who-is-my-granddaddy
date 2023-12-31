import { Injectable } from '@angular/core';
import {GenericResponseModel} from "../../interfaces/generic-response-model";
import {Person} from "../../interfaces/person";
import {Service} from "../service";
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class FamilyTreeApiService extends Service {

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  getFamilyTree() {
    return this.httpClient.get<GenericResponseModel<Person[]>>(`${this.baseApiUrl}/familytree`);
  }

  getRootAscendants(identityNumber: string) {
    return this.httpClient.get<GenericResponseModel<Person[]>>(`${this.baseApiUrl}/familytree/getRootAscendants?identityNumber=${identityNumber}`)
  }

  getDescendants(identityNumber: string) {
    return this.httpClient.get<GenericResponseModel<Person[]>>(`${this.baseApiUrl}/familytree/getDescendants?identityNumber=${identityNumber}`)
  }
}
