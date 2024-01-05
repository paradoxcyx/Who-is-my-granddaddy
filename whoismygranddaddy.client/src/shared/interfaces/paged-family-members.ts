import {FamilyMember} from "./family-member";

export interface PagedFamilyMembers {
  page: number;
  familyMembers: FamilyMember[];
}
