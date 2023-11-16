import { formatDate } from '@angular/common';
import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { ArquivoService } from 'src/app/services/arquivo.service';
import { NotifierService } from 'src/app/services/notifier.service';
import { DialogComponent } from '../../dialog/dialog.component';
import { DialogService } from 'src/app/services/dialog.service';

@Component({
    selector: 'app-arquivo-pdf',
    templateUrl: './arquivo-pdf.component.html',
    styleUrls: ['./arquivo-pdf.component.scss']
})
export class ArquivoPdfComponent implements OnInit {

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
                private notifierService: NotifierService,
                private dialogService: DialogService,
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

    getArquivo() {
        let dataInicial = '';
        let dataFinal = '';

        if (this.pesquisa.dataInicial !== undefined && this.pesquisa.dataInicial !== null && this.pesquisa.dataInicial !== '') {
            dataInicial = formatDate(this.pesquisa.dataInicial, 'dd-MM-yyyy', this.locale);
        }

        if (this.pesquisa.dataFinal !== undefined && this.pesquisa.dataFinal !== null && this.pesquisa.dataFinal !== '') {
            dataFinal = formatDate(this.pesquisa.dataFinal, 'dd-MM-yyyy', this.locale);
        }

        this.arquivoService.getArquivo(dataInicial, dataFinal, 2, this.pesquisa.nome, this.pesquisa.alias, this.pagina, false).subscribe((response: any) => {
            this.arquivos = response.data
            this.qtdItens = response.qtdItens;
            if (this.arquivos.length > 0) {
                this.listar = true;
            } else {
                this.listar = false;
            }
        });
    }

    openDialogDeleteArquivo(id: number) {

        this.dialogService.confirmDialog({
            title: 'Deseja realmente excluir este item?',
            message: '',
            confirmText: 'Excluir',
            cancelText: 'Fechar'
        }).subscribe((response: any) => {
            if (response) {
                this.deleteArquivo(id);
            }
        });
    }

    deleteArquivo(id: number) {
        this.arquivoService.deleteArquivo(id.toString()).subscribe((response: any) => {
            this.getArquivo();
            this.notifierService.showNotification('Arquivo excluído com sucesso', 'Sucesso', 'success');
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
        });
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
