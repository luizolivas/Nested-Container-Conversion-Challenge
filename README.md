

# Nested Container Conversion Challenge

Este repositório contém uma prática para desenvolver habilidades em manipulação de estruturas de dados complexas.

## Desafio

Este desafio consiste em duas tarefas principais:

1. **Função de Conversão para Array Unidimensional**: Escreva uma função que aceite um contêiner multidimensional de qualquer tamanho e o converta em um array associativo unidimensional. As chaves desse array unidimensional devem representar o caminho para o valor na estrutura original.

   **Exemplo:**

   Dado o seguinte contêiner:

```
{
    'one':
    {
        'two': 3,
        'four': [ 5,6,7]
    },
    'eight':
    {
        'nine':
        {
            'ten':11
        }
    }
}
```

A função deverá retornar:

```
{
    'one/two':3,
    'one/four/0':5,
    'one/four/1':6,
    'one/four/2':7,
    'eight/nine/ten':11
}
```

Função Reversa: Escreva uma segunda função que faça o processo reverso, convertendo o array associativo unidimensional de volta para uma estrutura multidimensional, recriando o contêiner original.


Dado o seguinte array associativo unidimensional:
```

{
    "one/two": 3,
    "one/four/0": 5,
    "one/four/1": 6,
    "one/four/2": 7,
    "eight/nine/ten": 11
}

```


A função deverá retornar:

```
{
    "one": {
        "two": 3,
        "four": [5, 6, 7]
    },
    "eight": {
        "nine": {
            "ten": 11
        }
    }
}
```

