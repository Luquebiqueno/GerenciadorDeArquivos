import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutenticacaoComponent } from './modules/autenticacao/autenticacao/autenticacao.component';
import { EsqueciMinhaSenhaComponent } from './modules/autenticacao/esqueci-minha-senha/esqueci-minha-senha.component';
import { NavComponent } from './nav/nav/nav.component';
import { authGuard } from './_helpers/auth.guard';
import { DashboardComponent } from './modules/dashboard/dashboard/dashboard.component';
import { ArquivoEditComponent } from './modules/arquivo/edit/arquivo-edit.component';
import { ArquivoCsvComponent } from './modules/arquivo/list/csv/arquivo-csv.component';
import { ArquivoImagemComponent } from './modules/arquivo/list/imagem/arquivo-imagem.component';
import { ArquivoPdfComponent } from './modules/arquivo/list/pdf/arquivo-pdf.component';
import { MinhaContaComponent } from './modules/minha-conta/minha-conta/minha-conta.component';
import { AlterarSenhaComponent } from './modules/alterar-senha/alterar-senha/alterar-senha.component';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'autenticacao',
        pathMatch: 'full',
    },
    {
        path: 'autenticacao', component: AutenticacaoComponent,
    },
    {
        path: 'esqueci-minha-senha', component: EsqueciMinhaSenhaComponent,
    },
    {
        path: '', component: NavComponent,
        canActivate: [authGuard],
        children: [
            {
                path: 'dashboard',
                pathMatch: 'full',
                component: DashboardComponent,
                canActivate: [authGuard]
            },
            {
                path: 'alterar-senha',
                component: AlterarSenhaComponent,
                canActivate: [authGuard]
            },
            {
                path: 'minha-conta',
                component: MinhaContaComponent,
                canActivate: [authGuard]
            },
            {
                path: 'imagem',
                component: ArquivoImagemComponent,
                canActivate: [authGuard]
            },
            {
                path: 'csv',
                component: ArquivoCsvComponent,
                canActivate: [authGuard]
            },
            {
                path: 'pdf',
                component: ArquivoPdfComponent,
                canActivate: [authGuard]
            },
            {
                path: 'arquivo/create',
                component: ArquivoEditComponent,
                canActivate: [authGuard]
            },
            {
                path: 'arquivo/edit/:id',
                component: ArquivoEditComponent,
                canActivate: [authGuard]
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
