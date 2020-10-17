# SEFAZ API - Menor Preço
Este projeto foi desenvolvido para o Processo Seletivo 2020 da SEFAZ, onde consiste em construir uma API (REST/JSON) para consulta e recuperação de produtos, filtrada pelo código GTIN (EAN) e ordenada de forma crescente pelo preço.

Para esse projeto foram utilizadas as seguintes tecnologias:
- .NET Core 3.1 para construção de uma Web API
- Entity Framework Core
- SQLite

## Passo-a-Passo para execução do Projeto
1. Baixe e rode o projeto pelo Visual Studio (Projeto foi construído através do VS 2019), e então será redicionada a aplicação para uma página web do Swagger, onde foi utilizado para facilitar o teste e documentação da API.
2. Execute a rota disponível na página **/api/v1/ImportarDados**  através do Swagger (isso fará a importação dos dados do arquivo CSV para o Banco de Dados SQLite)
3. Execute a API na rota **api/v1/Produto/?CodigoGtin=valor** para consultar produtos do Banco de Dados, onde será listado o último produto vendido de cada estabelecimento, ordenado pelo menor preço.

