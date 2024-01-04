import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FamilyTreeViewerComponent} from "./family-tree-viewer/family-tree-viewer.component";
import {ComponentsModule} from "../components/components.module";
import { FormsModule } from '@angular/forms';
import { RootAscendantComponent } from './root-ascendant/root-ascendant.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
@NgModule({
  declarations: [FamilyTreeViewerComponent, RootAscendantComponent],
  imports: [
    CommonModule,
    ComponentsModule,
    FormsModule,
    FontAwesomeModule

  ],
  exports: [FamilyTreeViewerComponent]
})
export class PagesModule { }
