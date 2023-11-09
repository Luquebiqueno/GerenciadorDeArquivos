import { formatDate } from '@angular/common';
import { Component, Inject, LOCALE_ID } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { ArquivoService } from 'src/app/services/arquivo.service';
import { NotifierService } from 'src/app/services/notifier.service';
import { DialogComponent } from '../../dialog/dialog.component';

@Component({
	selector: 'app-arquivo-imagem',
	templateUrl: './arquivo-imagem.component.html',
	styleUrls: ['./arquivo-imagem.component.scss']
})
export class ArquivoImagemComponent {
	arquivos: any = [];
	listar: boolean = false;
    pagina = 0;
    qtdItens = 0;
    displayedColumns: string[] = ['alias', 'nome', 'dataCadastro', 'acoes'];

	pesquisa: any = {
		dataInicial: '',
		dataFinal: '',
		nome: '',
		alias: ''
    }

    constructor(private arquivoService: ArquivoService,
                private dialog: MatDialog,
                private notifierService: NotifierService,
                @Inject(LOCALE_ID) public locale: string) { }

    ngOnInit(): void {
        let dataInicial = new Date();
        let dataFinal = new Date();

        dataInicial.setDate(dataInicial.getDate() - 1);
        dataFinal.setDate(dataFinal.getDate() + 1);

        this.pesquisa.dataInicial = dataInicial;
        this.pesquisa.dataFinal = dataFinal;

        this.getArquivo();
    }

	getArquivo(){
        let dataInicial = '';
        let dataFinal = '';

        if (this.pesquisa.dataInicial !== undefined && this.pesquisa.dataInicial !== null && this.pesquisa.dataInicial !== '') {
            dataInicial = formatDate(this.pesquisa.dataInicial, 'dd-MM-yyyy', this.locale);
        }

        if (this.pesquisa.dataFinal !== undefined && this.pesquisa.dataFinal !== null && this.pesquisa.dataFinal !== '') {
            dataFinal = formatDate(this.pesquisa.dataFinal, 'dd-MM-yyyy', this.locale);
        }

        this.arquivoService.getArquivo(dataInicial, dataFinal, 1, this.pesquisa.nome, this.pesquisa.alias, this.pagina, false).subscribe((response: any) => {
            this.arquivos = response.data
            this.qtdItens = response.qtdItens;
            if (this.arquivos.length > 0) {
                this.listar = true;
            }
        });
    }

	openDialogDeleteArquivo(id:number) {
        this.dialog.open(DialogComponent, {data: {id: id}});
    }

	limpar() {
        this.listar = false;
        this.pagina = 0;
        this.qtdItens = 0;
        this.pesquisa = {
            dataInicial: '',
            dataFinal: '',
            nome: '',
            alias: ''
        }

        let dataInicial = new Date();
        let dataFinal = new Date();

        dataInicial.setDate(dataInicial.getDate() - 1);
        dataFinal.setDate(dataFinal.getDate() + 1);

        this.pesquisa.dataInicial = dataInicial;
        this.pesquisa.dataFinal = dataFinal;

        this.getArquivo();
    }

    handlePageEvent(pageEvent: PageEvent) {
        this.pagina = pageEvent.pageIndex;
        this.getArquivo();
    }
}
