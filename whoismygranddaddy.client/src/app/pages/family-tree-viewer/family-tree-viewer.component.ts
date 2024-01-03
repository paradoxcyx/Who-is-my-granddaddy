import {AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import {FamilyTreeApiService} from "../../../shared/services/family-tree/family-tree-api.service";
import {FamilyMember} from "../../../shared/interfaces/family-member";
import {TreeViewerComponent} from "../../components/tree-viewer/tree-viewer.component";
import {EMPTY, finalize } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-family-tree-viewer',
  templateUrl: './family-tree-viewer.component.html',
  styleUrl: './family-tree-viewer.component.css'
})
export class FamilyTreeViewerComponent implements OnInit {
  @ViewChild('treeviewer') TreeViewer: TreeViewerComponent | undefined;

  familyMembers: FamilyMember[] = [];

  searchByIdentityNumber: string | null = null;

  page = {
    isLoading: true,
    hasError: false,
    error: ''
  }

  constructor(private familyTreeService: FamilyTreeApiService) {
  }
  ngOnInit() {
    this.loadFamilyMembers();
  }

  loadFamilyMembers() {
    this.page.isLoading = true;
    this.page.hasError = false;
    this.page.error = '';

    this.familyTreeService.getDescendants(this.searchByIdentityNumber)
      .pipe(
        catchError((errorCtx) => {
          this.page.hasError = true;
          this.page.error = errorCtx.error.message;

          return EMPTY;
        }),
        finalize(() => {
          this.page.isLoading = false;
        })
      )
      .subscribe((result) => {
        this.familyMembers = result.data;
        this.TreeViewer!.loadFamilyMembers(this.familyMembers);
      });

  }

  search() {
    this.loadFamilyMembers();
  }

  clear() {
    this.searchByIdentityNumber = null;
    this.loadFamilyMembers();
  }
}
