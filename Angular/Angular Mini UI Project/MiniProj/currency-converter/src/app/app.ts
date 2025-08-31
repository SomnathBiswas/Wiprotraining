import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('currency-converter');
  
  // Property to store the conversion result
  conversionResult: any = null;
  
  // Method to handle the conversion event
  onConvert(result: any) {
    this.conversionResult = result;
    console.log('Conversion result in App:', result);
  }
}
