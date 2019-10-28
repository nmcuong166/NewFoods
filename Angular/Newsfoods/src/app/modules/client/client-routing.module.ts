import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AppLoginComponent } from '../../shared/login/app-login.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'login',
    component: AppLoginComponent
  }
];

@NgModule({
  imports: [(RouterModule.forChild(routes))],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
