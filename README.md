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
Links das aplicações no heroku

- [**API 1 Endpoint unidade medida valor**](https://ingaiaapi1.herokuapp.com/swagger/index.html)
- [**API 2 Consumo API 1 e Retorno do valor**](https://ingaiaapi2.herokuapp.com/calculoImovel)

Desolvi 3 API.
*Na past api_1 foi uma implementação simples e rápida.
*Na pasta api_2, é a mesma Api da api_1, a diferença que estruturei ela usando  Drive Domain Desegn,
Repository Pattern.
*Na api_3 desenvolvi em nodejs, como é um api apenas para consumir a primeira api_1 e retornar o valor do calculo,
ficou uma implementação mais simples.

Para api 1 foi implementado todo o crud rest api.
Partindo da url https://ingaiaapi1.herokuapp.com conforme mais detalhes no swagger.

Para api 2 foi implementado 1 get que ira listar todas as unidades de medidas cadastradas e seus valores.
e foi implementando um POST que ao passar no corpo o Json {"area" : 60.23, "unidade" : "Metros"} o mesmo irá 
retornar o valor do imovés, Ficou necessário os dois parametros  pois na api pode ser cadastrados diversas
unidades de medidas e seu valor, assim o mesmo calculo pode ser feito várias vezes apenas selecionando a unidade de medida.

Obrigado.
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

![alt text](exemplo/swagger.PNG?raw=true "API ENDPOINTS")
![alt text](exemplo/consumerl.PNG?raw=true "API CONSUMER REGISTRO")
![alt text](exemplo/consumer.PNG?raw=true "API CONSUMER")
