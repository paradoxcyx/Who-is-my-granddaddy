import { Component, OnInit, ViewChild } from '@angular/core';
import {FamilyTreeApiService} from "../../../shared/services/family-tree/family-tree-api.service";
import {FamilyMember} from "../../../shared/interfaces/family-member";
import {TreeViewerComponent} from "../../components/tree-viewer/tree-viewer.component";
import {EMPTY, finalize } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {Page} from "../page";
import { faChevronLeft, faChevronRight } from '@fortawesome/free-solid-svg-icons';
import {PagedFamilyMembers} from "../../../shared/interfaces/paged-family-members";


@Component({
  selector: 'app-family-tree-viewer',
  templateUrl: './family-tree-viewer.component.html',
  styleUrl: './family-tree-viewer.component.css'
})
export class FamilyTreeViewerComponent extends Page implements OnInit {
  @ViewChild('treeviewer') TreeViewer: TreeViewerComponent | undefined;

  //Using this paged family members array allows us to better manipulate family members by page number
  pagedFamilyMembers: PagedFamilyMembers[] = [];

  searchByIdentityNumber: string | null = null;

  constructor(private familyTreeService: FamilyTreeApiService) {
    super();
  }
  ngOnInit() {
    this.loadFamilyMembers();
  }

  loadFamilyMembers(nextPage: boolean = true) {
    this.initLoading();

    this.familyTreeService.getDescendants(this.searchByIdentityNumber, this.page.paging.pageNumber)
      .pipe(
        catchError((errorCtx) => {
          this.showError(errorCtx.error.message);
          this.TreeViewer!.clearFamilyTree();

          return EMPTY;
        }),
        finalize(() => {
          this.page.isLoading = false;
        })
      )
      .subscribe((result) => {

        if (nextPage) {
          this.addToFamilyMembers(result.page, result.data);
        }
        else {
          this.removeLatestFamilyMembers();
        }

        this.TreeViewer!.loadFamilyMembers(this.pagedFamilyMembers.flatMap((m) => m.familyMembers));

        this.page.paging.maxPages = result.maxPages;
        this.page.paging.pageNumber = result.page;
      });

  }

  addToFamilyMembers(page: number, familyMembers: FamilyMember[]) {

    this.pagedFamilyMembers.push({
      page: page,
      familyMembers: familyMembers
    });

  }

  removeLatestFamilyMembers() {
    this.pagedFamilyMembers.pop();
  }

  override search(): void {
    this.page.paging.pageNumber = 1;
    this.pagedFamilyMembers = [];

    this.loadFamilyMembers();
  }

  override clearSearch(): void {
    this.page.paging.pageNumber = 1;
    this.pagedFamilyMembers = [];
    this.searchByIdentityNumber = null;

    this.loadFamilyMembers();
  }

  nextPage(): void {
    //check if the user already reached max pages
    if (this.page.paging.pageNumber >= this.page.paging.maxPages) {
      return;
    }

    //increasing the page number and loading the next page of family members into the tree
    this.page.paging.pageNumber++;
    this.loadFamilyMembers(true);
  }

  prevPage(): void {
    //Preventing the user from going to the previous page if there aren't any previous pages.
    if (this.page.paging.pageNumber <= 1)
    {
      return;
    }

    //decreasing the page number and loading the previous page of family members
    this.page.paging.pageNumber--;
    this.loadFamilyMembers(false);
  }

  sanitiseFamilyMembers(): void {
    // Loop through each family member in the paged list
    this.pagedFamilyMembers.forEach((fm, ix) => {

      if (ix == 0) {
        let firstFamilyMember = fm.familyMembers[0];

        if (firstFamilyMember) {
          firstFamilyMember.mid = undefined;
          firstFamilyMember.fid = undefined;
        }
      }
      // Loop through each member of the family
      fm.familyMembers.forEach((m) => {
        // Check if both father id (fid) and mother id (mid) are present
        if (m.fid && m.mid) {
          // Find all potential fathers and mothers in the flattened family members list
          const fathers = this.pagedFamilyMembers.flatMap((pfm) => pfm.familyMembers)
            .filter((f) => f.id == m.fid && f.id != m.id);

          const mothers = this.pagedFamilyMembers.flatMap((pfm) => pfm.familyMembers)
            .filter((f) => f.id == m.mid && f.id != m.id);

          // Check if both fathers and mothers exist
          if (fathers.length > 0 && mothers.length > 0) {
            // Take the first father and mother from the filtered lists
            const father = fathers[0];
            const mother = mothers[0];

            // Update father's pids if conditions are met
            if (father && (!father.pids || father.pids.length < 1) && mother) {
              father.pids = [mother.id];
            }

            // Update mother's pids if conditions are met
            if (mother && (!mother.pids || mother.pids.length < 1) && father) {
              mother.pids = [father.id];
            }
          }
        }
      });
    });
  }

  protected readonly faChevronLeft = faChevronLeft;
  protected readonly faChevronRight = faChevronRight;
}
