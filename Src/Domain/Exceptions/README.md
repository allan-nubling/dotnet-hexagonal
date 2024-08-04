# Exceptions

## Objetivo:
- Fazer nosso domínio lançar apenas exceções conhecidas de modo que o nosso filtro/middleware
tenha um numero limitado de bases de exceções que ele precisa tratar

- O nosso filtro/middleware deveria olhar apenas sempre as bases, esse filtro é responsável
apenas em transformar as exceções do domino em erros do tipo REST com a resposta no formato JSON

- Olhando as extensões de exceções deve ser possível montar uma tabela com todas as exceções que o
nosso domínio pode vir a lançar e com isso mapear todas conhecidas por nós e permitir que os
sistemas que conectem na nossa API consigam tratar corretamente (sabendo que vão ter exceções 
desconhecidas e não tratadas, isso faz parte.)

- Nunca podemos lançar apena a base da exceções porque isso vai tonar mais difícil mapear e 
separar qual é o problema que está acontecendo e realizar o tratamento correto.

## Exemplos: 
Bases (Classes abstratas, genéricas) - Status Code:
- DomainException - HTTP 400
- AdaptersExceptions | ExternalProvidersExceptions - HTTP 502
- InternalException - HTTP 500
- ForbiddenAccessException - HTTP 403
    
Extensões de Exceções (implementações concretas)
- BiometryQualityException :DomainException
- ProcessExpiredException :DomainException
- AnyDomainException :DomainException
- ProviderException :AdaptersExceptions
- ...

Response Esperada em JSON:
```json
{
  "Module": "string", // Classe/módulo que a exceção foi lançada
  "Error": "string", // Mome do erro, exemplo "ProcessExpiredException"
  "Message": "string", // Mensagem que descreva o erro EM PORTUGUÊS
  "Code": "string" // Código unico, um ENUM onde separe melhor erros semelhantes. Casos que temos BiometryQualityException pode ter os seguintes códigos "UN500", "BR500"
}
```
