import { Component, OnInit } from '@angular/core';
import { Tiquete } from './../models/tiquete';
import { Persona } from './../models/persona';
import { TiqueteService } from './../../services/tiquete.service';
import { PersonaService } from './../../services/persona.service';


@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  persona : Persona;
  tiquete : Tiquete;
  constructor(private personaService: PersonaService, private tiqueteService: TiqueteService) { }

  ngOnInit(): void {
    this.persona = new Persona();
    this.tiquete = new Tiquete();
  }

  addTiquete(){
    //Validar que Exista la persona.
    this.tiqueteService.post(this.tiquete).subscribe(p => {
      if (p != null) {
        alert('Tiquete registrado!');
        this.tiquete = p;
      }
    });

  }
}
