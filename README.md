# Clyvo Day Api

## Descrição do Projeto

O **ClyvoDayApiDocker** é uma API REST desenvolvida em **C# com .NET**, criada para gerenciar informações relacionadas ao cuidado de animais de estimação.

A aplicação permite realizar operações de cadastro, consulta, atualização e exclusão de dados, utilizando persistência em banco de dados **Oracle**. O projeto foi conteinerizado com **Docker** e preparado para execução em uma **Máquina Virtual Linux na Microsoft Azure**.

O objetivo principal da entrega é demonstrar a aplicação de conceitos de **DevOps Tools e Cloud Computing**, utilizando Docker, Docker Compose, Azure CLI, GitHub e Oracle Database em ambiente de nuvem.

---

## Benefícios para o Negócio

A solução oferece benefícios como:

- Centralização das informações de tutores, animais, clínicas e veterinários;
- Melhor organização dos dados relacionados aos cuidados dos pets;
- Facilidade de consulta e atualização das informações;
- Persistência dos dados em banco Oracle;
- Possibilidade de execução em ambiente conteinerizado;
- Maior portabilidade da aplicação entre ambientes;
- Redução de problemas de configuração com uso de Docker;
- Preparação da solução para execução em nuvem;
- Facilidade de manutenção e evolução do sistema.

---

## Desenho Macro da Arquitetura

A arquitetura da solução é composta por uma aplicação API em .NET e um banco de dados Oracle, ambos executando em containers Docker dentro de uma Máquina Virtual Linux na Azure.

Fluxo macro:

```text
Usuário / Cliente HTTP
        |
        v
Internet
        |
        v
Azure Virtual Machine - Linux
        |
        v
Docker Engine
        |
        +-----------------------------+
        |                             |
        v                             v
Container API .NET             Container Oracle XE
Porta 8080                     Porta 1521
        |                             |
        +-------------> Volume Nomeado oracle-data

---
