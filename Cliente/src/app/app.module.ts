import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

//rutas
import { APP_ROUTING } from './app.router';

// componentes
import { AppComponent } from './app.component';
import { CompartidoModule } from './compartido/compartido.module';
import { EntidadComponent } from './Componets/entidad/entidad.component';
import { EmpleadoComponent } from './Componets/empleado/empleado.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';



const rutas: Routes = [
{path: '', redirectTo: 'inicio', pathMatch: 'full' },
];


@NgModule({
  declarations: [
    AppComponent,
    EntidadComponent,
    EmpleadoComponent
  ],
  imports: [
    BrowserModule,
    CompartidoModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    APP_ROUTING
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
