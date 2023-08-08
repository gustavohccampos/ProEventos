import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent {

  ngOnInit():  void{
    this.getEventos();
  }

  constructor (private http:HttpClient){}

  public eventos : any =[];
  public eventosFiltrados : any =[];
  widthImg:number = 80;
  marginImg:number = 2;
  viewImg = true;
  private _filtroLista = "";


  exibirImg():void{
  this.viewImg=!this.viewImg;
}

public get filtroLista(){
  return this._filtroLista
}

public set filtroLista(value){
  this._filtroLista= value;
  this.eventosFiltrados = this.filtroLista?this.filtrarEventos(this.filtroLista): this.eventos;
}

filtrarEventos(filtrarPor:string):any{
  filtrarPor = filtrarPor.toLocaleLowerCase();
  return this.eventos.filter(
    (    evento: { tema: string;local: string; dataEvento:string})=>evento.tema.toLocaleLowerCase().indexOf(filtrarPor)!==-1 ||
    evento.local.toLocaleLowerCase().indexOf(filtrarPor)!==-1||
    evento.dataEvento.toLocaleLowerCase().indexOf(filtrarPor)!==-1
  )
}

  public getEventos():void{
    this.http.get("https://localhost:5125/api/eventos").subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados=this.eventos;
      },
      error => console.log(error)
    );


  }




}
