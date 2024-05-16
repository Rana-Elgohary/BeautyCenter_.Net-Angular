import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PriceCountService {
  private priceCounterSubject = new BehaviorSubject<number>(0);
  priceCounter$ = this.priceCounterSubject.asObservable();

  // Method to update the price
  setPriceCounter(newPrice: number) {
    const currentPrice = this.priceCounterSubject.value;
    this.priceCounterSubject.next(currentPrice + newPrice);
  }

  // Method to get the current price value
  getPriceCounter() {
    return this.priceCounterSubject.value;
  }
}
