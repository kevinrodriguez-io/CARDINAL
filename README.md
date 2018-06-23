# Notas

El proyecto está separado en tres capas

La capa de Model contiene la base de datos, Utilizando el ORM entity framework
se utilizan migraciones para ejecutar cambios en la base de datos y versionar.

Si es la primera vez ejecutando el programa, deberá abrir la Consola de Package Manager
y ejecutar un update-database para asegurarse de que la base de datos se cree con las
migraciones que están en el folder de migrations.

La capa de Service contiene la lógica de negocios y lógica compartida, así como utilidades
que son inyectadas mediante dependency injection.

El proyecto utiliza Unity container para manejar la inyección de dependencias y hacer
mucho más fácil la creación de forms que utilizen servicios inyectables.

Para poder utilizar dependency injection en un form con su respectivo servicio se deben
realizar los siguientes pasos:

1- Registar el servicio que se desea inyectar en Program.cs (Seguir los ejemplos)
2- Registar el form que desea recibir el servicio inyectable en Program.cs
3- Instanciar el form pero en lugar de usar new MiForm(), usar Program.Container.Resolve < MiForm >, ver ejemplo en Main.cs

Al usar .Resolve, el container pasa por parametro todas las dependencias que ya ha registrado,
tales como el DbContext y demás servicios que han sido inyectados previamente. Nos ahorra mucho código
y facilita el manejo de dependencias siguiendo buenas prácticas modernas.
