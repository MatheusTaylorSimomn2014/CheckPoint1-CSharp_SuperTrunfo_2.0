# C Software Development

# Super Trunfo 2.0 (Prototótipo) -- Card Game Engine CSharp

Uma biblioteca genérica para modelagem de jogos de cartas, desenvolvida como parte do HandsOn 03 do Checkpoint 1 da matéria C Software Development.


## Nomes e RM do grupo
- Matheus Taylor, RM556211
- Henrique Maldonado, RM557270

## Uma Breve Descrição do Porjeto
A biblioteca fornece interfaces e classes base para construção de qualquer jogo de cartas, incluindo:
- Cartas (`ICard`, `Card`)
- Jogadores (`IPlayer<T>`, `Player<T>`)
- Baralho (`IDeck<T>`, `Deck<T>`)
- Rodadas (`IRound<T>`, `Round<T>`)
- Jogo (`IGame<T>`, `Game<T>`)
- Suporte a atributos comparáveis (`IAttributeCard<TValue>`)

## Como Usar
1. Referencie a `CardGameEngine` no seu projeto.
2. Crie suas próprias cartas implementando `ICard` ou herdando `Card`.
3. Se precisar de atributos, implemente `IAttributeCard<TValue>`.
4. Estenda `Game<T>` e `Round<T>` para implementar as regras do seu jogo.

## Exemplo: Super Trunfo
Veja no código as classes `SuperTrunfoCard`, `SuperTrunfoRound` e `SuperTrunfoGame` que implementam um jogo de comparação de atributos.

## Estrutura de Arquivos
- `CardGameEngine/`
  - `ICard.cs`
  - `Card.cs`
  - `IPlayer.cs`
  - `Player.cs`
  - `IDeck.cs`
  - `Deck.cs`
  - `IRound.cs`
  - `Round.cs`
  - `IGame.cs`
  - `Game.cs`
  - `IAttributeCard.cs`
  - (exemplos opcionais na pasta `Examplos/`)

## Requisitos
- .NET Standard 2.0 ou superior
- C# 8.0+
