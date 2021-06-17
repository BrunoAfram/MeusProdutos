# MeusProdutos
Desafio de estágio WLS Soluções

## Instruções de uso
**1** - Abra a solução do projeto no Visual Studio e configure a conexão com o banco de dados em "appsettings.json"   
        
        "DefaultConnection": "server=; port=; database=meusprodutosdb; user=; password=; Persist Security Info=False"  
        
**2** - Utilizando o Console ou PowerShell, insira os seguintes comandos:  
  
        Add-Migration Exemplo  
        Update-Database  
        
**3** - Rode o projeto, para visualização de testes, uma pagina do Swagger será aberta no navegador padrão.  
        O banco de dados já está populado com algumas entradas, para facilitar o teste dos verbos Http.  
        Clique no verbo Http que desejar, clique em **"Try it out"**, preencha os parâmetros (se necessário) e clique em **"Execute"**. O resultado será exibido abaixo.  
          
## Principais desafios encontrados  
  Durante o desenvolvimento deste projeto, pesquisei e aprendi a utilizar ferramentas que não tinha conhecimento anteriormente.  
  Aprendi a utilizar o Entity Framework Core como uma ferramenta ORM e também a visualização da API com o Swagger.  
  
  O maior problema que encontrei foi na implementação da autenticação por Bearer JWT, onde gerei o token com sucesso mas não consegui implementar a autenticação de retorno utilizando o Swagger.

        
