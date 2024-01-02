import {AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import {FamilyTreeApiService} from "../../../shared/services/family-tree/family-tree-api.service";
import {FamilyMember} from "../../../shared/interfaces/family-member";
import {TreeViewerComponent} from "../../components/tree-viewer/tree-viewer.component";


@Component({
  selector: 'app-family-tree-viewer',
  templateUrl: './family-tree-viewer.component.html',
  styleUrl: './family-tree-viewer.component.css'
})
export class FamilyTreeViewerComponent implements OnInit {
  @ViewChild('treeviewer') TreeViewer: TreeViewerComponent | undefined;

  familyMembers: FamilyMember[] = [];
  searchByIdentityNumber: string | null = null;

  constructor(private familyTreeService: FamilyTreeApiService) {
  }
  ngOnInit() {
    this.loadFamilyMembers();
  }

  loadFamilyMembers() {
    this.familyTreeService.getDescendants(this.searchByIdentityNumber)
      .subscribe((result) => {
        this.familyMembers = result.data;
        this.TreeViewer!.loadFamilyMembers(this.familyMembers);
      })
  }
}
