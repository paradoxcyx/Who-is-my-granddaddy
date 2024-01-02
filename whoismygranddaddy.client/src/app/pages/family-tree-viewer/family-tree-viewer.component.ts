import {AfterViewInit, Component, OnInit } from '@angular/core';
import {FamilyTreeApiService} from "../../../shared/services/family-tree/family-tree-api.service";
import {FamilyMember} from "../../../shared/interfaces/family-member";


@Component({
  selector: 'app-family-tree-viewer',
  templateUrl: './family-tree-viewer.component.html',
  styleUrl: './family-tree-viewer.component.css'
})
export class FamilyTreeViewerComponent implements OnInit {

  familyMembers: FamilyMember[] = [];

  constructor(private familyTreeService: FamilyTreeApiService) {
  }
  ngOnInit() {
    this.loadFamilyMembers();
  }

  loadFamilyMembers() {
    this.familyTreeService.getDescendants(null)
      .subscribe((result) => {
        this.familyMembers = result.data;
      })
  }
}
