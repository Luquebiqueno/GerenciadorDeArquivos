import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AlterarSenhaComponent } from './alterar-senha/alterar-senha.component';



@NgModule({
	declarations: [
		AlterarSenhaComponent
	],
	imports: [
		CommonModule,
        RouterModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule
	]
})
export class AlterarSenhaModule { }
