# Etapa 1: Construção do projeto
FROM node:22.14 AS builder

WORKDIR /app

# Copia os arquivos do projeto para dentro do container
COPY package.json package-lock.json ./

# Instala as dependências do projeto
RUN npm install

# Copia o restante dos arquivos para o container
COPY . .

# Compila o projeto React
RUN npm run build

# Expor a porta 80
EXPOSE 80