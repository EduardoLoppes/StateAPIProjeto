# StateAPIProjeto
Configuração do Projeto

1. Clonar o Repositório
Clone o repositório para sua máquina local usando o Git:
<br/>
bash
git clone https://github.com/EduardoLoppes/StateAPIProjeto.git
<br/>
3. Configurar a String de Conexão
Abra o arquivo appsettings.json e configure a string de conexão para o PostgreSQL em ConnectionStrings.DefaultConnection. Substitua as partes Host, Database, Username e Password com as informações do seu servidor PostgreSQL:
<br/>
json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=TaskDb;Username=seu-usuario;Password=sua-senha"
  }
}
<br/>
4. Restaurar Pacotes NuGet
No terminal ou prompt de comando, navegue até o diretório do projeto e execute o seguinte comando para restaurar os pacotes NuGet:
<br/>
bash
dotnet restore
<br/>
6. Criar o Banco de Dados e Aplicar Migrações
No Visual Studio, abra o Package Manager Console e execute os comandos para criar as migrações e atualizar o banco de dados:
<br/>
Add-Migration InitialCreate
Update-Database
