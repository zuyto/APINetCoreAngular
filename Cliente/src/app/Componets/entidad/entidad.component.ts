import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntidadService } from 'src/app/Services/entidad.service';
import { EntidadesModel } from './entidad.model';

@Component({
  selector: 'app-entidad',
  templateUrl: './entidad.component.html',
  styleUrls: ['./entidad.component.css']
})
export class EntidadComponent implements OnInit {
  public EntidadesModel: EntidadesModel;

  tipoDocumento: any;
  pass: boolean;
  tablaEntidad: any;

  constructor(

    public router: Router
    , private activeRoute: ActivatedRoute
    , private EntidadService: EntidadService

  ) {
  }

  ngOnInit(): void {
    this.EntidadesModel = new EntidadesModel();
    this.tipoDocumento = [];
    this.pass = true;
    this.tablaEntidad = [];


    this.GetEntidades();
  }

  /**Funciones Activar o inactivar campos */
  access() {
    let object: any = {
      pass: this.pass
    }

    return object;
  }

  habilitar(value: any) {
    this.pass = value;

  }

  GetEntidades() {
    this.EntidadService.GetEntidades().subscribe((datos) => {
      if (datos.succesful) {
        console.log('datos', datos.entity);

        this.tablaEntidad = datos;
      } else {
        alert(datos.error);
      }
    });
  }
  GetObjEntidad() {
    this.EntidadService.GetObjEntidad(this.EntidadesModel).subscribe(
      (datos) => {
        if (datos.succesful) {
          this.tablaEntidad = datos.entity;
        } else {
          alert(datos.error);
        }
      }
    );
  }
  CreateEntidad() {
    console.log('EntidadesModel', this.EntidadesModel);
    this.EntidadService.CreateEntidad(this.EntidadesModel).subscribe(
      (datos) => {
        if (datos.succesful) {
          this.GetEntidades();
          alert('Transacción exitosa');
          this.EntidadesModel = new EntidadesModel();
        } else {
          alert(datos.error);
        }
      }
    );
  }
  UpdateEntidad() {
    this.EntidadService.UpdateEntidad(this.EntidadesModel).subscribe(
      (datos) => {
        if (datos.succesful) {
          this.GetEntidades();
          alert('Transacción exitosa');
          this.EntidadesModel = new EntidadesModel();
        } else {
          alert(datos.error);
        }
      }
    );
  }


}
