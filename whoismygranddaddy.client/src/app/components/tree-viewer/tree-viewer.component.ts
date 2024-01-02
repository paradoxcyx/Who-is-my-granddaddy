import { Component, Input, OnInit } from '@angular/core';
import FamilyTree from "@balkangraph/familytree.js";
import {FamilyMember} from "../../interfaces/family-member";

@Component({
  selector: 'tree-viewer',
  templateUrl: './tree-viewer.component.html',
  styleUrl: './tree-viewer.component.css'
})


export class TreeViewerComponent implements OnInit {

  @Input() familyMembers: FamilyMember[] = [];

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

    FamilyTree.templates['family']['field_0'] = '<text style="font-size: 24px;" fill="#ffffff" x="100" y="90" text-anchor="middle">{val}</text>';
    FamilyTree.templates['family']['field_1'] = '<text style="font-size: 16px;" fill="#ffffff" x="100" y="60" text-anchor="middle">{val}</text>';
    FamilyTree.templates['family']['field_2'] = '<text style="font-size: 16px;" fill="#ffffff" x="100" y="30" text-anchor="middle">{val}</text>';
  }

  ngOnInit(): void {

    this.initTemplate();

    const tree = document.getElementById('tree');
    if (tree) {
      var family = new FamilyTree(tree, {
        template: 'family',
        enableSearch: false,
        enableTouch: false,
        nodeMouseClick: FamilyTree.action.none,
        nodeBinding: {
          field_0: "name",
          field_1: "birthDate",
          field_2: "identityNumber"
        },

      });

      family.load(this.familyMembers);
    }

  }

}
