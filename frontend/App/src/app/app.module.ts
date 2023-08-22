import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './shared/nav/nav.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { TituloComponent } from './shared/titulo/titulo.component';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import {  NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

import { ModalModule} from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';


import { CollapseModule } from 'ngx-bootstrap/collapse';
import { EventoService } from './services/evento.service';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';



@NgModule({
  declarations: [
    AppComponent,
    TituloComponent,
    EventosComponent,
    PalestrantesComponent,
    NavComponent,
    ContatosComponent,
    DashboardComponent,
    PerfilComponent,
    DateTimeFormatPipe,

   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    NgbTooltipModule,
    NgbDropdownModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut:3000,
      positionClass:'toast-bottom-right',
      preventDuplicates:true,
      progressBar:true,
    }),
    NgxSpinnerModule,

  ],
  providers: [
    EventoService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA] ,
})
export class AppModule { }
