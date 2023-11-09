import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Arquivo } from '../models/arquivo';

@Injectable({
	providedIn: 'root'
})
export class ArquivoService {

	url = environment.host + 'Arquivo';

    constructor(private http: HttpClient) { }

    getArquivo(dataInicial: any, dataFinal: any, arquivoTipoId: any, nome: any, alias: any, pagina: any, exportar: any): Observable<Arquivo[]> {
        return this.http.get<Arquivo[]>(this.url + `?dataInicial=${dataInicial}&dataFinal=${dataFinal}&arquivoTipoId=${arquivoTipoId}&nome=${nome}&alias=${alias}&pagina=${pagina}&exportar=${exportar}`);
    }

    getArquivoById(id: string): Observable<Arquivo> {
        return this.http.get<Arquivo>(this.url + '/' + id);
    }

    createArquivo(model: any) {
        return this.http.post(this.url, model);
    }

    updateArquivo(id: string, model: Arquivo): Observable<Arquivo> {
        return this.http.put<Arquivo>(this.url + '/' + id, model);
    }

    deleteArquivo(id: string): Observable<any> {
        return this.http.put<Arquivo>(this.url + '/DeleteArquivo/' + id, null);
    }

    uploadArquivo(model: FormData) {
		return this.http.post(this.url + '/UploadArquivo', model);
	}
}
