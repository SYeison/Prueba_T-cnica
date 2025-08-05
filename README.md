# 🗳 Sistema de Votaciones - API RESTful

Este proyecto implementa una API para la gestión de un sistema de votación, desarrollado con ASP.NET y Entity Framework. Permite registrar votantes y candidatos, emitir votos y obtener estadísticas del proceso electoral.

---

##  Instrucciones para ejecutar el proyecto localmente

### ✅ Requisitos

- Visual Studio 2022
- .NET Framework 4.8
- SQL Server 
- Postman
## Documentación POSTMAN
[archivo](https://github.com/SYeison/Prueba_T-cnica/blob/main/Imagenes/Sistema%20de%20votacion.postman_collection.json)

##  Pasos

1. Clona este repositorio:
   ```bash
   git@github.com:SYeison/Prueba_T-cnica.git
   ```
2. link de la conexión de la base de datos
   ```bash
   <connectionStrings>
   <add name="DBSistemaVotacionEntities" connectionString="metadata=res://*/Models.DBSistemaVotacion.csdl|res://*/Models.DBSistemaVotacion.ssdl|res://*/Models.DBSistemaVotacion.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=SistemaVotaciones;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
 </connectionStrings>
```


 ## Ejemplos de uso del API con POSTMAN
 ```voters
http://localhost:62465/Help/Api/POST-api-voters-Insertar
{
  "Id": 1,
  "Nombre": "sample string 2",
  "Email": "sample string 3",
  "HasVoted": true
}
```
```Votes
http://localhost:62465/Help/Api/POST-api-Votes-Emitir
Sample:
{
  "Id": 1,
  "VotanteId": 2,
  "CandidatoId": 3
}
```
```Candidates
http://localhost:62465/Help/Api/POST-api-candidates-Insertar
{
  "Id": 1,
  "Nombre": "sample string 2",
  "Partido": "sample string 3",
  "Votos": 4
}
```


## Obtener estadística
```{
    "TotalVotos": 2,
    "Resultados": [
        {
            "Nombre": "David López",
            "Votos": 1,
            "Porcentaje": "50,00%"
        },
        {
            "Nombre": "Camila Mendoza",
            "Votos": 1,
            "Porcentaje": "50,00%"
        },
        {
            "Nombre": "Lucía Herrera",
            "Votos": 0,
            "Porcentaje": "0,00%"
        }
    ],
    "TotalVotantes": 2 
}
```
---

**Desarrollado como parte de una prueba técnica**  
**Nombre**: Yeison Andres Sanchez Rodas  
**Fecha**: 05/08/2025

--- 
