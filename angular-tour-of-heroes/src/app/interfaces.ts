export interface Hero {
  id: number;
  name: string;
}
export interface Genre{
  id:string;
  name?:string;
  games?:Game[]
}
export interface Mechanic{
  id:string;
  name?:string;
  games?:Game[]
}
export interface Game{
  id:string;
  name?:string;
  genre?:Genre;
  mechanics?: Mechanic[];
}
