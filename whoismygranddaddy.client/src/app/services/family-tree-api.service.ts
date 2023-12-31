import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Person} from "../interfaces/person";
import {GenericResponseModel} from "../interfaces/generic-response-model";

@Injectable({
  providedIn: 'root'
})
export class FamilyTreeApiService {

  private baseApiUrl = 'https://localhost:7258/familytree';

  constructor(private http: HttpClient) {}

  getFamilyTree() {
    return this.http.get<GenericResponseModel<Person[]>>(`${this.baseApiUrl}`);
  }

  getRootAscendants(identityNumber: string) {
    return this.http.get<GenericResponseModel<Person[]>>(`${this.baseApiUrl}/getRootAscendants?identityNumber=${identityNumber}`)
  }

  getDescendants(identityNumber: string) {
    return this.http.get<GenericResponseModel<Person[]>>(`${this.baseApiUrl}/getDescendants?identityNumber=${identityNumber}`)
  }
}
