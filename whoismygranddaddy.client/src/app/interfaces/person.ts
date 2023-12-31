export interface Person {

  identityNumber: string;
  name: string;
  surname: string;
  birthDate: Date;
  children: Person[]
}
