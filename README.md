# 5by5 - Ingestão dados de Radares

Projeto desenvolvido individualmente como parte do treinamento do estágio

## Funcionalidades do sistema:

- Modulo 1:
  - Leitura de dados através de arquivo json (<a href="https://dados.antt.gov.br/dataset/79d287f4-f5ca-4385-a17c-f61f53831f17/resource/fa861690-70de-4a27-a82f-0eee74abdbc0/download/dados_dos_radares.json" >Disponível Aqui</a>)
  - Inserção desses dados em um banco de dados SQL SERVER
- Modulo 2:
  - Leitura dos dados através do banco de dados SQL SERVER
  - Inserção desses dados no banco de dados Mongo
- Modulo 3:
  - Geração de relatórios do tipo: .csv, .json, .XML
  - A fonte dos dados pode ser recuperada tanto do SQL SERVER quanto do MongoDB

## Padrões de projeto utilizados:

- Singleton: O sistema utiliza o padrão de projeto Singleton para criar um objeto de conexão com o SQL SERVER;
- Strategy: O sistema utiliza o padrão Strategy para fazer inserir dependências no ReadController, as dependências são classes concretas que implementam a interface IDatabaseRepository.

## Enunciado: 
![image](https://github.com/edenilsonjunior/5by5-IngestaoRadar/assets/110670578/91e2ffa4-d6c1-4d04-80bd-d62f8a68f87e)
