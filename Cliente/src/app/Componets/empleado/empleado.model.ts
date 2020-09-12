export class EmpleadosModel{

  id: number;
  nombres: string;
  apellidos: string;
  genero: string;
  edad: string;
  direccion: string;
  telefono: string;
  correo: string;
  cargo: string;
  salario: string;
  documento: string;
  tipoDocumento: string;
  idEntidad: number;
  idUsuario: number;

  constructor() {
    this.id = null,
    this.nombres = "",
    this.apellidos = "",
    this.genero = "",
    this.edad = "",
    this.direccion = "",
    this.telefono = "",
    this.correo = "",
    this.cargo = "",
    this.salario = "",
    this.documento = "",
    this.tipoDocumento = "",
    this.idEntidad = null,
    this.idUsuario = null
  }

}
