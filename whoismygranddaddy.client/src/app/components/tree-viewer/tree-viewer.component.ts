import { Component, Input } from '@angular/core';
import {Person} from "../../interfaces/person";

@Component({
  selector: 'tree-viewer',
  templateUrl: './tree-viewer.component.html',
  styleUrl: './tree-viewer.component.css'
})
export class TreeViewerComponent {
  @Input() people: Person[] = [];
}
