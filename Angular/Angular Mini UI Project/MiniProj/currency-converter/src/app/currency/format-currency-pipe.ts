import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatCurrency',
  standalone: false
})
export class FormatCurrencyPipe implements PipeTransform {
  transform(value: number, currencyCode: string = 'USD'): string {
    // Format the currency value with 2 decimal places
    const formattedValue = value.toFixed(2);
    
    // Add currency symbol based on currency code
    switch(currencyCode) {
      case 'USD':
        return '$' + formattedValue;
      case 'EUR':
        return '€' + formattedValue;
      case 'INR':
        return '₹' + formattedValue;
      default:
        return formattedValue + ' ' + currencyCode;
    }
  }
}
