import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../modules/dialog/dialog/dialog.component';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class DialogService {

	constructor(private dialog: MatDialog) { }

	confirmDialog(data: any): Observable<boolean> {
		return this.dialog.open(DialogComponent, {
			data: data,
			width: '400px',
			disableClose: true
		}).afterClosed();
	}
}
