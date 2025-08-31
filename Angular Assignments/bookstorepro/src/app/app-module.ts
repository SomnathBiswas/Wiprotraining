import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { DiscountPipe } from './pipes/discount-pipe';
import { Books } from './components/books/books';
import { BookItem } from './components/book-item/book-item';

import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    App,
    DiscountPipe,
    Books,
    BookItem
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
