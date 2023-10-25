import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MinhaContaComponent } from './minha-conta/minha-conta.component';



@NgModule({
	declarations: [
		MinhaContaComponent
	],
	imports: [
		CommonModule,
        RouterModule,
        MaterialModule,
        ReactiveFormsModule,
        FormsModule
	]
})
export class MinhaContaModule { }
