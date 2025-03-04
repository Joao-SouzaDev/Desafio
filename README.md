# Projeto InsightLoop

Este é o repositório do projeto InsightLoop, que consiste em duas APIs: a API de Autenticação e a API de Produtos. As APIs se comunicam utilizando RabbitMQ e todas as dependências são gerenciadas via Docker Compose.

## Estrutura do Projeto

- `AuthService`: Contém a API de Autenticação.
- `ProductService`: Contém a API de Produtos.
- `FeedbackService`: Contém a API de Feedbacks.

## Pré-requisitos

- [Docker](https://www.docker.com/get-started)

## Configuração Inicial

Antes de iniciar o projeto, certifique-se de que você tem o Docker e o Docker Compose instalados na sua máquina.

## Como Iniciar o Projeto

Siga os passos abaixo para iniciar o ambiente completo com Docker Compose:

1. Clone este repositório:
   ```bash
   git clone [https://github.com/seu-usuario/desafio.git]
   cd desafio
2 . Construa o projeto
    ```bash
      docker-compose up --build 
