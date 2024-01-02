import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FamilyTreeViewerComponent} from "./family-tree-viewer/family-tree-viewer.component";
import {ComponentsModule} from "../components/components.module";

@NgModule({
  declarations: [FamilyTreeViewerComponent],
  imports: [
    CommonModule,
    ComponentsModule

  ],
  exports: [FamilyTreeViewerComponent]
})
export class PagesModule { }
