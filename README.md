<div align="center">
    
</div>

<div align="center">
  <a href="#sobre">Sobre</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#iniciando">Aplicação 1</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#iniciando2">Aplicação 2</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#deploy">Deploy</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#exemplo">Exemplo</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
 

</div>


## Sobre

Teste Ingaia para apresentação do calculo do valor do imóvel com base em um valor de uma unidade de medida


## Requisitos

- [**Git**](https://git-scm.com/)
- [**Node.js**](https://nodejs.org/en/)
- [**Docker**](https://www.docker.com/)
- [**Visual Studio Code**](https://code.visualstudio.com)
- [**Heroku**](https://dashboard.heroku.com/login)
## Aplicação 1

```Git Bash
    
  $ Usando Bash, com o docker rodando 
  - cd api_1/TesteIngaia
  - docker-compose up
  
  Será iniciado a imagem do docker com o banco mongo, para a aplicação 1, 
  responsável por cadastrar as unidades de medidas e seus valores correspondentes.
```

## Aplicação 2
```
  $ Usando Bash, abrir api 2
  - cd api_3/src
  - npm install
  - npm start
  
  Será iniciado a api 2 responsável por consumir a api 1 e retornar o valor do preço do imóvel. 
```

## Deploy

```Powershell
$ Com a conta criada no Heroku e configurado o app e a conexão e permissões:

- cd api_1/TesteIngaia
- docker build -t testeingaia1:latest .
- heroku container:push -a testeingaia:latest web --app ingaiaapp1
- heroku container:release -a testeingaia:latest web --app ingaiaapi1



```

## Exemplo

![alt text](sancorjira/examples/Registrar.PNG?raw=true "Registrar")

