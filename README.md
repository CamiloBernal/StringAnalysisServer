# StringAnalysisServer
Proyecto de prueba para CodeTag

Autor: Camilo Bernal
Fecha publicación: 22/05/2015
Lenguaje de programación utilizado: C#
Tecnologías empleadas: Asp.Net WebApi (SelfHost), LinQ
Versión de MS Framework: 4.5.2
IDE: Visual studio 2013
Librerías externas: Ningúna

Descripción de la solución:

La solución está organizada en varios proyectos de los que destaca: “Server” y “Client”. El proyecto Server constituye 
el BackEnd de la solución y se encarga de procesar los request que se envían desde la aplicación cliente. 

El servidor está construido para ejecutarse desde una consola (Evitando la necesidad de IIS). Una vez recibe un request en la 
ruta http://localhost:8080/api/message/ mediante el verbo “Post” procesa dichos request de manera asincrónica y paralela (TPL)
invocando para cada request un objeto que implementa la interface “ITextAnalizer” que se encarga de procesar, analizar 
y dejar registro de cada reques por separado. 

El resultado del análisis es volcado a un archivo xml ubicado en la ruta que se configure en el parámetro de aplicación
(app.config) “PathToSaveStats” de la aplicación “Server”

Se utilizaron diferentes patrones de diseño, a destacar el patrón “Strategy” y 
se aplicó el principio de “Open/Closed” de SOLID. Por su parte, para los diferentes tipos de análisis sobre los textos
enviados al servidor se implementaron delegados de tal manera que se puderan aplicar nuevas “Expresiones” 
para el análisis de las cadenas. Estos delegados se pueden establecer mediante expresiones Lambda en la configuración 
del analizador (ITextAnalizer) por lo que la solución es sumamente dinámica y está orientada hacia la “DI” 
(Inyección de dependencias).


