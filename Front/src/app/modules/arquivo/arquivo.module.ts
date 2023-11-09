import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ArquivoCsvComponent } from './list/csv/arquivo-csv.component';
import { ArquivoImagemComponent } from './list/imagem/arquivo-imagem.component';
import { ArquivoPdfComponent } from './list/pdf/arquivo-pdf.component';
import { ArquivoPdfEditComponent } from './edit/pdf/arquivo-pdf-edit.component';
import { ArquivoCsvEditComponent } from './edit/csv/arquivo-csv-edit.component';
import { ArquivoImagemEditComponent } from './edit/imagem/arquivo-imagem-edit.component';
import { DialogComponent } from './dialog/dialog.component';


@NgModule({
	declarations: [
		ArquivoCsvComponent,
		ArquivoImagemComponent,
		ArquivoPdfComponent,
		ArquivoPdfEditComponent,
		ArquivoCsvEditComponent,
		ArquivoImagemEditComponent,
  		DialogComponent
	],
	imports: [
		CommonModule,
		RouterModule,
		MaterialModule,
		ReactiveFormsModule,
		FormsModule,
		HttpClientModule
	]
})
export class ArquivoModule { }
