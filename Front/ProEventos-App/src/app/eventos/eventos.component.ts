import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltred: any = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public showImg: boolean = true;

  private _filterList: string = "";

  public get filterList(){
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value;
    this.eventosFiltred = this.filterList ? this.filterEvents(this.filterList): this.eventos
  }

  filterEvents(filterValue: string): any{
    filterValue = filterValue.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filterValue) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filterValue) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetEventos();
  }

  showImage(){
    this.showImg = !this.showImg;
  }

  public GetEventos(): void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltred = response;
      },
      error => console.log(error)
    );

  }

}
