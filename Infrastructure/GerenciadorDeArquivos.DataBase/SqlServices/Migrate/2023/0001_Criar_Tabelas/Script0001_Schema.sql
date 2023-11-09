Use GerenciadorDeArquivos


If Object_Id('SistemaMenu') Is Null 
Begin
	Create Table SistemaMenu 
	(
		 SistemaMenuId	Int Identity(1,1) Primary Key
		,ParentId		Int					Null
		,Descricao		Varchar(256)	Not Null
		,Icone			Varchar(256)		Null
		,RouterLink		Varchar(512)		Null
		,Ordem			Int				Not Null
		,Ativo			Bit				Not Null Default(1)
	)
End
Go

If Object_Id('Usuario') Is Null 
Begin
	Create Table Usuario 
	(
		 UsuarioId				Int Identity(1,1) Primary Key
		,Nome					Varchar(128)	Not Null
		,Email					Varchar(100)	Not Null Unique
		,Telefone				Varchar(20)			Null
		,Senha					Varchar(400)	Not Null
		,DataCadastro			Datetime		Not	Null
		,DataAlteracao			DateTime			Null
		,RefreshToken			Varchar(500)		Null
		,RefreshTokenExpiryTime	DateTime			Null
		,Ativo					Bit				Not Null Default(1)
	)
End
Go

If Object_Id('ArquivoTipo') Is Null 
Begin
	Create Table ArquivoTipo 
	(
		 ArquivoTipoId	Int Identity(1,1) Primary Key
		,Descricao		Varchar(30) Not Null
	)
End
Go

If Object_Id('Arquivo') Is Null 
Begin
	Create Table Arquivo 
	(
		 ArquivoId			Int Identity(1,1) Primary Key
		,Alias				Varchar(200)	Not Null
		,Nome				Varchar(200)	Not Null
		,Caminho			Varchar(400)	Not Null
		,ArquivoTipoId		Int				Not Null References ArquivoTipo (ArquivoTipoId)
		,DataCadastro		DateTime		Not Null
		,UsuarioCadastro	Int				Not	Null
		,DataAlteracao		DateTime			Null
		,UsuarioAlteracao	Int					Null
		,Ativo				Bit				Not Null
	)
End
Go
