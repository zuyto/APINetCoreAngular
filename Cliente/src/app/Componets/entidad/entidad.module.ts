import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EntidadComponent } from './entidad.component';
import { EntidadService } from 'src/app/Services/entidad.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DirectivasModule } from 'src/app/Directivas/directivas.module';
import { EntidadRoutingModule } from './entidad-routing.module';



@NgModule({
  declarations: [
    EntidadComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    DirectivasModule,
    EntidadRoutingModule

  ],
  providers: [
    EntidadService
  ]
})
export class EntidadModule { }
