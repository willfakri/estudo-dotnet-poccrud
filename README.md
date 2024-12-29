# estudo-dotnet-poccrud
Estudo de projeto dotnet completo e configurações em ambiente de desenvolvimento no Linux Ubuntu.


#Criação do projeto com template
dotnet new web -o MeuProjeto -f net8.0

#
dotnet add package Microsoft.EntityFrameworkCore.Sqlite (aqui pode ser outros DBs de sua escolha)
dotnet add package Microsoft.EntityFrameworkCore.Design

# A configuração do DbContext foi feita no override por praticidade, mas o ideal é via appsettings.
TODO: refatorar para usar via appsettings

# Sempre dar build antes de executar migrations
dotnet clean
dotnet build

# Esse comando aplica as alterações no projeto dotnet
dotnet ef migrations add 0001

# Esse comando aplica as alterações no banco de dados
dotnet ef database update

# Dica: não deixar estocar código na hora de fazer migração pro database

# Existe o comando migrations remove, mas o recomendado é fazer as alterações sempre de forma sequencial, sem voltar (foward only)
dotnet ef migrations remove

