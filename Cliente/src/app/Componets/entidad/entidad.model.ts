export class EntidadesModel{

  id: number;
  nombre: string;
  pais: string;
  departamento: string;
  ciudad: string;
  direccion: string;
  telefono: string;
  correo: string;

  constructor() {
    this.id = null,
    this.nombre = "",
    this.pais = "",
    this.departamento = "",
    this.ciudad = "",
    this.direccion = "",
    this.telefono = "",
    this.correo = ""
  }

}
