import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Arquivo } from 'src/app/models/arquivo';
import { ArquivoService } from 'src/app/services/arquivo.service';
import { NotifierService } from 'src/app/services/notifier.service';

@Component({
	selector: 'app-arquivo-csv-edit',
	templateUrl: './arquivo-csv-edit.component.html',
	styleUrls: ['./arquivo-csv-edit.component.scss']
})
export class ArquivoCsvEditComponent implements OnInit {
	
	arquivoCsvForm: FormGroup;
    arquivo: Arquivo;
    titulo = 'Cadastrar Arquivo Csv';
    id: string;
    file: any = null;
    fileName: string = null;
    isEdit: boolean = false;

	constructor(private route: ActivatedRoute,
				private arquivoService: ArquivoService,
				private fb: FormBuilder,
				private router: Router,
				private notifierService: NotifierService) { }

	ngOnInit(): void {
		this.getCsvForm();
        this.id = this.route.snapshot.paramMap.get('id');
        if (this.id != null && this.id != undefined) {
            this.titulo = 'Editar Arquivo Csv';
            this.isEdit = true;
            this.getArquivoCsvById(this.id);
        }
	}
	
	
	getCsvForm(): void {
        this.arquivoCsvForm = this.fb.group({
            alias: ['', [Validators.required]]
        });
    }

    getArquivoCsvById(id: string) {
        this.arquivoService.getArquivoById(id).subscribe((response: Arquivo) => {
            if (response != null) {
                this.arquivoCsvForm = this.fb.group({
                    id: response.id,
                    alias: response.alias
                });
            }
        });
    }

    salvar() {
        if (this.id != null || this.id != undefined) {
            this.updateArquivoCsv(this.id);
        } else {
            this.createArquivoCsv();
        }
    }

    createArquivoCsv(): void {
        if (this.arquivoCsvForm.invalid) {
            this.notifierService.showNotification('Dados inválidos', 'Erro', 'error');
            return;
        }

        this.arquivo = this.arquivoCsvForm.value;
        this.arquivo.nome = this.fileName
        this.arquivo.arquivoTipoId = 3;
        const formData = new FormData();
        formData.append('file', this.file, this.file.name);

        this.arquivoService.uploadArquivo(formData).subscribe((response: any) => {
            this.file = null;
            this.arquivo.caminho = response.caminho;
            this.arquivoService.createArquivo(this.arquivo).subscribe((response: any) => {
                this.notifierService.showNotification('Arquivo cadastrado com sucesso', 'Sucesso', 'success');
                this.voltar();
                
            },
            error => {
                this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
                return;
            });            
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
            return;
        });
    }

    updateArquivoCsv(id: string) {
        this.arquivo = this.arquivoCsvForm.value;
        this.arquivoService.updateArquivo(id.toString(), this.arquivo).subscribe((response: Arquivo) => {
            this.notifierService.showNotification('Arquivo Atualizado com sucesso', 'Sucesso', 'success');
            this.voltar();
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
        });
    }

    voltar(): void {
        this.router.navigate(['../../csv']);
    }

    getFile(event: any) {
        this.file = event.target.files[0] ?? null;
        this.fileName = this.file?.name;
    }
}