# Olá Mundo

Protótipo de plataforma 2D feito em Unity 6 e C#, com foco total em programação de mecânicas.

![Gameplay](docs/gameplay.gif)

## Como jogar

- **Andar:** A e D
- **Pular / pulo duplo:** Espaço
- **Pausar:** Esc (o painel tem as opções Continuar e Voltar ao Menu)
- **Derrotar inimigos:** pulando na cabeça deles

## Como rodar o projeto

1. Instalar o Unity **6000.5.7f1** pelo Unity Hub.
2. Abrir esta pasta como projeto.
3. Abrir a cena `Menu` e dar Play.

## Mecânicas que eu programei

- Movimento com pulo duplo e checagem de chão robusta (`OverlapCircle` + velocidade vertical)
- Sistema de vida e dano
- Três tipos de inimigo: patrulha, parado e perseguidor
- Checkpoint e respawn
- Plataforma móvel e zona de morte
- Moedas: normal, grande e móvel
- Porta aberta por botão
- HUD de vida e moedas atualizado por eventos
- Animator controlado por código (Idle, Andando, Pulando e Caindo), flip do sprite e efeito de achatar ao pousar
- Pausa, menu inicial, tela de vitória e troca de fases (3 fases)

## Decisões de código

**Respawn inicial no `Start` do `PlayerVida`.** A posição de respawn é uma variável `static` que só ganhava valor ao tocar num checkpoint. Se o jogador morresse antes do primeiro, ele voltava para `(0, 0, 0)`, que pode estar fora da fase. Agora o `Start` grava a posição inicial do Player como respawn.

**`OnDestroy` para desligar o input.** Ao trocar de fase, o objeto de controles do Player antigo continuava ativo e chamava um método de um objeto já destruído, gerando `MissingReferenceException`. O `OnDestroy` remove a inscrição no evento e desativa os controles.

**`Time.timeScale` como fonte única do estado de pausa.** O script decide entre pausar e continuar lendo o `Time.timeScale`, em vez de manter uma variável `bool` separada. Assim não há duas informações que possam ficar fora de sincronia. Também corrigi um bug em que o pulo apertado durante a pausa era aplicado ao continuar, juntando a checagem de pausa à condição do pulo.

## Limitações conhecidas

O evento do botão é `static`, então qualquer botão abre todas as portas. Como cada fase tem só um par botão/porta, isso não afeta o jogo. Para ter vários pares, eu precisaria identificar qual botão abre qual porta.

Não há sons, e os gráficos são placeholder: o foco foi a lógica.

## Sobre o desenvolvimento

Desenvolvido durante meu aprendizado, com o Claude (IA) como professor: ele explicava os conceitos e revisava, e eu escrevi a lógica das mecânicas.

## Sobre mim

Estudante de Ciência da Computação (5º período), focado em programação de jogos, aberto a oportunidades na área. Contato: judocaweverton7@gmail.com