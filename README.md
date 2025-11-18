# Projeto Toolkit Sigma — AV1 + AV2
Disciplina: Computação Científica  
Professor: Prof. Dr. André Campos  
Alunos:
| Gabriel Guedes da Silva - 06004672
| Mauricio Grass de Bronstein - 06001816

# ProjetoToolkit — Aplicativo Console em C# (.NET 9)

## Descrição
Aplicativo console desenvolvido em **C# (.NET 9)** com um **menu unificado de módulos** para estudo e prática de linguagens formais, lógica proposicional, decidibilidade, reconhecimento e autômatos finitos.  
O programa recebe entradas via console e apresenta saídas textuais, com exemplos documentados na pasta `prints/`.

---

## Funcionalidades implementadas

### **--- AV1: FUNDAMENTOS PRÁTICOS ---**

### 1. Verificador de alfabeto e cadeia (Σ = {a, b})
- **Entrada**: símbolo e cadeia  
- **Saída**: `PERTENCE`/`NÃO PERTENCE` para símbolos e `VÁLIDA`/`INVÁLIDA` para cadeias  
- **Exemplos**:  
  - Válido → `prints/item1_valido.png`  
  - Inválido → `prints/item1_invalido.png`

---

### 2. Classificador T/I/N por JSON
- Lista de problemas embutida em JSON  
- Usuário responde `T` (tratável), `I` (intratável) ou `N` (não computável)  
- Mostra **acertos e erros** com percentual final  
- **Exemplos**:  
  - Respostas → `prints/item2_resposta.png`  
  - Resumo final → `prints/item2_resumo.png`

---

### 3. Programa de decisão — termina com 'b'?
- **Entrada**: cadeia sobre Σ = {a, b}  
- **Saída**: `SIM` ou `NAO`  
- Trata casos vazios e valida pré-condições  
- **Exemplos**:  
  - SIM → `prints/item3_sim.png`  
  - NAO → `prints/item3_nao.png`

---

### 4. Avaliador proposicional básico
- **Entradas**: valores de `P`, `Q`, `R`  
- **Fórmulas avaliadas**:  
  1. `P ∧ Q` (conjunção)  
  2. `P ∨ Q` (disjunção)  
  3. `P → Q` (implicação)  
  4. `(P ∧ Q) → R` (implicação composta)  
- Opção de imprimir **tabela-verdade completa**  
- **Exemplos**:  
  - Resultado com valores + tabela → `prints/item4_valores_tabela.png`  
  - Tabela-verdade completa → `prints/item4_tabela_completa.png`

---

### 5. Reconhecedor Σ = {a, b} — L_par_a e L = a b*
- **L_par_a**: cadeias com número **par de 'a'**  
- **L = a b\***: cadeias do tipo `a` seguido de zero ou mais `b`  
- **Saída**: `ACEITA` ou `REJEITA`  
- Validação do alfabeto antes da decisão  
- **Exemplos**:  
  - ACEITA → `prints/item5_aceita.png`  
  - REJEITA → `prints/item5_rejeita.png`

---

### **--- AV2: DECIDIBILIDADE E MODELOS ---**

### 6. Problema × Instância por JSON
- Classificar frases como **Problema (P)** ou **Instância (I)**  
- Lista com 8 itens embutida em JSON  
- Mostra acertos/erros e percentual final  
- **Exemplos**:  
  - Respostas → `prints/item6_resposta.png`  
  - Resumo final → `prints/item6_resumo.png`

---

### 7. Decidíveis: L_fim_b e L_mult3_b
- **L_fim_b**: decide se cadeia termina com 'b' (sempre termina)  
- **L_mult3_b**: decide se número de 'b's é múltiplo de 3 (sempre termina)  
- **Saída**: `SIM` ou `NAO`  
- **Exemplos**:  
  - L_fim_b → `prints/item7_l_fim_b_sim.png`  
  - L_mult3_b → `prints/item7_l_mult3_b_sim.png`

---

### 8. Reconhecível que pode não terminar
- **Linguagem**: L_prefixo_infinito = cadeias que são apenas 'a's  
- Simula reconhecedor que pode não finalizar  
- Limite de passos configurável pelo usuário  
- Registra quando execução é interrompida por limite  
- **Exemplos**:  
  - Aceita → `prints/item8_aceita.png`  
  - Limite atingido → `prints/item8_limite_atingido.png`

---

### 9. Detector ingênuo de loop + reflexão
- Executa processo discreto passo a passo (Collatz ou Decremento)  
- Detecta estados repetidos (possível loop)  
- Limite de passos configurável  
- **Reflexão completa** sobre falsos positivos/negativos ao final  
- **Exemplos**:  
  - Loop detectado → `prints/item9_loop_detectado.png`  
  - Reflexão → `prints/item9_reflexao.png`

---

### 10. Simulador de AFD
- AFD que reconhece cadeias terminando com **'ab'**  
- Estados: q0 (inicial), q1, q2 (final)  
- Mostra transições a cada símbolo consumido  
- **Saída**: `ACEITA` ou `REJEITA`  
- **Exemplos**:  
  - Aceita → `prints/item10_aceita.png`  
  - Rejeita → `prints/item10_rejeita.png`

---

## Como executar

### Pré-requisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/download) instalado  
  Verifique com:
  ```bash
  dotnet --version
```

### Executar pelo terminal
Na pasta do projeto, rode:
```bash
dotnet run
```

---

### Executar pelo Visual Studio Code
1. Abra a pasta do projeto no VS Code  
2. Instale a extensão **C# Dev Kit**  
3. Pressione **F5** (debug) ou **Ctrl+F5** (executar sem debug)  
4. Ou use o terminal integrado: `dotnet run`

---

## Estrutura do projeto
```
ProjetoToolkit/
├── Program.cs              # Código principal com todos os módulos (AV1 + AV2)
├── ProjetoToolkit.csproj   # Arquivo de configuração do projeto
├── README.md               # Este arquivo
└── prints/                 # Screenshots de exemplo (pasta a ser criada)
    ├── item1_valido.png
    ├── item1_invalido.png
    ├── item2_resposta.png
    ├── item2_resumo.png
    ├── item3_sim.png
    ├── item3_nao.png
    ├── item4_valores_tabela.png
    ├── item4_tabela_completa.png
    ├── item5_aceita.png
    ├── item5_rejeita.png
    ├── item6_resposta.png
    ├── item6_resumo.png
    ├── item7_l_fim_b_sim.png
    ├── item7_l_mult3_b_sim.png
    ├── item8_aceita.png
    ├── item8_limite_atingido.png
    ├── item9_loop_detectado.png
    ├── item9_reflexao.png
    ├── item10_aceita.png
    └── item10_rejeita.png
```

---

## Uso do programa
- Ao iniciar, o console apresenta um **menu unificado** com 10 módulos.  
- Basta digitar o número do módulo (1-10) e seguir as instruções na tela.  
- Digite `0` para sair do programa.  
- As saídas podem ser comparadas com os exemplos disponíveis na pasta `prints/`.

---

## Menu Principal
```
=== PROJETO TOOLKIT - MENU PRINCIPAL ===

--- AV1: FUNDAMENTOS PRÁTICOS ---
1. Verificador de Alfabeto e Cadeia
2. Classificador T/I/N por JSON
3. Programa de Decisão: 'Termina com b?'
4. Avaliador Proposicional Básico
5. Reconhecedor de Linguagens

--- AV2: DECIDIBILIDADE E MODELOS ---
6. Problema × Instância por JSON
7. Decidíveis: L_fim_b e L_mult3_b
8. Reconhecível que pode não terminar
9. Detector Ingênuo de Loop + Reflexão
10. Simulador de AFD

0. Sair

Escolha uma opção:
```

---

## Tecnologias utilizadas
- **C# (.NET 9)**: Linguagem principal
- **System.Text.Json**: Deserialização de dados JSON
- **Console Application**: Interface de linha de comando
- **Programação estruturada**: Organização em classes e métodos

---

## Prints de execução
Os exemplos de entrada/saída estão organizados na pasta [`prints/`](prints/).  
Eles mostram os resultados esperados para cada módulo implementado.
