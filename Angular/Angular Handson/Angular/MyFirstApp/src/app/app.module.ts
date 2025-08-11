import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { FileOpsComponent } from './file-ops/file-ops.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { Register } from './register/register';
import { Auth } from './service/auth/auth';
import { Hrservice } from './service/hrservice/hrservice';
import { Users } from './users/users';
import { Menu } from './menu/menu';

@NgModule({
  declarations: [
    AppComponent,
    FileOpsComponent,
    LoginComponent,
    Register,
    Auth,
    Hrservice,
    Users,
    Menu
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    HttpClientModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }