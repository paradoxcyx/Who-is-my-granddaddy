import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {FamilyTreeViewerComponent} from "./pages/family-tree-viewer/family-tree-viewer.component";

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'family-tree-viewer', component: FamilyTreeViewerComponent }
  //{ path: 'about', component: AboutComponent },
  // Add more routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
