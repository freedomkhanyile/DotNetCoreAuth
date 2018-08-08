import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'websitepipe'
})
export class WebsitePipe implements PipeTransform {

  transform(items: any[], searchText: string): any[] {
    if (!items) return [];
    if (!searchText) return items;
    searchText = searchText.toLowerCase();
    return items.filter(it => {
      return it.name.toLowerCase().includes(searchText) || it.description.toLowerCase().includes(searchText) || it.publisher.toLowerCase().includes(searchText);
    });
  }

}
