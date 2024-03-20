# Adopt-Pet 🐶

  <a href="#sumario">Português <img width="20px" src="https://www.bing.com/th?id=OIP.avWx6zurTwFtYTuHW8SnwwHaFL&w=140&h=100&c=8&rs=1&qlt=90&o=6&pid=3.1&rm=2" alt="Bandeira Do Brasil"></a>
  
  <a href="#summary">English <img width="20px" src="https://th.bing.com/th?id=OIP.WZd_NaiNtbSrSGH0aQEgUQHaEz&w=310&h=201&c=8&rs=1&qlt=90&o=6&pid=3.1&rm=2" alt="Bandeira Do Brasil"></a>

  <hr>












# Summary
<details open="open">
  <summary>Content</summary>
  <ol>
    <li>
      <a href="#overview">About The Project</a>
      <ul>
        <li><a href="#features">Features</a></li>
        <li><a href="#automated-tests">Automated Tests</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#requirements">Requisitos</a></li>
        <li><a href="#requirements">Instalação</a></li>
      </ul>
    </li>
  </ol>

## Overview

This Project is a API implemented in .Net 7.0 that was built using the Doman Drive Design (DDD) estructure

The Project aims to improve my skills in c#, software architecture and I.A

This Project is pretty simple, but i implement Various Tecnologias, as (DDD)
Integration Testes for all Projects and Scrum during its development

This Api allow that you adopt a Pet without leaving home, You can even talk to the shelter that has the pet
in addition if you are a Shelter you can put your pets to Application and give more chance of pet be adopted 🐶


## Features

- Register a Pet
- Register a Shelder
- Adopted a Pet
- Image Verification With I.A 

![SwaggerImage](./Assets/ImgSwagger1.png)

## Automated Tests

The web API also includes automated tests for each identity

## Getting Started

### Requirements

- A Azure Account

  ## Installation
  1. Faça o clone do repositório
   ```sh
   git clone https://github.com/Gabrielbprado/Adopt-Pet.Api.git
   ```

In the 'Adopt.Domain' folder, navigate to the 'FileAzure' and go to Line 10.
```BlobServiceClient blobServiceClient = new BlobServiceClient("Your Connection Key do Azure Storage");```
replace ``` Your Connection Key do Azure Storage ``` for your Azure Storege Key

you can see how create a Azure Storege Key bellow

[How to Create the Key"](https://www.bing.com/ck/a?!&&p=3b296f6d3d87c014JmltdHM9MTcwODU2MDAwMCZpZ3VpZD0wNGU0MWVkZi1kMWRkLTYwYWMtMzllMy0wZDIyZDAyNjYxNWMmaW5zaWQ9NTUyMA&ptn=3&ver=2&hsh=3&fclid=04e41edf-d1dd-60ac-39e3-0d22d026615c&psq=Como+criar+um+AzureBlob+storage&u=a1aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL3B0LWJyL2F6dXJlL3N0b3JhZ2UvYmxvYnMvcXVpY2tzdGFydC1zdG9yYWdlLWV4cGxvcmVyIzp-OnRleHQ9SW4lQzMlQURjaW8lMjBSJUMzJUExcGlkbyUzQSUyMFVzYXIlMjBvJTIwR2VyZW5jaWFkb3IlMjBkZSUyMEFybWF6ZW5hbWVudG8lMjBkbyx1bWElMjBBc3NpbmF0dXJhJTIwZGUlMjBBY2Vzc28lMjBDb21wYXJ0aWxoYWRvJTIwLi4uJTIwTW9yZSUyMGl0ZW1z&ntb=1)

```after go to The Archive Visionia.cs in the line 38 client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "Your Key");```

replace ```Your Key``` For your Subcribed Key

[See How Here](https://www.bing.com/ck/a?!&&p=f1565e7f6cf9e00fJmltdHM9MTcwODU2MDAwMCZpZ3VpZD0wNGU0MWVkZi1kMWRkLTYwYWMtMzllMy0wZDIyZDAyNjYxNWMmaW5zaWQ9NTQ4Nw&ptn=3&ver=2&hsh=3&fclid=04e41edf-d1dd-60ac-39e3-0d22d026615c&psq=Como+criar+uma+conta+Vision+Studio&u=a1aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL3B0LXB0L2F6dXJlL2FpLXNlcnZpY2VzL2NvbXB1dGVyLXZpc2lvbi9vdmVydmlldy12aXNpb24tc3R1ZGlvIzp-OnRleHQ9Q3JpZSUyMHVtYSUyMFN1YnNjcmklQzMlQTclQzMlQTNvJTIwZG8lMjBBenVyZSUyMHNlJTIwYWluZGElMjBuJUMzJUEzbyxQb2RlJTIwaWdub3JhciUyMGVzdGUlMjBwYXNzbyUyMGUlMjBmYXolQzMlQUEtbG8lMjBtYWlzJTIwdGFyZGUu&ntb=1)

For Test is onlyne execute The Command 
```Dotnet Run```
In The Paste Adopt.Api or
Open The Archive Adopt.Sln and Run the archive Adopt.Api

# EndPoints

## Shelter

- Post: /api/Abrigo/v1/cadastrar
  
- Get: /api/Abrigo/v1/listarAll
  
- Get{id}: /api/Abrigo/v1/{id}
  
- Delete: /api/Abrigo/v1/deletar/{id}

- Post(Login): /api/Abrigo/v1/login
  

## Adocao

- Post: /api/Adocao/v1/adotar
  
- Delete: /api/Adocao/v1/deletar{id} **only Shelter can Delete**
  

## Pet

- Post: /api/pet/v1/cadastrar
  
- Get: /api/pet/v1/listarAll
  
- Get{id}: /api/pet/v1/{id}
  
- Delete: /api/pet/v1/{id}

  ## Tutor

  - Post: /api/Tutor/v1/cadastrar
    
  - Get: /api/Tutor/v1/{username}
    
  - Delete: /api/Tutor/v1/deletar/{id}
    
  - Post(Login): /api/Tutor/v1/login
    
  - Patch: /api/Tutor/v1/uploadPhoto/{id}


# Sumario

<details open="open">
  <summary>Conteúdo</summary>
  <ol>
    <li>
      <a href="#visão-geral">Sobre o Projeto</a>
      <ul>
        <li><a href="#recursos">Recursos</a></li>
        <li><a href="#testes-automatizados">Testes Automatizados</a></li>
      </ul>
    </li>
    <li>
      <a href="#começando">Começando</a>
      <ul>
        <li><a href="#requisitos">Requisitos</a></li>
        <li><a href="#instalação">Instalação</a></li>
      </ul>
    </li>
  </ol>







  

## Visão Geral

Este projeto é uma API implementada em .Net 7.0 que foi construída usando a estrutura Domain-Driven Design (DDD).

O objetivo do projeto é melhorar minhas habilidades em c#, arquitetura de software e IA.

Este projeto é bastante simples, mas implemento várias tecnologias, como (DDD), Testes de Integração para todos os Projetos e Scrum durante seu desenvolvimento.

Esta API permite que você adote um animal de estimação sem sair de casa. Você até pode conversar com o abrigo que possui o animal. Além disso, se você for um abrigo, pode colocar seus animais de estimação no aplicativo e dar mais chances de adoção aos animais 🐶

## Recursos

- Registrar um Animal de Estimação
- Registrar um Abrigo
- Adotar um Animal de Estimação
- Verificação de Imagem com IA

![Imagem do Swagger](./Assets/ImgSwagger1.png)

## Testes Automatizados

A API web também inclui testes automatizados para cada identidade.

## Começando

### Requisitos

- Uma conta do Azure

### Instalação

1. Clone o repositório
   ```sh
   git clone https://github.com/welissonArley/MeuLivroDeReceitas.git
   ```

   Na pasta 'Adopt.Domain', navegue até 'FileAzure' e vá para a Linha 10.
   
BlobServiceClient blobServiceClient = new BlobServiceClient("Sua Chave de Conexão do Azure Storage");

 Substitua 'Sua Chave de Conexão do Azure Storage' pela sua Chave do Azure Storage.

 Você pode ver como criar uma Chave do Azure Storage abaixo.
 [Como Criar a Chave](https://www.bing.com/ck/a?!&&p=3b296f6d3d87c014JmltdHM9MTcwODU2MDAwMCZpZ3VpZD0wNGU0MWVkZi1kMWRkLTYwYWMtMzllMy0wZDIyZDAyNjYxNWMmaW5zaWQ9NTUyMA&ptn=3&ver=2&hsh=3&fclid=04e41edf-d1dd-60ac-39e3-0d22d026615c&psq=Como+criar+um+AzureBlob+storage&u=a1aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL3B0LWJyL2F6dXJlL3N0b3JhZ2UvYmxvYnMvcXVpY2tzdGFydC1zdG9yYWdlLWV4cGxvcmVyIzp-OnRleHQ9SW4lQzMlQURjaW8lMjBSJUMzJUExcGlkbyUzQSUyMFVzYXIlMjBvJTIwR2VyZW5jaWFkb3IlMjBkZSUyMEFybWF6ZW5hbWVudG8lMjBkbyx1bWElMjBBc3NpbmF0dXJhJTIwZGUlMjBBY2Vzc28lMjBDb21wYXJ0aWxoYWRvJTIwLi4uJTIwTW9yZSUyMGl0ZW1z&ntb=1)

 Depois, vá para o arquivo 'Visionia.cs' na linha 38.
client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "Sua Chave");
 Substitua 'Sua Chave' pela sua Chave de Assinatura.

// [Veja Como Aqui](https://www.bing.com/ck/a?!&&p=f1565e7f6cf9e00fJmltdHM9MTcwODU2MDAwMCZpZ3VpZD0wNGU0MWVkZi1kMWRkLTYwYWMtMzllMy0wZDIyZDAyNjYxNWMmaW5zaWQ9NTQ4Nw&ptn=3&ver=2&hsh=3&fclid=04e41edf-d1dd-60ac-39e3-0d22d026615c&psq=Como+criar+uma+conta+Vision+Studio&u=a1aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL3B0LXB0L2F6dXJlL2FpLXNlcnZpY2VzL2NvbXB1dGVyLXZpc2lvbi9vdmVydmlldy12aXNpb24tc3R1ZGlvIzp-OnRleHQ9Q3JpZSUyMHVtYSUyMFN1YnNjcmklQzMlQTclQzMlQTNvJTIwZG8lMjBBenVyZSUyIHNlJTIwYWluZGElMjBuJUMzJUEzbyxQb2RlJTIwaWdub3JhciUyMGVzdGUlMjBwYXNzbyUyMGUlMjBmYXolQzMlQUEtbG8lMjBtYWlzJTIwdGFyZGUu&ntb=1)

// Para testar se está online, execute o comando 'Dotnet Run' na pasta 'Adopt.Api' ou abra o Arquivo 'Adopt.Sln' e execute o arquivo 'Adopt.Api'.

// EndPoints

// Abrigo

- Post: /api/Abrigo/v1/cadastrar
  
- Get: /api/Abrigo/v1/listarAll
  
- Get{id}: /api/Abrigo/v1/{id}
  
- Delete: /api/Abrigo/v1/deletar/{id}

- Post(Login): /api/Abrigo/v1/login

// Adoção

- Post: /api/Adocao/v1/adotar
  
- Delete: /api/Adocao/v1/deletar{id} apenas o Abrigo pode Excluir

// Pet

- Post: /api/pet/v1/cadastrar
  
- Get: /api/pet/v1/listarAll
  
- Get{id}: /api/pet/v1/{id}
  
- Delete: /api/pet/v1/{id}

// Tutor

- Post: /api/Tutor/v1/cadastrar
    
- Get: /api/Tutor/v1/{username}
    
- Delete: /api/Tutor/v1/deletar/{id}
    
- Post(Login): /api/Tutor/v1/login
    
- Patch: /api/Tutor/v1/uploadPhoto/{id}







