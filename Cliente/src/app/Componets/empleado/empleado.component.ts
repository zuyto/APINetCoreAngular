import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from 'src/app/Services/empleado.service';
import { EmpleadosModel } from './empleado.model';

@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.css']
})
export class EmpleadoComponent implements OnInit {

  public EmpleadosModel: EmpleadosModel;
  pass: boolean;
  tablaEmpleados: any;

  constructor(private EmpleadoService: EmpleadoService) {}

  ngOnInit(): void {
    this.EmpleadosModel = new EmpleadosModel();
    this.pass = true;
    this.tablaEmpleados = [];
  }

  /**Funciones Activar o inactivar campos */
  access() {
    let object: any = {
      pass: this.pass,
    };

    return object;
  }

  habilitar(value: any) {
    this.pass = value;
  }
  GetEmpleados() {
    this.EmpleadoService.GetEmpleados().subscribe(
      (datos) => {
      if (datos.succesful) {
        console.log('datos', datos.entity);

        this.tablaEmpleados = datos;
      } else {
        alert(datos.error);
      }
    });
  }
  GetObjEmpleado() {
    this.EmpleadoService.GetObjEmpleado(this.EmpleadosModel).subscribe(
      (datos) => {
        if (datos.succesful) {
          this.tablaEmpleados = datos.entity;
        } else {
          alert(datos.error);
        }
      }
    );
  }
  CreateEmpleado() {
    console.log('EntidadesModel', this.EmpleadosModel);
    this.EmpleadoService.CreateEmpleado(this.EmpleadosModel).subscribe(
      (datos) => {
        if (datos.succesful) {
          this.GetEmpleados();
          alert('Transacción exitosa');
          this.EmpleadosModel = new EmpleadosModel();
        } else {
          alert(datos.error);
        }
      }
    );
  }
  UpdateEmpleado() {
    this.EmpleadoService.UpdateEmpleado(this.EmpleadosModel).subscribe(
      (datos) => {
        if (datos.succesful) {
          this.GetEmpleados();
          alert('Transacción exitosa');
          this.EmpleadosModel = new EmpleadosModel();
        } else {
          alert(datos.error);
        }
      }
    );
  }


}
