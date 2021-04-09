# BlueBank Prueba Tecnica

_BlueBank lo ha contratado para renovar su sistema financiero core de gestión de cuentas de
ahorro. Necesitamos una solución que se ajuste a las necesidades de la compañía, que
permita ser competitivo en un mercado en el cual el tiempo de respuesta, confiabilidad y
seguridad de la plataforma pueden decidir si la compañía continúa o no_

![image](https://user-images.githubusercontent.com/55601495/114241535-e4cbea80-994e-11eb-9d42-dabfdb2f506c.png)


## Instalacion 🚀

_Necesitas Visual Studio 2017 - 2019, ASP.Net Core 3.1, Un manejador de consultas que admita sql server y Postman.
Clona este repositorio, pon proyecto de inicio multiples y corres la Api Rest del Backend y el Frontend al tiempo, en el proyecto BlueBankFRONT agrega la dirección local en donde esta corriendo la api rest

Ejemplo: BlueBankApi: https://localhost:44393/_


### Despliegue 🔧

_El despligue continuo de este repositorio esta activo en la rama master, cuando se haga un commit en ésta rama se construira una imagen de docker y se subira a DockerHub, las app services de Azure tanto de la api como de la aplicacion web con vista se actualizaran con respecto a DockerHub en automatico. _

```
docker push devronald/bluebankback:latest
docker push devronald/bluebankfront:latest
```
* [Frontend](https://webappbluebankfront.azurewebsites.net/) 
* [Api REST](https://webappbluebank.azurewebsites.net)

## Tablas Usadas

![image](https://user-images.githubusercontent.com/55601495/114241448-bf3ee100-994e-11eb-9e85-9f8934208e69.png)


## Autor ✒️

* **Ronal Gelvez.**

