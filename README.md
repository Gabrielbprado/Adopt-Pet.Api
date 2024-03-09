# Adopt-Pet 🐶
<details open="open">
  <summary>Conteudo</summary>
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
   git clone https://github.com/welissonArley/MeuLivroDeReceitas.git
   ```

In the 'Adopt.Domain' folder, navigate to the 'FileAzure' and go to Line 10.
```BlobServiceClient blobServiceClient = new BlobServiceClient("Your Key de Conexão do Azure Storage");```
replace ``` Sua Chave de Conexão do Azure Storage ``` for your Azure Storege Key

you can see how create a Azure Storege Key bellow

[How to Create the Key"](https://www.bing.com/ck/a?!&&p=3b296f6d3d87c014JmltdHM9MTcwODU2MDAwMCZpZ3VpZD0wNGU0MWVkZi1kMWRkLTYwYWMtMzllMy0wZDIyZDAyNjYxNWMmaW5zaWQ9NTUyMA&ptn=3&ver=2&hsh=3&fclid=04e41edf-d1dd-60ac-39e3-0d22d026615c&psq=Como+criar+um+AzureBlob+storage&u=a1aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL3B0LWJyL2F6dXJlL3N0b3JhZ2UvYmxvYnMvcXVpY2tzdGFydC1zdG9yYWdlLWV4cGxvcmVyIzp-OnRleHQ9SW4lQzMlQURjaW8lMjBSJUMzJUExcGlkbyUzQSUyMFVzYXIlMjBvJTIwR2VyZW5jaWFkb3IlMjBkZSUyMEFybWF6ZW5hbWVudG8lMjBkbyx1bWElMjBBc3NpbmF0dXJhJTIwZGUlMjBBY2Vzc28lMjBDb21wYXJ0aWxoYWRvJTIwLi4uJTIwTW9yZSUyMGl0ZW1z&ntb=1)

```after go to The Archive Visionia.cs in the line 38 client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "Your Key");```

replace ```Your Key``` For your SubcribedKey

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






