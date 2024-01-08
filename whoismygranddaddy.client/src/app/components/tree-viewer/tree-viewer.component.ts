import { Component, OnInit } from '@angular/core';
import FamilyTree from "@balkangraph/familytree.js";
import {FamilyMember} from "../../../shared/interfaces/family-member";

@Component({
  selector: 'tree-viewer',
  templateUrl: './tree-viewer.component.html',
  styleUrl: './tree-viewer.component.css'
})


export class TreeViewerComponent implements OnInit {

  familyTree!: FamilyTree;

  constructor() {
  }

  //Instantiating the family tree
  initFamilyTree() {
    const tree = document.getElementById('tree');
    if (tree) {
      this.familyTree = new FamilyTree(tree, {
        template: 'family',
        enableSearch: false,
        enableTouch: false,

        nodeMouseClick: FamilyTree.action.none,
        nodeBinding: {
          field_0: "fullName",
          field_1: "birthDate",
          field_2: "identityNumber"
        },

      });
    }
  }
  //Initializing custom template for tree-view and nodes
  initTemplate() {
    FamilyTree.templates['family'] = Object.assign({}, FamilyTree.templates['tommy']);
    FamilyTree.templates['family'].size = [200, 120];
    FamilyTree.templates['family'].defs = '';

    FamilyTree.templates['family'].ripple = {
      radius: 0,
      color: "none",
      rect: undefined
    };

    FamilyTree.templates['family']['field_0'] = '<text style="font-size: 24px;" fill="#000" x="100" y="90" text-anchor="middle">{val}</text>';
    FamilyTree.templates['family']['field_1'] = '<text style="font-size: 16px;" fill="#000" x="100" y="60" text-anchor="middle">{val}</text>';
    FamilyTree.templates['family']['field_2'] = '<text style="font-size: 16px;" fill="#000" x="100" y="30" text-anchor="middle">{val}</text>';
  }

  ngOnInit(): void {
  }

  loadFamilyMembers(familyMembers: FamilyMember[]) {
    this.clearFamilyTree();

    //Loading the family members into the tree view
    this.familyTree.load(familyMembers);
  }

  clearFamilyTree() {
    //Ensure that we initialize the family tree first before populating it with data
    //I have experienced weird issues with this library when attempting to populate while an existing instance is active
    this.initFamilyTree();
    this.initTemplate();
  }

}
