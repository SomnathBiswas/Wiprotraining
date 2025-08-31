import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-conversion-result',
  standalone: false,
  templateUrl: './conversion-result.html',
  styleUrl: './conversion-result.css'
})
export class ConversionResult implements OnChanges {
  @Input() result: string | any = '';
  
  fromAmount: number = 0;
  fromCurrency: string = '';
  toAmount: number = 0;
  toCurrency: string = '';

  ngOnChanges(changes: SimpleChanges) {
    if (this.result && typeof this.result === 'object') {
      this.fromAmount = this.result.fromAmount;
      this.fromCurrency = this.result.fromCurrency;
      this.toAmount = this.result.toAmount;
      this.toCurrency = this.result.toCurrency;
      console.log('Updated conversion result:', this.result);
    }
  }
}
