import { Component, OnInit } from '@angular/core';

import { Currency } from '../currency';
@Component({
  selector: 'app-history',
  standalone: false,
  templateUrl: './history.html',
  styleUrl: './history.css'
})
export class History implements OnInit {

  history: any[] = [];
  historyItems: any[] = []; // Add this property to match the template

  constructor(private currency: Currency) { } 

  ngOnInit() {
    this.currency.getHistory().subscribe(data => {
      this.history = data;
      this.historyItems = data; // Assign the same data to historyItems
    });
  }
}
