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

<h3>Rotas Paciente >>></h3>

Método: POST;
Descrição: Cria e insere um paciente novo no banco de dados;
Path: http://localhost:5011/api/Pacientes/CriarPaciente
Modelo do body:
sh
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

Requisição: updatePatient;
Descrição: Atualiza as informações de um paciente já criado no banco de dados;
Método: PUT;
Path: http://localhost:3333/patient/:id
Modelo do body:
sh
{
    "name": "",
    "gender": "",
	"birth": "YYYY-MM-DD",
    "cpf": "",
    "phone": "",
    "emergency": "",
    "allergy": "",
    "specialCares": "",        
    "healthInsurance": ""
}


Requisição: updateStatus;
Descrição: Altera o Status do paciente no banco de dados;
Método: PUT;
Path: http://localhost:3333/patient/:id/status
Modelo do body:
sh
{
	"status": "AGUARDANDO_ATENDIMENTO"
}


Requisição: patientsList;
Descrição: Gera uma lista dos pacientes cadastrados no banco de dados, podendo ser filtrado pelos campos ["AGUARDANDO_ATENDIMENTO", "EM_ATENDIMENTO", "ATENDIDO", "NAO_ATENDIDO"];
Método: GET;
Path: 
http://localhost:3333/patient

Requisição: searchPatient;
Descrição: Busca o paciente no banco de dados pelo Id;
Método: GET;
Path: http://localhost:3333/patient/:id


Requisição: deletePatient;
Descrição: Busca o paciente no banco de dados pelo Id e exclui do banco de dados;
Método: DELETE;
Path: http://localhost:3333/patient/:id

<p>_________________</p>

<h3>Rotas Doctor >>></h3>

Requisição: createDoctor;
Descrição: Cria um médico novo no banco de dados;
Método: POST;
Path: http://localhost:3333/doctor
Modelo do body:
sh
{
	"name": "",
    "gender": "",
    "birth": "YYYY-MM-DD",
    "cpf": "",
    "phone": "",
	"academy": "",
    "crmUf": "",
	"specialization": "",
    "statusDoctor": "" 
}



Requisição: updateDoctor;
Descrição: Atualiza as informações de um médico já criado no banco de dados;
Método: PUT;
Path: http://localhost:3333/doctor/:id
Modelo do body:
sh
{
	"name": "",
    "gender": "",
    "birth": "YYYY-MM-DD",
    "cpf": "",
    "phone": "",
	"academy": "",
    "crmUf": "",
	"specialization": "",
    "statusDoctor": "" 
}


Requisição: updateStatus;
Descrição: Altera o Status do médico no banco de dados;
Método: PUT;
Path: http://localhost:3333/doctor/:id/status
Modelo do body:
sh
{
	"statusDoctor": "Inativo"
}



Requisição: doctorsList;
Descrição: Gera uma lista dos médicos cadastrados, podendo filtrar por ["ATIVO"] ou ["INATIVO"];
Método: GET;
Path: http://localhost:3333/doctor?statusDoctor=status


Requisição: searchDoctor;
Descrição: Busca o médico no banco de dados pelo Id;
Método: GET;
Path: http://localhost:3333/doctor/:id


Requisição: deleteDoctor;
Descrição: Busca o médico pelo Id e exclui do banco de dados;
Método: DELETE;
Path: http://localhost:3333/doctor/:id

<p>_________________</p>

<h3>Rotas Nurse >>></h3>

Requisição: createNurse;
Descrição: Cria um enfermeiro novo no banco de dados;
Método: POST;
Path: http://localhost:3333/nurse
Modelo do body:
sh
{
    "name": "",
    "gender": "",
    "birth": "YYYY-MM-DD",
    "cpf": "",
    "phone": "",
    "academy": "",
    "cofenUf": ""
}


Requisição: updateNurse;
Descrição: Atualiza as informações de um médico já criado no banco de dados;
Método: PUT;
Path: http://localhost:3333/nurse/:id
Modelo do body:
sh
{
    "name": "",
    "gender": "",
    "birth": "YYYY-MM-DD",
    "cpf": "",
    "phone": "",
    "academy": "",
    "cofenUf": ""
}


Requisição: nurseList;
Descrição: Gera uma lista dos enfermeiros cadastrados no banco de dados;
Método: GET;
Path: http://localhost:3333/nurse


Requisição: searchNurse;
Descrição: Busca o enfermeiro no banco de dados pelo Id;
Método: GET;
Path: http://localhost:3333/nurse/:id


Requisição: deleteNurse;
Descrição: Busca o enfermeiro pelo Id e exclui do banco de dados;
Método: DELETE;
Path: http://localhost:3333/nurse/:id

<p>_________________</p>

<h3>Rotas Service >>></h3>


Requisição: service;
Descrição: Enviando o body com Id do paciente e Id do médico, inicia o atendimento, atualiza o status do paciente para "Atendido" e incrementa um atendimento na contagem de atendimentos de ambos. 
Método: POST;
Path: http://localhost:3333/service
Modelo do body:
sh
{
    "idPatient": "9",
    "idDoctor": "1"
}

<p>_________________</p>

<h2>Sugestões e Melhorias:</h2>

- FrontEnd - A API pode receber um FrontEnd para melhorar a usabilidade;
- Rotas - A API pode receber novas rotas e oferecer novas funcionalidades, por exemplo:
     sh
     + Rotas para listar pacientes atendidos por determinado Médico;
     
    sh
     + Inclusão de contagem de atendimento para Nurses;
     
     sh
     + Criação de attendence para Nurses;
     
     sh
     + Sistema de login para os usuários do sistema;
     
- Models - As especificações de cada model podem ser aprimoradas;
- ...