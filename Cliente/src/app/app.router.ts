import { RouterModule, Routes } from '@angular/router';
import { Component } from '@angular/core';
import { EntidadComponent } from './Componets/entidad/entidad.component';
import { EmpleadoComponent } from './Componets/empleado/empleado.component';



const APP_ROUTES: Routes = [
    { path: 'entidad', component: EntidadComponent },
    { path: 'empleado', component: EmpleadoComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'entidad' }

];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);

