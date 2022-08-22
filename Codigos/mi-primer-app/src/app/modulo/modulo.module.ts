import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimeroComponent } from './primero/primero.component';
import { FormsModule } from '@angular/forms';
import { ServicioService } from './services/servicio.service';
import { FiltroPipe } from './filtro.pipe';
import { SegundoComponent } from './segundo/segundo.component';



@NgModule({
  declarations: [PrimeroComponent, FiltroPipe, SegundoComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [PrimeroComponent],
  providers: [ServicioService]
})
export class ModuloModule { }
