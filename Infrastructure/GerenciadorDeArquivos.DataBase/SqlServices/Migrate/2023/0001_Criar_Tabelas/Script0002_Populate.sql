Use GerenciadorDeArquivos
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Dashboard' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Dashboard'
		,Icone		= 'dashboard'
		,RouterLink	= 'dashboard'
		,Ordem		= 1
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Usuários' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Minha Conta'
		,Icone		= 'person'
		,RouterLink	= 'minha-conta'
		,Ordem		= 2
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Arquivos' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Arquivos'
		,Icone		= 'folder'
		,RouterLink	= Null
		,Ordem		= 3
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Imagens' And 
				ParentId In (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Arquivos')) 
Begin
	Declare @ParentId Int = (Select Top 1 SistemaMenuId From SistemaMenu (Nolock) Where Descricao = 'Arquivos')
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= @ParentId
		,Descricao	= 'Imagens'
		,Icone		= 'image'
		,RouterLink	= 'imagem'
		,Ordem		= 1
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Pdf' And 
				ParentId In (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Arquivos')) 
Begin
	Declare @ParentId Int = (Select Top 1 SistemaMenuId From SistemaMenu (Nolock) Where Descricao = 'Arquivos')
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= @ParentId
		,Descricao	= 'Pdf'
		,Icone		= 'picture_as_pdf'
		,RouterLink	= 'pdf'
		,Ordem		= 2
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Csv' And 
				ParentId In (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Arquivos')) 
Begin
	Declare @ParentId Int = (Select Top 1 SistemaMenuId From SistemaMenu (Nolock) Where Descricao = 'Arquivos')
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= @ParentId
		,Descricao	= 'Csv'
		,Icone		= 'description'
		,RouterLink	= 'csv'
		,Ordem		= 3
		,Ativo		= 1
End
Go

If Not Exists (Select Top 1 1 From ArquivoTipo (Nolock)) 
Begin
	Insert Into ArquivoTipo
	(
		Descricao
	)
	Values
	 ('Imagem')
	,('Pdf')
	,('Csv')
End
Go

If Not Exists (Select Top 1 1 From ArquivoStatus (Nolock)) 
Begin
	Insert Into ArquivoStatus
	(
		Descricao
	)
	Values
	 ('Processado')
	,('Aguardando Processamento')
	,('Erro ao Processar')
End
Go
