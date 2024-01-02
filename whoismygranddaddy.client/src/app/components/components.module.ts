import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TreeViewerComponent } from './tree-viewer/tree-viewer.component';
import { TreeViewAllModule } from '@syncfusion/ej2-angular-navigations';
import { DiagramAllModule } from '@syncfusion/ej2-angular-diagrams';



@NgModule({
  declarations: [
    TreeViewerComponent
  ],
  imports: [
    CommonModule,
    TreeViewAllModule,
    DiagramAllModule,
  ],
  exports:[TreeViewerComponent]
})
export class ComponentsModule { }
