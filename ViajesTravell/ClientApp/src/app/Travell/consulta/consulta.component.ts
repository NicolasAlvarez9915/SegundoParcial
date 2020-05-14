import { Component, OnInit } from '@angular/core';
import { TiqueteService } from './../../services/tiquete.service';
import { Tiquete } from './../models/tiquete';


@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {

  tiquetes: Tiquete[];
  searchText:string;
  constructor(private tiqueteService: TiqueteService) { }

  ngOnInit(): void {
    this.tiqueteService.get().subscribe(result => {
      this.tiquetes = result;
    });
  }

}
