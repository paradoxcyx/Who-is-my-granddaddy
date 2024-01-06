import { Component, OnInit, ViewChild } from '@angular/core';
import {Page} from "../page";
import {TreeViewerComponent} from "../../components/tree-viewer/tree-viewer.component";
import {FamilyTreeApiService} from "../../../shared/services/family-tree/family-tree-api.service";
import {EMPTY, catchError, finalize } from 'rxjs';
import {FamilyMember} from "../../../shared/interfaces/family-member";

@Component({
  selector: 'app-root-ascendant',
  templateUrl: './root-ascendant.component.html',
  styleUrl: './root-ascendant.component.css'
})
export class RootAscendantComponent extends Page implements OnInit {
  @ViewChild('treeviewer') TreeViewer: TreeViewerComponent | undefined;
  searchByIdentityNumber: string = '';

  rootAscendants: FamilyMember[] = [];

  constructor(private familyTreeService: FamilyTreeApiService) {
    super();
  }
  ngOnInit(): void {

  }

  override search(): void {
    if (!this.searchByIdentityNumber) {
      this.page.hasError = true;
      this.page.error = 'Identity number required search for ascendants';
    }

    this.loadRootAscendants();
  }
  override clearSearch(): void {
    this.searchByIdentityNumber = '';
  }

  loadRootAscendants() {
    this.initLoading();

    this.familyTreeService.getRootAscendants(this.searchByIdentityNumber)
      .pipe(
        catchError((errorCtx) => {
          this.showError(errorCtx.error.message);

          this.rootAscendants = [];
          this.TreeViewer!.clearFamilyTree();

          return EMPTY;
        }),
        finalize(() => {
          this.page.isLoading = false;
        })
      )
      .subscribe((result) => {
        this.rootAscendants = result.data;
        this.TreeViewer!.loadFamilyMembers(this.rootAscendants);
      });

  }

}
