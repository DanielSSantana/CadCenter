# Seja bem vindo(a) ao repositório CadCenter 👋

Esse repositorio contem o projeto de uma api e uma apicação ASP MVC .Net.
O projeto ainda esta sendo evoluido, e foi iniciado em 07/02/2024, então não se assuste se as coisas ainda não funcionarem por enquanto.
A ideia é colocar aqui todos os conhecimentos possiveis adquiridos.
Como:
 + Design patterns
 + Cache (Local e Redis)
 + Integrações
 + SignalR
 + DDD
 + Mensageria
 + Microserviços
 + Middlewares
 + Ef Core, Dapper
 + Baco relacional e não relacional (Sql server, MongoDb)
Outro repositorio será criado contendo a aplição de front end em feita em Angualar. Disponibilizarei o link aqui, em breve.

## Resumo

O projeto CadCenter trata-se de uma central de cadastros. Quando concluído, deve permitir o cadastro de pessoas, endereços e seus dados de contatos de forma integrada e eficiente. Para enriquecer ainda mais o projeto, algumas ideias de novos recursos e tecnologias que serão implementados:

Integração com APIs de Geolocalização: Implementar uma integração com APIs de geolocalização, como o Google Maps API, para enriquecer os cadastros de endereços com informações de latitude, longitude e detalhes geográficos.

Autenticação e Autorização com Azure Active Directory (AAD): Utilizar o Azure Active Directory para implementar um sistema robusto de autenticação e autorização baseado em tokens JWT, garantindo a segurança dos dados e o controle de acesso aos recursos da API.

Regras de Negócio:

Validar a idade mínima dos usuários cadastrados, de acordo com as leis locais, para cumprir regulamentos de proteção de dados.
Implementar regras de validação de CPF e CNPJ para garantir a integridade dos dados cadastrados.
Verificar a unicidade de endereços e dados de contato para evitar duplicidades no sistema.

Banco de Dados SQL Server e MongoDB:

Utilizar o SQL Server para armazenar informações estruturadas, como dados de cadastro de pessoas e endereços, aproveitando recursos de transações e suporte a consultas complexas.
Integrar o MongoDB para armazenar dados não estruturados ou semi-estruturados, como logs de eventos ou informações adicionais dos cadastros, aproveitando a flexibilidade e escalabilidade oferecidas pelo NoSQL.

Cache com Redis:

Implementar o Redis como um mecanismo de cache para armazenar dados temporários e frequentemente acessados, reduzindo a latência e melhorando o desempenho da API.

Documentação da API com Swagger: Utilizar o Swagger para documentar automaticamente a API, fornecendo uma interface interativa para os usuários explorarem e testarem os endpoints da aplicação.

Testes Automatizados: Implementar testes automatizados, como testes unitários e testes de integração, para garantir a qualidade e a estabilidade da aplicação em diferentes cenários de uso.

Essas são apenas algumas ideias para enriquecer o projeto CadCenter e torná-lo mais completo e robusto. 

