import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { DialogComponent } from './dialog/dialog.component';


@NgModule({
	declarations: [
		DialogComponent
	],
	imports: [
		CommonModule,
		MaterialModule
	]
})
export class DialogModule { }
