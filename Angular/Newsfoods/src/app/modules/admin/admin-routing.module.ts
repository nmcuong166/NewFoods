import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './components/admin/admin.component';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/shared/common/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    canActivate: [AuthGuard] // check quyen xem co the vao routing nay hay ko
  },

];

@NgModule({
  imports: [(RouterModule.forChild(routes))],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
