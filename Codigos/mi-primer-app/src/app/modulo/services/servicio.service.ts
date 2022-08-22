import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ServicioService {
  constructor() {}

  getNames(): string[] {
    const names: string[] = [];
    names.push('Emanuel');
    names.push('Jacinta');
    names.push('Ornela');
    return names;
  }
}
