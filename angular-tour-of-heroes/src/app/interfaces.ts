export interface Hero {
  id: number;
  name: string;
}
export interface Genre{
  id:string;
  name:string;
}
export interface Mechanic{
  id:string;
  name:string;
}
export interface Game{
  id:string;
  name:string;
  genre:Genre;
  mechanics: Mechanic[];
}
