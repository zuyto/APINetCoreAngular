import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EntidadComponent } from './entidad.component';

const routes: Routes = [
  {
      path: '', component: EntidadComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class EntidadRoutingModule {
}
