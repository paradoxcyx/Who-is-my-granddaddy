import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FamilyTreeViewerComponent} from "./family-tree-viewer/family-tree-viewer.component";
import {ComponentsModule} from "../components/components.module";
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [FamilyTreeViewerComponent],
  imports: [
    CommonModule,
    ComponentsModule,
    FormsModule

  ],
  exports: [FamilyTreeViewerComponent]
})
export class PagesModule { }
