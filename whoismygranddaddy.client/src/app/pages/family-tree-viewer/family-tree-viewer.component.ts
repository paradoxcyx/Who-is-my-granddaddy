import {AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import {FamilyTreeApiService} from "../../../shared/services/family-tree/family-tree-api.service";
import {FamilyMember} from "../../../shared/interfaces/family-member";
import {TreeViewerComponent} from "../../components/tree-viewer/tree-viewer.component";
import {EMPTY, finalize } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {Page} from "../page";
import { faChevronLeft, faChevronRight } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-family-tree-viewer',
  templateUrl: './family-tree-viewer.component.html',
  styleUrl: './family-tree-viewer.component.css'
})
export class FamilyTreeViewerComponent extends Page implements OnInit {
  @ViewChild('treeviewer') TreeViewer: TreeViewerComponent | undefined;

  familyMembers: FamilyMember[] = [];
  searchByIdentityNumber: string | null = null;

  constructor(private familyTreeService: FamilyTreeApiService) {
    super();
  }
  ngOnInit() {
    this.loadFamilyMembers();
  }

  loadFamilyMembers() {
    this.page.isLoading = true;
    this.page.hasError = false;
    this.page.error = '';

    this.familyTreeService.getDescendants(this.searchByIdentityNumber, this.page.paging.pageNumber)
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
        console.log(JSON.stringify(result));
        this.familyMembers = result.data;
        this.TreeViewer!.loadFamilyMembers(this.familyMembers);

        this.page.paging.maxPages = result.maxPages;
        this.page.paging.pageNumber = result.page;
      });

  }

  override search(): void {
    this.loadFamilyMembers();
  }

  override clearSearch(): void {
    this.searchByIdentityNumber = null;
    this.loadFamilyMembers();
  }

  nextPage(): void {
    if (this.page.paging.pageNumber >= this.page.paging.maxPages) {
      return;
    }

    this.page.paging.pageNumber++;
    this.loadFamilyMembers();
  }

  prevPage(): void {
    if (this.page.paging.pageNumber <= 1)
    {
      return;
    }

    this.page.paging.pageNumber--;
    this.loadFamilyMembers();
  }

  protected readonly faChevronLeft = faChevronLeft;
  protected readonly faChevronRight = faChevronRight;
}
