import { Component, OnInit } from '@angular/core';
import {FamilyTreeApiService} from "./services/family-tree-api.service";
import {Person} from "./interfaces/person";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public persons: Person[] = [];

  constructor(private familyTreeService: FamilyTreeApiService) {}

  ngOnInit() {
    this.getPeople();
  }

  getPeople() {
    this.familyTreeService.getFamilyTree().subscribe(
      (result) => {
        this.persons = result.data;
      },
      (error) => {
        console.log(error);
      }
    )
  }
}
