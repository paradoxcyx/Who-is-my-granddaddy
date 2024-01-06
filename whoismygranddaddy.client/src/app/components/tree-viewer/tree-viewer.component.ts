import { Component, Input, OnInit } from '@angular/core';
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

    FamilyTree.templates['family_male'] = Object.assign({}, FamilyTree.templates['family']);
    FamilyTree.templates['family_male'].node = '<circle cx="100" cy="100" r="100" fill="#039be5" stroke-width="1" stroke="#aeaeae"></circle>';
    FamilyTree.templates['family_female'] = Object.assign({}, FamilyTree.templates['family']);
    FamilyTree.templates['family_female'].node = '<circle cx="100" cy="100" r="100" fill="#FF46A3" stroke-width="1" stroke="#aeaeae"></circle';

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
    this.initFamilyTree();
    this.initTemplate();

    //Loading the family members into the tree view
    this.familyTree.load(familyMembers);
  }

  clearFamilyTree() {
    this.initFamilyTree();
    this.initTemplate();
  }

}
