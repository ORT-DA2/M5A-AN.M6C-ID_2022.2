import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filtro',
})
export class FiltroPipe implements PipeTransform {
  transform(list: string[], filtro: string): string[] {
    return list.filter(
      (x) => x.toLowerCase().includes(filtro.toLowerCase()));
  }
}
