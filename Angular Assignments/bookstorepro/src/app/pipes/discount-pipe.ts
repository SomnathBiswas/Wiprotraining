import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'discount',
  standalone: false
})
export class DiscountPipe implements PipeTransform {

transform(price: number, percent: number): number {
    if (price == null || percent == null) return price;
    const discounted = price - (price * percent) / 100;
    return Math.round(discounted * 100) / 100;
  }

}
