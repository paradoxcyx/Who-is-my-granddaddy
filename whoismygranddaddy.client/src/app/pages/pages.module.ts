import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FamilyTreeViewerComponent} from "./family-tree-viewer/family-tree-viewer.component";
import {ComponentsModule} from "../components/components.module";
import {GojsAngularModule} from 'gojs-angular';


@NgModule({
  declarations: [FamilyTreeViewerComponent],
  imports: [
    CommonModule,
    ComponentsModule,
    GojsAngularModule
  ],
  exports: [FamilyTreeViewerComponent]
})
export class PagesModule { }
