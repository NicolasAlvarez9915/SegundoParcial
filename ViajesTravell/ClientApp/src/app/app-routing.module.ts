import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistroComponent } from './Travell/registro/registro.component';
import { ConsultaComponent } from './Travell/consulta/consulta.component';
import { Route } from '@angular/compiler/src/core';

import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [

  {
    path: 'Registro',
    component: RegistroComponent
  },
  {
    path: 'Consulta',
    component: ConsultaComponent
  }
] 

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
