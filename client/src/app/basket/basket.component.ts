import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem } from '../shared/models/basket';
import { BasketService } from './basket.service';
@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  basket$: Observable<IBasket>;

  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }

  incrementBasketItem(item: IBasketItem) {
    this.basketService.incrementItemInBasket(item);
  }

  decrementBasketItem(item: IBasketItem) {
    this.basketService.decrementItemInBasket(item);
  }
  
  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFromBasket(item);
  }
}
