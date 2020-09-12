import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmpleadoComponent } from './empleado.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DirectivasModule } from 'src/app/Directivas/directivas.module';
import { EmpleadoRoutingModule } from './empleado-routing.module';
import { EmpleadoService } from 'src/app/Services/empleado.service';



@NgModule({
  declarations: [
    EmpleadoComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    DirectivasModule,
    EmpleadoRoutingModule

  ],
  providers: [
    EmpleadoService
  ]
})
export class EmpleadoModule { }
