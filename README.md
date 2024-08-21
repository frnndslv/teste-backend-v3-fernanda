# Modificaçoes Teste Backend

O projeto foi modificado / reestruturado com criaçao de nova solution e modificaçao de solutions existentes.

## Inclusao de Solution DBtheatrical: pasta com toda estrutura / codigo de construção e configuraçao para o banco. 
Solution DBtheatrical contem as pastas :
APIs(pasta contendo a criação das Apis) 
Dbcontext (contendo string de configuraçao do banco)
Migrations(automaçao da criaçao do banco)
Models (contem todos os objetos )

## Modificaçao Solution TheatricalPlayersRefactoringKata

Organizaçao por pastas
Models: dentro de models, foi adcionado as classes / objetos ja existentes: Invoice, Item, Performance, Play. bem como tambem foi criado as classes statemente(pra ser usada na criaçao da estrutura do xml)  e Genre (com implementaçao de metodos com calculos de atuais e novos generos )
Service(Inclusao do genero history na classe Statementeprinter )
Utils(Utf8StringWriter, faz o xml converter pra txt com utf-8)

## modificaçoes arquivos .csproj
Atualizaçao do "Microsoft.EntityFrameworkCore" Version="8.0.8"

## modificação StatementPrintertexts
inclui o teste unitario para o arquivo xml














