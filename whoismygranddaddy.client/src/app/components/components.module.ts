import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TreeViewerComponent } from './tree-viewer/tree-viewer.component';

@NgModule({
  declarations: [
    TreeViewerComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[TreeViewerComponent]
})
export class ComponentsModule { }
