# Proyecto template .NET 5 WebAPI
**Incluye**
- WebAPI .NET 5
- Swagger
- Seguridad via JWT
- Envío de mails
- Log (mediante [Serilog](https://serilog.net/))
- ActionFilters útiles

## Utilización
Para utilizar este template, es necesario:
1. clonar este proyecto
2. dentro del repo, movernos a la carpeta `templates/webapi` e instalar el template ejecutando:
`dotnet new --install . `
3. ya tenemos nuestro template instalado, para crear nuevos proyectos utilizandolo debemos ejecutar:
`dotnet new fmcw-webapi-template -n NombreSolucionACrear`
**NOTA** en caso de mover nuestro repo de lugar, es necesario [desinstalarlo](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates#:~:text=config%20folder.-,Uninstalling%20a%20template,file%20directly%2C%20provide%20the%20identifier.&text=If%20the%20package%20was%20installed%20by%20specifying%20a%20path%20to%20the%20.) para luego volver a instalarlo (paso 2)


## WebAPI .NET 5
El proyecto es una WebAPI .NET 5. Se utliza inyección de dependencias para las dependencias utilizadas (envío de mails, seguridad, etc). Toda la configuración pre-definida podemos encontrarla en la clase [StartupConfiguration.cs](templates/webapi/FMCW.Template/FMCW.Template.API/StartupConfiguration.cs)

## Swagger
Se define en [ConfigureSwagger](templates/webapi/FMCW.Template/FMCW.Template.API/StartupConfiguration.cs#L15), leyendo del appsettings.json la configuración de nuestra API (section `Application`)

## Seguridad vía JWT
Se define mediante el [JwtManager.cs](templates/webapi/FMCW.Template/FMCW.Template.Security/JwtManager.cs) y el [action filter de seguridad](templates/webapi/FMCW.Template/FMCW.Template.API/Controllers/ActionFilter/ValidateJwtActionFilter.cs). La configuración necesaria se lee del `appsettings.json` section `Jwt` 
Se validará en cada request entrante si el header `Authorization` está presente y si corresponde a un JWT válido. En caso de que sí, inyectaremos el Id del usuario al que corresponde dicho token en la propiedad `IdUsuario` de [BaseController.cs](templates/webapi/FMCW.Template/FMCW.Template.API/Controllers/BaseController.cs#L9). En caso de ser un método anónimo, utilizar al attribute `NoTokenCheck`
```
[HttpGet("anonymous")]
[NoTokenCheck]
public StringResult Anonymous()
{
       var token = _manager.GenerateToken(10); // Id del usuario para el cual queremos generar el token
       var result = StringResult.Ok(token.Jwt);
       return result;
}

[HttpGet("login")]
public StringResult Login()
{
        return StringResult.Ok($"Bienvenido usuario {this.IdUsuario}");
}
```

## Envío de mails:
Mediante el método `SendMail `de [MailService.cs](templates/webapi/FMCW.Template/FMCW.Template.EmailSender/MailService.cs). La configuración para el envío de mails se lee del `appsettings.json`, section `MailConfig`

## Log 
Se define en el `Progam.cs`, y se utliza Serilog. En este proyecto poseemos dos logeos configurados: a [consola ](templates/webapi/FMCW.Template/FMCW.Template.API/Program.cs#L28) y a [archivo físico](templates/webapi/FMCW.Template/FMCW.Template.API/Program.cs#L30). Desde aquí podemos agregar nuevos outputs para nuestros logs, quitar o modificar los existentes.

## ActionFilter útiles
Actualmente poseemos dos ActionFilters: [Http Status Code](templates/webapi/FMCW.Template/FMCW.Template.API/Controllers/ActionFilter/HttpStatusCodeActionFilter.cs) y de [catcheo de excepciones no controladas](templates/webapi/FMCW.Template/FMCW.Template.API/Controllers/ActionFilter/LogExceptionActionFilter.cs). El primero setea como HTTP status code de la request el valor que posee la propiedad `ResponseStatusCode` del `BaseController.cs`. En caso que dicha propiedad sea null, no modifica modifica la respuesta.
El segundo catchea todas las excepciones no controladas, logeado la información del error y devolviendo la estructura que tenemos pre-definida.

