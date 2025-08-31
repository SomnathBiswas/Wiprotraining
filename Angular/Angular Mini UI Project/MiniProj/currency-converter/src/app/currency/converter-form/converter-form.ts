import { Component, Output, EventEmitter } from '@angular/core';
import { Currency } from '../currency';
import { Subscription,interval } from 'rxjs';
@Component({
  selector: 'app-converter-form',
  standalone: false,
  templateUrl: './converter-form.html',
  styleUrl: './converter-form.css'
})
export class ConverterForm {
  private ratesSubscription: Subscription | undefined;

  @Output() convert = new EventEmitter<any>();

  amount = 1;
  from = 'USD';
  to = 'INR';

  result = '';

  currencies = ['USD', 'EUR', 'INR'];
  rates: any = {};

  // constructor(private currency: Currency) {
  //   this.currency.getRates(5).subscribe(data => {
  //     this.rates = data;
  //   });
  //  }
  constructor(private currency: Currency) {}

  ngOnInit() {
    // Initial fetch of rates
    this.fetchRates();
    
    // Set up polling
    this.startPolling(5); // Poll every 5 seconds
  }

  ngOnDestroy() {
    // Clean up subscription when component is destroyed
    if (this.ratesSubscription) {
      this.ratesSubscription.unsubscribe(); 
    }
  }

  fetchRates() {
    this.currency.getRates().subscribe({
      next: (data) => {
        this.rates = data;
      },
      error: (err) => console.error('Failed to fetch rates after retries', err)
    });
  }

  startPolling(intervalSec: number = 5) {
    this.ratesSubscription = interval(intervalSec * 1000).subscribe(() => {
      this.fetchRates();
    });
  }

    onSubmit() {
    if (this.rates[this.from] && this.rates[this.to]) {
      const converted = (this.amount / this.rates[this.from]) * this.rates[this.to];
      this.result = `${this.amount} ${this.from} = ${converted.toFixed(2)} ${this.to}`;

      // Emit the result so parent components can use it
      //this.convert.emit(this.result);
      this.convert.emit({
        fromAmount: this.amount,
        fromCurrency: this.from,
        toAmount: converted,
        toCurrency: this.to
      });

      this.currency.saveHistory({
        date: new Date(),
        from: this.from,
        to: this.to,
        amount: this.amount,
        result: converted
      }).subscribe();
    }
  }


}
