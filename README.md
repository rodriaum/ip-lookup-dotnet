# IP Address Lookup

O **IP Address Lookup** é uma aplicação em Windows Forms que permite aos utilizadores consultar informações detalhadas sobre um endereço IP específico. Com esta ferramenta, pode obter dados como localização geográfica, informações da organização e muito mais.

![IP Address Lookup](https://i.imgur.com/ynqWWJf.png)

## Funcionalidades

- Procura informações detalhadas sobre um endereço IP, incluindo:
  - **ASN**:                  Sistema Autónomo do IP.
  - **Range**:                Intervalo de endereços IP.
  - **Hostname**:             Nome do host associado ao IP.
  - **Organização**:          Organização que possui o IP.
  - **Continente**:           Continente onde o IP está localizado.
  - **Código do Continente**: Código do continente (ex: NA para América do Norte).
  - **País**:                 País onde o IP está localizado.
  - **Código ISO**:           Código ISO do país.
  - **Região**:               Região onde o IP está localizado.
  - **Código da Região**:     Código da região.
  - **Fuso Horário**:         Fuso horário associado ao IP.
  - **Cidade**:               Cidade onde o IP está localizado.
  - **Código Postal**:        Código postal da localização.
  - **Latitude**:             Latitude da localização do IP.
  - **Longitude**:            Longitude da localização do IP.
  - **Moeda**:                Informações sobre a moeda da região.
  - **Proxy**:                Indica se o IP é um proxy.
  - **Tipo**:                 Tipo de IP (ex: IPv4, IPv6).

## Como Usar

1. Clone o repositório:
   ```bash
   git clone https://github.com/rodriaum/IP-Address-Lookup.git
2. Abra a solução no Visual Studio.
3. Compile e execute a aplicação.
4. Insira o endereço IP que deseja consultar na interface da aplicação e pressione o botão para obter as informações.

## Variáveis Secretas
Este projeto utiliza variáveis de ambiente para armazenar credenciais sensíveis. Certifique-se de definir corretamente essas variáveis antes de executar o sistema.

No Linux/macOS (bash/zsh)
```shell
export PROXY_CHECK_API_KEY="your_token"
```

No Windows (PowerShell)
```shell
$env:PROXY_CHECK_API_KEY="your_token"
```

## Licença

Este projeto é licenciado sob a [MIT License](https://github.com/rodriaum/IP-Address-Lookup?tab=MIT-1-ov-file#MIT-1-ov-file).