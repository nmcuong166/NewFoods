import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeComponent } from './home/home.component';
import { ClientRoutingModule } from './client-routing.module';
import { AppLoginComponent } from '../../shared/login/app-login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ClientComponent } from './client.component';

@NgModule({
  declarations: [
    HomeComponent,
    HeaderComponent,
    AppLoginComponent,
    AboutUsComponent,
    ClientComponent
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports: [ClientComponent]
})
export class ClientModule { }
