import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AppLoginComponent } from '../../shared/login/app-login.component';
import { AboutUsComponent } from './about-us/about-us.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'about',
    component: AboutUsComponent
  },
  {
    path: 'login',
    component: AppLoginComponent
  },
  {
    path: '**',
    redirectTo: '/client/home'
  }

];

@NgModule({
  imports: [(RouterModule.forChild(routes))],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
