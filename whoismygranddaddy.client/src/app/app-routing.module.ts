import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {FamilyTreeViewerComponent} from "./pages/family-tree-viewer/family-tree-viewer.component";
import {RootAscendantComponent} from "./pages/root-ascendant/root-ascendant.component";

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'family-tree-viewer', component: FamilyTreeViewerComponent },
  { path: 'root-ascendant', component: RootAscendantComponent }
  //{ path: 'about', component: AboutComponent },
  // Add more routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
