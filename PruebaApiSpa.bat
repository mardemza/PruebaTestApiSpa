REM --- Instalo los paquetes DOTNET ---
dotnet restore
CD src\PruebaApiSpa.EntityFrameworkCore
REM --- Instalo EF Global si no esta instalado ---
dotnet tool install --global dotnet-ef
REM --- Ejecuto actualización para generar base local de SQLite ---
dotnet ef database update --startup-project ../PruebaApiSpa.Web.Host/PruebaApiSpa.Web.Host.csproj
CD ..\PruebaApiSpa.Web.Host\ClientApp
REM --- Instalo Angular CLI si no esta instalado ---
CALL npm i -g @angular/cli
REM --- Instalo dependencias del Proyecto Angular ---
CALL npm install
REM --- Lanzo proyecto Angular en otra consola---
START CMD /k "ng serve -o"
CD ..
REM --- Ejecuto el proyecto API REST ---
dotnet run
