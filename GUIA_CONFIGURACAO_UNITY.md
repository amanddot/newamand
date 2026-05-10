# 🎮 GUIA COMPLETO DE CONFIGURAÇÃO - JOGO DA LIXEIRA

## ESTRUTURA DO PROJETO (Hierarquia)

```
SampleScene (ou sua cena)
├── Main Camera
├── Directional Light
├── Canvas
│   ├── TextoPontos (TextMeshPro)
│   └── TextoVitória (TextMeshPro)
├── Lixeira (cilindro)
├── LixoSpawner (objeto vazio)
├── Chao (cubo)
└── MusicaAmbiente (objeto vazio com Audio Source)
```

---

## PASSO 1: CONFIGURAR A LIXEIRA (Cilindro)

### O que é:
- O **cilindro** que o jogador controla com setas do teclado
- Precisa ter 2 scripts: `lixocontrole` e `AddPoints`
- Precisa ter `Audio Source` para tocar som

### Como fazer:

**A. Clique no cilindro na Hierarquia**

**B. Na aba do Inspector, você verá os componentes:**
```
[✓] Mesh Renderer
[✓] Mesh Filter
[✓] Capsule Collider (ou Cylinder Collider)
[✓] lixocontrole (Script)
[✓] AddPoints (Script)
[✓] Audio Source
```

**C. Configure cada script:**

#### **Script "lixocontrole":**
- **Velocity**: `10` (velocidade que a lixeira se move)
  - Quanto maior, mais rápido se move
  - Teste valores entre 5 e 15

#### **Script "AddPoints":**

| Campo | O que fazer |
|-------|------------|
| **Lixo Spawner Controller** | Arraste da Hierarquia o objeto "LixoSpawner" |
| **Source** | Arraste a própria Lixeira (ela mesma tem Audio Source) |

**Como arrastar:**
1. Clique no campo vazio do lado de "Lixo Spawner Controller"
2. Na Hierarquia, procure e arraste "LixoSpawner"
3. Solte no campo
4. Repita para "Source" (arraste a Lixeira novamente)

#### **Audio Source:**
- ✅ **Audio Clip**: Arraste um arquivo de som da pasta `Assets/AudioAssets/Sons/`
- ✅ **Loop**: DESATIVADO (❌ não marque)
- ✅ **Play On Awake**: DESATIVADO (❌ não marque)
- Volume: entre 0.5 e 1

---

## PASSO 2: CONFIGURAR O LIXOSPAWNER (Objeto Vazio)

### O que é:
- Objeto invisível que **GERA LIXO** durante o jogo
- Tem apenas o script `LixoSpawnerController`
- **Mais importante:** aqui ficam TODAS as referências de pontuação e vitória

### Como fazer:

**A. Clique em "LixoSpawner" na Hierarquia**

**B. Na aba do Inspector:**

#### **Script "LixoSpawnerController":**

| Campo | Tipo | O que colocar | Explicação |
|-------|------|---------------|-----------|
| **Maximum X** | float | `9` | Limite lateral esquerda/direita (onde lixo pode aparecer) |
| **Fixed Y** | float | `8` | Altura onde lixo aparece (cai de cima) |
| **Fixed Z** | float | `0` | Profundidade (mantém igual) |
| **Timer** | float | `2` | Tempo (em segundos) entre aparecer cada lixo |
| **Lixo** | GameObject | Arraste o prefab | Na pasta Assets → procure "Lixo" azul |
| **Max Points** | int | `10` | Quantos pontos para ganhar o jogo |
| **Points** | int | `0` | Deixe como está (começa em 0) |
| **Points Text** | TMP_Text | Arraste do Canvas | Procure "TextoPontos" no Canvas |
| **Victory Text** | TMP_Text | Arraste do Canvas | Procure "TextoVitória" no Canvas |

### ⚠️ IMPORTANTE - COMO ARRASTAR O PREFAB:

1. Na pasta **Assets**, procure por um ícone **azul** chamado "Lixo"
   ```
   Assets
   ├── Lixo (ícone azul - ESTE!)
   ├── AddPoints.cs
   ├── destroylixo.cs
   └── ...
   ```
2. **Arraste esse ícone azul** para o campo "Lixo" no Inspector

### 📝 Exemplo visual de como ficar preenchido:

```
Maximum X: 9
Fixed Y: 8
Fixed Z: 0
Timer: 2
Lixo: [Lixo] (o prefab azul)
Max Points: 10
Points: 0
Points Text: [TextoPontos] (do Canvas)
Victory Text: [TextoVitória] (do Canvas)
```

---

## PASSO 3: CONFIGURAR O CHÃO (Cubo)

### O que é:
- O **cubo** onde o lixo cai
- Se lixo cair aqui, **PERDE PONTOS**
- Tem script `destroylixo`

### Como fazer:

**A. Clique no cubo na Hierarquia**

**B. Na aba do Inspector:**

#### **Script "destroylixo":**

| Campo | O que fazer |
|-------|------------|
| **Lixo Spawner Controller** | Arraste "LixoSpawner" da Hierarquia |

**Exemplo:**
```
destroylixo
├── Lixo Spawner Controller: [LixoSpawner] ✓
```

---

## PASSO 4: CONFIGURAR O CANVAS (UI)

### O que é:
- Tela que mostra **Pontos** e **Mensagem de Vitória**
- Precisa ter 2 TextMeshPro

### Como fazer:

**A. Clique em "Canvas" na Hierarquia**

**B. Procure por dois textos dentro dele:**
- "TextoPontos" (ou parecido)
- "TextoVitória" (ou "VocêVenceu")

**C. Configure cada um:**

#### **TextoPontos** (mostra pontos):
- Texto inicial: `Pontos: 0`
- Tamanho fonte: `60`
- Posição: canto superior esquerdo
- Cor: Branca

#### **TextoVitória** (mensagem final):
- Texto: `Você venceu!!!!`
- Tamanho fonte: `80`
- Cor: Verde ou dourada
- **IMPORTANTE:** Desative o objeto (marque ❌ ao lado do nome)
  - Vai ativar automaticamente quando ganhar

---

## PASSO 5: CONFIGURAR TAGS

### O que são Tags:
- Marcadores que identificam objetos no jogo
- Usadas para saber quando algo é "Lixo"

### Como fazer:

**A. Clique no prefab "Lixo" (ícone azul na pasta Assets)**

**B. No Inspector, procure "Tag" (perto do topo)**

**C. Clique na dropdown e procure "Lixo"**

Se não existir:
1. Clique em "Add Tag"
2. Clique no "+"
3. Digite "Lixo"
4. Volta e atribui ao prefab

---

## PASSO 6: CONFIGURAR ÁUDIO

### O que é:
- Som que toca quando pega lixo
- Música ambiente (opcional)

### Como fazer:

#### **Na Lixeira (som de pegar):**
1. Clique na Lixeira
2. Clique em botão "Add Component" (lá embaixo)
3. Digite "Audio Source"
4. Clique para adicionar
5. Arraste um arquivo `.mp3` ou `.wav` de `Assets/AudioAssets/Sons/`
6. **Loop**: ❌ Desativado
7. **Play On Awake**: ❌ Desativado

#### **Música Ambiente (opcional):**
1. Crie objeto vazio chamado "MusicaAmbiente"
2. Adicione **Audio Source**
3. Arraste um arquivo `.mp3` de música
4. **Loop**: ✅ **ATIVADO** (música toca sempre)
5. **Play On Awake**: ✅ **ATIVADO** (começa quando jogo inicia)
6. **Volume**: `0.3` ou `0.5` (mais baixo que som de pegar)

---

## RESUMO RÁPIDO

### ✅ Checklist de Configuração:

- [ ] **Lixeira (cilindro)**
  - [ ] Script `lixocontrole` com Velocity = 10
  - [ ] Script `AddPoints` com LixoSpawner e AudioSource apontados
  - [ ] Componente `Audio Source` com som

- [ ] **LixoSpawner (objeto vazio)**
  - [ ] Script `LixoSpawnerController` totalmente preenchido
  - [ ] Maximum X = 9, Fixed Y = 8, Fixed Z = 0
  - [ ] Timer = 2, Max Points = 10
  - [ ] Lixo, Points Text e Victory Text apontados

- [ ] **Chão (cubo)**
  - [ ] Script `destroylixo` com LixoSpawner apontado
  - [ ] Tem Collider

- [ ] **Canvas**
  - [ ] TextoPontos visível (mostra "Pontos: 0")
  - [ ] TextoVitória desativado (vai ativar ao ganhar)

- [ ] **Tags**
  - [ ] Prefab Lixo tem Tag "Lixo"

- [ ] **Áudio**
  - [ ] Lixeira tem Audio Source com som
  - [ ] (Opcional) MusicaAmbiente criado

---

## TESTANDO

Quando tudo estiver configurado:

1. Pressione **Play** (botão de play do Unity)
2. Use **setas do teclado** para mover a lixeira
3. Pegue o lixo que cai (pontos aumentam)
4. Se lixo cair no chão (pontos diminuem)
5. Quando atingir 10 pontos → mensagem "Você venceu!" aparece

---

## POSSÍVEIS ERROS E SOLUÇÕES

### ❌ "Não aparece lixo"
- Verifique se `Lixo` está apontando para o prefab azul correto
- Verifique se `Max Points` não está zerado

### ❌ "Pontos não aparecem"
- Verifique se `Points Text` está apontando para TextoPontos
- Verifique se TextoPontos existe no Canvas

### ❌ "Sem som"
- Verifique se `Audio Source` na Lixeira tem um arquivo de som
- Verifique se `source` em AddPoints aponta para a Lixeira

### ❌ "Lixeira não se move"
- Verifique se `Velocity` em `lixocontrole` está > 0
- Verifique se tem Collider no cilindro

### ❌ "Mensagem de vitória não aparece"
- Verifique se `Victory Text` está apontando para TextoVitória
- Verifique se TextoVitória **começa desativado** (marque a caixinha)
