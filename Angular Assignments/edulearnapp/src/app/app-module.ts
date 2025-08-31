import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module'; 
import { App } from './app';
import { CourseDetail } from './components/course-detail/course-detail';
import { CourseList } from './components/course-list/course-list';

@NgModule({
  declarations: [
    App,
    CourseDetail,
    CourseList
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
