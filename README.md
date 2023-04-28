<h1>Lab API Software - Sistema de Automação Médica</h1>
<h3>Aplicativo API para Gerenciamento de Médicos, Enfermeiros e Pacientes</h3>

<h2>Sistema:</h2>

<p>O LabAPI Software executa o gerenciamento dos cadastros de médicos, enfermeiros e pacientes através da insersão, busca e alteração no banco de dados. </p>
<p>O LabAPI Software fornece o registro de atendimento dos médicos e a atualização do status do paciente quando atendido.</p>
<p>_________________</p>



<h2>Tecnologias:</h2>

| Linguagem | Documentação |
| ------ | ------ |
| C# | [https://learn.microsoft.com/pt-br/dotnet/csharp/] |


| Framework / Plugins | Documentação |
| ------ | ------ |
| Microsoft.EntityFrameworkCore | [https://learn.microsoft.com/pt-br/ef/] |
| Microsoft.EntityFrameworkCore.Design | [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore] |
| Microsoft.EntityFrameworkCore.SqlServer | [https://learn.microsoft.com/pt-br/ef/core/providers/sql-server/?tabs=dotnet-core-cli] |
| Microsoft.EntityFrameworkCore.Tools  | [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/] |
| Newtonsoft.Json  | [https://www.newtonsoft.com/json/help/html/introduction.htm] |
| Swashbuckle.AspNetCore  | [https://learn.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio] |
<p>_________________</p>


<h2>Instalação </h2>


Para iniciar o aplicativo começamos pelo [Microsoft.EntityFrameworkCore] usando os comandos abaixo para a instalação das dependências e iniciar o servidor.


```dotnet add package Microsoft.EntityFrameworkCore.Sqlite```


Na sequência instalaremos o[Microsoft.EntityFrameworkCore.Design] usando os comando abaixo: 

```dotnet add package Microsoft.EntityFrameworkCore --version 7.0.5```


Instalaremos agora o [Microsoft.EntityFrameworkCore.SqlServer] para fazer a integração com banco de dados. 

```dotnet add package Microsoft.EntityFrameworkCore.SqlServer```


Instalaremos também o [Microsoft.EntityFrameworkCore.Tools] usando o comando abaixo: 

```dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.5```


Por fim, instalaremos o [Swashbuckle.AspNetCore] para poder atualizar o servidor automaticamente.

```dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 6.2.3```

<p>_________________</p>

<h2>Padrões Utilizados</h2>

O projeto foi executado em pastas para oferecer uma melhor compreensão do código. Veja como está idealizado:

- [src] - Pastas Controllers, Models, Enums e DTOs;
- [enums] - Pasta com arquivo de classes do tipo enums;
- [models] - Arquivos de criação de tabelas no banco de dados;
- [controllers] - Pastas com os arquivos das requisições da aplicação. Constam os arquivos Paciente, Medicos, Enfermeiros e Atendimento;

Nas pastas os arquivos estão separados conforme a sua função. 

O arquivo [Program.cs] que consta no arquivo raiz é o início do projeto e faz a ligação com o banco de dados. 
<p>_________________</p>

<h2>Requisições, Descrição e Path</h2>

<p>A aplicação consta com 3 sessões de requisições, sendo elas, Paciente, Medicos, Enfermeiros. Abaixo você confere as informações principais para a utilização das requisições, suas funções e path's:</p>

<h3>Rotas PACIENTES >>></h3>

Requisição: CriarPaciente;
Descrição: Cria e insere um paciente novo no banco de dados;
Método: POST;
Path: http://localhost:5011/Pacientes/CriarPaciente
Modelo do body:
```sh
{
  "nomeCompleto": "",
  "genero": "",
  "dataNascimento": "",
  "cpf": "",
  "telefone": "",
  "contatoEmergencia": "",
  "alergias": [""],
  "cuidadosEspecificos": [""],
  "convenio": ""
}
```
Requisição: AtualizarPaciente;
Descrição: Atualiza as informações pelo id de um paciente já cadastrado no banco de dados;
Método: PUT;
Path: http://localhost:5011/Pacientes/AtualizarPaciente/{id}
Modelo do body:
```sh
{
  "nomeCompleto": "",
  "genero": "",
  "dataNascimento": "",
  "cpf": "",
  "telefone": "",
  "contatoEmergencia": "",
  "alergias": [""],
  "cuidadosEspecificos": [""],
  "convenio": ""
}
```

Requisição: StatusPaciente;
Descrição: Altera o Status do paciente no banco de dados pelo id;
Método: PUT;
Path: http://localhost:5011/Pacientes/StatusPaciente/{id}/status
Modelo do body:
```sh
{
  "novoStatus": "",
  "statusAtendimento": "AguardandoAtendimento"
}
```

Requisição: BuscarPaciente;
Descrição: Gera uma lista dos pacientes cadastrados no banco de dados, podendo ser filtrado pelos campos ["AGUARDANDOATENDIMENTO", "EMATENDIMENTO", "ATENDIDO", "NAOATENDIDO"];
Método: GET;
Path: 
http://localhost:5011/Pacientes/BuscarPaciente

Requisição: BuscarPaciente;
Descrição: Busca o paciente no banco de dados pelo Id;
Método: GET;
Path: http://localhost:5011/Pacientes/BuscarPaciente/{id}


Requisição: DeletePaciente;
Descrição: Busca o paciente no banco de dados pelo Id e exclui do banco de dados;
Método: DELETE;
Path: http://localhost:5011/Pacientes/DeletePaciente/{id}

<p>_________________</p>

<h3>Rotas MEDICOS >>></h3>

Requisição: CriarMedico;
Descrição: Cria um médico novo no banco de dados;
Método: POST;
Path: http://localhost:5011/Medicos/CriarMedico
Modelo do body:
```sh
{
  "nomeMedico": "",
  "genero": "",
  "dataNascimento": "",
  "cpf": "",
  "telefone": "",
  "instituicaoEnsinoFormacao": "",
  "crM_UF": "",
  "especializacao_Clinica": 1,
  "especializacaoClinica": [""],
  "estado_No_Sistema": 0,
  "totalAtendimentos": 0
}
```


Requisição: AtualizarMedico;
Descrição: Atualiza as informações de um médico já criado no banco de dados pelo id;
Método: PUT;
Path: http://localhost:5011/Medicos/AtualizarMedico/{identificador}
Modelo do body:
```sh
{
  "nomeMedico": "",
  "genero": "",
  "dataNascimento": "",
  "cpf": "",
  "telefone": "",
  "instituicaoEnsinoFormacao": "",
  "crM_UF": "",
  "especializacao_Clinica": 1,
  "especializacaoClinica": [""],
  "estado_No_Sistema": 0,
  "totalAtendimentos": 0
}
```

Requisição: StatusMedico;
Descrição: Altera o Status do médico no banco de dados;
Método: PUT;
Path: http://localhost:5011/Medicos/StatusMedico/{identificador}/status
Modelo do body:
```sh
{
  "novoStatus": "",
  "statusDisponiveis": [0]
}
```


Requisição: BuscarMedico;
Descrição: Gera uma lista dos médicos cadastrados, podendo filtrar por ["ATIVO"] ou ["INATIVO"];
Método: GET;
Path: http://localhost:5011/medicos/buscarmedico?status=inativo


Requisição: BuscarMedico;
Descrição: Busca o médico no banco de dados pelo Id;
Método: GET;
Path: http://localhost:5011/medicos/buscarmedico/{id}


Requisição: DeleteMedico;
Descrição: Busca o médico pelo Id e exclui do banco de dados;
Método: DELETE;
Path: http://localhost:5011/medicos/DeleteMedico/{id}

<p>_________________</p>

<h3>Rotas ENFERMEIROS >>></h3>

Requisição: CriarEnfermeiro;
Descrição: Cria um enfermeiro novo no banco de dados;
Método: POST;
Path: http://localhost:5011/enfermeiros/criarEnfermeiro
Modelo do body:
```sh
{
  "id": 0,
  "nomeCompleto": "",
  "genero": "",
  "dataNascimento": "",
  "cpf": "",
  "telefone": "",
  "instituicaoEnsinoFormacao": "",
  "totalAtendimentos": 0,
  "cofeN_UF": ""
}
```

Requisição: AtualizarEnfermeiro;
Descrição: Atualiza as informações de um enfermeiro já criado no banco de dados pelo id;
Método: PUT;
Path: http://localhost:5011/enfermeiros/atualizarEnfermeiro/{id}
Modelo do body:
```sh
{
  "id": 0,
  "nomeCompleto": "",
  "genero": "string",
  "dataNascimento": "",
  "cpf": "",
  "telefone": "",
  "instituicaoEnsinoFormacao": "",
  "totalAtendimentos": 0,
  "cofeN_UF": ""
}
```

Requisição: BuscarEnfermeiro;
Descrição: Gera uma lista dos enfermeiros cadastrados no banco de dados;
Método: GET;
Path: http://localhost:5011/enfermeiros/buscarEnfermeiro


Requisição: BuscarEnfermeiro;
Descrição: Busca o enfermeiro no banco de dados pelo Id;
Método: GET;
Path: http://localhost:5011/enfermeiros/buscarEnfermeiro/{id}


Requisição: DeleteEnfermeiro;
Descrição: Busca o enfermeiro pelo Id e exclui do banco de dados;
Método: DELETE;
Path: http://localhost:5011/enfermeiros/deleteEnfermeiro/{id}

<p>_________________</p>

<h3>Rotas ATENDIMENTOS >>></h3>


Requisição: Atendimentos;
Descrição: Enviando o body com Id do paciente e Id do médico, com campo observação para detalhes da consulta, inicia o atendimento, atualiza o status do paciente para "Atendido" e incrementa um atendimento na contagem de atendimentos de ambos. 
Método: POST;
Path: http://localhost:5011/atendimentos/atendimentoMedico
Modelo do body:
```sh
{
    "PacienteId": "9",
    "MedicoId": "1",
    "Observacoes": ""
}
```

<p>_________________</p>

<h2>Sugestões e Melhorias:</h2>

- FrontEnd - A API pode receber um FrontEnd para melhorar a usabilidade;
- Rotas - A API pode receber novas rotas e oferecer novas funcionalidades, por exemplo:
     ```sh
     + Rotas para listar pacientes atendidos por determinado Médico;
     ```
    ```sh
     + Inclusão de contagem de atendimento para Nurses;
     ```
     ```sh
     + Criação de attendence para Nurses;
     ```
     ```sh
     + Sistema de login para os usuários do sistema;
     ```
- Models - As especificações de cada model podem ser aprimoradas;
- ...