export interface FamilyMember {

  id: number;
  pids: number[];
  mid: number | undefined;
  fid: number | undefined;
  name: string;
  surname: string;
  fullName: string;
  identityNumber: string;
  birthDate: Date;
}
