import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ArquivoCsvComponent } from './list/csv/arquivo-csv.component';
import { ArquivoImagemComponent } from './list/imagem/arquivo-imagem.component';
import { ArquivoPdfComponent } from './list/pdf/arquivo-pdf.component';
import { ArquivoEditComponent } from './edit/arquivo-edit.component';


@NgModule({
	declarations: [
		ArquivoCsvComponent,
		ArquivoImagemComponent,
		ArquivoPdfComponent,
		ArquivoEditComponent
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
