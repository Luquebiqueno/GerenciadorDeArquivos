Use GerenciadorDeArquivos
Go

If Object_Id('GetDashboard') Is Not Null
Begin
	Drop Procedure GetDashboard
End
Go

Set Ansi_Nulls On
Go

Set Quoted_Identifier On
Go

Create Procedure GetDashboard 
(
	 @UsuarioId		Int
	,@DataInicial	Date
	,@DataFinal		Date
)
As
Begin
	Drop Table If Exists #Arquivos
	Drop Table If Exists #ArquivosRetorno

	Create Table #ArquivosRetorno
	(
		 Id		Int Identity(1,1)
		,Mes	Varchar(20)
		,Imagem	Int
		,Pdf	Int
		,Csv	Int
	)
	
	Select 
		 DataCadastro	= Format(DataCadastro, 'MMM/yyyy', 'pt-BR') 
		,Qtd			= Count(ArquivoId)
		,ArquivoTipoId	= ArquivoTipoId
	Into #Arquivos
	From Arquivo (Nolock)
	Where Ativo = 1
	And UsuarioCadastro = @UsuarioId
	And DataCadastro Between @DataInicial And @DataFinal
	Group By Format(DataCadastro, 'MMM/yyyy', 'pt-BR'), ArquivoTipoId
	Order By DataCadastro
	
	While (@DataInicial <= @DataFinal)
	Begin
		Insert Into #ArquivosRetorno
		(
			Mes
		)
		Select Mes = Format(@DataInicial, 'MMM/yyyy', 'pt-BR') 

		Set @DataInicial = DateAdd(mm, 1, @DataInicial)
	End
	
	Update Ar
	Set Ar.Imagem = Aq.Qtd
	From		#ArquivosRetorno	Ar
	Inner Join	#Arquivos			Aq On Trim(Aq.DataCadastro) = Trim(Ar.Mes)
	Where Aq.ArquivoTipoId = 1

	Update Ar
	Set Ar.Pdf = Aq.Qtd
	From		#ArquivosRetorno	Ar
	Inner Join	#Arquivos			Aq On Trim(Aq.DataCadastro) = Trim(Ar.Mes)
	Where Aq.ArquivoTipoId = 2

	Update Ar
	Set Ar.Csv = Aq.Qtd
	From		#ArquivosRetorno	Ar
	Inner Join	#Arquivos			Aq On Trim(Aq.DataCadastro) = Trim(Ar.Mes)
	Where Aq.ArquivoTipoId = 3
	
	Select
		 Mes	= Mes			
		,Imagem	= IsNull(Imagem, 0)		
		,Pdf	= IsNull(Pdf, 0)	
		,Csv	= IsNull(Csv, 0)
	From #ArquivosRetorno
	Order By Id
End	
Go