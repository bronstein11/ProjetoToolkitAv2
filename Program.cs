using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace ProjetoToolkit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Executar();
        }
    }

    public class MenuPrincipal
    {
        public void Executar()
        {
            bool continuar = true;
            
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== PROJETO TOOLKIT - MENU PRINCIPAL ===");
                Console.WriteLine();
                Console.WriteLine("--- AV1: FUNDAMENTOS PRÁTICOS ---");
                Console.WriteLine("1. Verificador de Alfabeto e Cadeia");
                Console.WriteLine("2. Classificador T/I/N por JSON");
                Console.WriteLine("3. Programa de Decisão: 'Termina com b?'");
                Console.WriteLine("4. Avaliador Proposicional Básico");
                Console.WriteLine("5. Reconhecedor de Linguagens");
                Console.WriteLine();
                Console.WriteLine("--- AV2: DECIDIBILIDADE E MODELOS ---");
                Console.WriteLine("6. Problema × Instância por JSON");
                Console.WriteLine("7. Decidíveis: L_fim_b e L_mult3_b");
                Console.WriteLine("8. Reconhecível que pode não terminar");
                Console.WriteLine("9. Detector Ingênuo de Loop + Reflexão");
                Console.WriteLine("10. Simulador de AFD");
                Console.WriteLine();
                Console.WriteLine("0. Sair");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    // AV1
                    case "1":
                        new VerificadorAlfabeto().Executar();
                        break;
                    case "2":
                        new ClassificadorTIN().Executar();
                        break;
                    case "3":
                        new DecidirTerminaComB().Executar();
                        break;
                    case "4":
                        new AvaliadorProposicional().Executar();
                        break;
                    case "5":
                        new ReconhecedorLinguagens().Executar();
                        break;
                    // AV2
                    case "6":
                        new ProblemaInstancia().Executar();
                        break;
                    case "7":
                        new DecisoresAdicionais().Executar();
                        break;
                    case "8":
                        new ReconhecedorNaoTerminante().Executar();
                        break;
                    case "9":
                        new DetectorLoop().Executar();
                        break;
                    case "10":
                        new SimuladorAFD().Executar();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    // ==================== AV1 ====================

    // ITEM 1: Verificador de Alfabeto e Cadeia
    public class VerificadorAlfabeto
    {
        private readonly HashSet<char> alfabeto = new HashSet<char> { 'a', 'b' };

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 1: VERIFICADOR DE ALFABETO E CADEIA ===");
            Console.WriteLine("Alfabeto Σ = {a, b}");
            Console.WriteLine();

            Console.Write("Digite um símbolo para verificar: ");
            string? entrada = Console.ReadLine();
            
            if (string.IsNullOrEmpty(entrada) || entrada.Length != 1)
            {
                Console.WriteLine("Entrada inválida! Digite apenas um símbolo.");
            }
            else
            {
                char simbolo = entrada[0];
                bool pertenceAlfabeto = VerificarSimbolo(simbolo);
                Console.WriteLine($"Símbolo '{simbolo}' {(pertenceAlfabeto ? "PERTENCE" : "NÃO PERTENCE")} ao alfabeto Σ");
            }

            Console.WriteLine();

            Console.Write("Digite uma cadeia para verificar: ");
            string? cadeia = Console.ReadLine() ?? "";
            
            bool cadeiaValida = VerificarCadeia(cadeia);
            Console.WriteLine($"Cadeia '{cadeia}' é {(cadeiaValida ? "VÁLIDA" : "INVÁLIDA")} para Σ*");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool VerificarSimbolo(char simbolo)
        {
            return alfabeto.Contains(simbolo);
        }

        private bool VerificarCadeia(string cadeia)
        {
            return cadeia.All(c => alfabeto.Contains(c));
        }
    }

    // ITEM 2: Classificador T/I/N por JSON
    public class ClassificadorTIN
    {
        private readonly List<ProblemaComputacional> problemas;

        public ClassificadorTIN()
        {
            string jsonProblemas = """
            [
                {
                    "nome": "Ordenação de lista",
                    "descricao": "Ordenar uma lista de números em ordem crescente",
                    "classificacao": "T"
                },
                {
                    "nome": "Problema do Caixeiro Viajante",
                    "descricao": "Encontrar o menor caminho que visita todas as cidades",
                    "classificacao": "I"
                },
                {
                    "nome": "Problema da Parada",
                    "descricao": "Determinar se um programa irá parar para uma entrada",
                    "classificacao": "N"
                },
                {
                    "nome": "Busca em array",
                    "descricao": "Encontrar um elemento específico em um array",
                    "classificacao": "T"
                },
                {
                    "nome": "Satisfatibilidade Booleana (SAT)",
                    "descricao": "Determinar se uma fórmula booleana pode ser satisfeita",
                    "classificacao": "I"
                },
                {
                    "nome": "Problema da Correspondência de Post",
                    "descricao": "Encontrar sequência que produz mesma string em dois conjuntos",
                    "classificacao": "N"
                }
            ]
            """;

            problemas = JsonSerializer.Deserialize<List<ProblemaComputacional>>(jsonProblemas) 
                       ?? new List<ProblemaComputacional>();
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 2: CLASSIFICADOR T/I/N POR JSON ===");
            Console.WriteLine("Classifique cada problema como:");
            Console.WriteLine("T - Tratável | I - Intratável | N - Não Computável");
            Console.WriteLine();

            int acertos = 0;
            int total = problemas.Count;

            foreach (ProblemaComputacional problema in problemas)
            {
                Console.WriteLine($"Problema: {problema.Nome}");
                Console.WriteLine($"Descrição: {problema.Descricao}");
                Console.Write("Sua classificação (T/I/N): ");
                
                string? resposta = Console.ReadLine()?.ToUpper();
                
                if (resposta == problema.Classificacao)
                {
                    Console.WriteLine("✓ CORRETO!");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"✗ INCORRETO! Resposta correta: {problema.Classificacao}");
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("=== RESUMO FINAL ===");
            Console.WriteLine($"Acertos: {acertos}/{total}");
            Console.WriteLine($"Percentual: {(double)acertos / total * 100:F1}%");
            
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }

    public class ProblemaComputacional
    {
        public string nome { get; set; } = "";
        public string descricao { get; set; } = "";
        public string classificacao { get; set; } = "";
        
        public string Nome => nome;
        public string Descricao => descricao;  
        public string Classificacao => classificacao;
    }

    // ITEM 3: Programa de Decisão - Termina com 'b'?
    public class DecidirTerminaComB
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 3: PROGRAMA DE DECISÃO - 'TERMINA COM B?' ===");
            Console.WriteLine("Verifica se uma cadeia sobre Σ = {a, b} termina com 'b'");
            Console.WriteLine();

            Console.Write("Digite uma cadeia: ");
            string? cadeia = Console.ReadLine() ?? "";

            if (!ValidarAlfabeto(cadeia))
            {
                Console.WriteLine("ERRO: Cadeia contém símbolos não pertencentes ao alfabeto Σ = {a, b}");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            string resultado = DecidirTerminaComB_Funcao(cadeia);
            Console.WriteLine($"Resultado: {resultado}");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool ValidarAlfabeto(string cadeia)
        {
            HashSet<char> alfabeto = new HashSet<char> { 'a', 'b' };
            return cadeia.All(c => alfabeto.Contains(c));
        }

        private string DecidirTerminaComB_Funcao(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                return "NAO";
            }

            return cadeia[cadeia.Length - 1] == 'b' ? "SIM" : "NAO";
        }
    }

    // ITEM 4: Avaliador Proposicional Básico
    public class AvaliadorProposicional
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 4: AVALIADOR PROPOSICIONAL BÁSICO ===");
            Console.WriteLine();

            bool continuar = true;
            
            while (continuar)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Avaliar fórmula com valores específicos");
                Console.WriteLine("2. Gerar tabela-verdade completa");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.Write("Opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AvaliarComValores();
                        break;
                    case "2":
                        GerarTabelaVerdade();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void AvaliarComValores()
        {
            Console.WriteLine();
            Console.WriteLine("Digite os valores das proposições:");
            
            Console.Write("P (true/false): ");
            bool P = LerBooleano();
            
            Console.Write("Q (true/false): ");
            bool Q = LerBooleano();
            
            Console.Write("R (true/false): ");
            bool R = LerBooleano();

            Console.WriteLine();
            Console.WriteLine("Escolha uma fórmula:");
            Console.WriteLine("1. P ∧ Q (conjunção)");
            Console.WriteLine("2. P ∨ Q (disjunção)");
            Console.WriteLine("3. P → Q (implicação)");
            Console.WriteLine("4. (P ∧ Q) → R (implicação composta)");
            Console.Write("Fórmula: ");

            string? escolha = Console.ReadLine();
            bool resultado = false;
            string formula = "";

            switch (escolha)
            {
                case "1":
                    resultado = P && Q;
                    formula = "P ∧ Q";
                    break;
                case "2":
                    resultado = P || Q;
                    formula = "P ∨ Q";
                    break;
                case "3":
                    resultado = !P || Q;
                    formula = "P → Q";
                    break;
                case "4":
                    resultado = !(P && Q) || R;
                    formula = "(P ∧ Q) → R";
                    break;
                default:
                    Console.WriteLine("Fórmula inválida!");
                    return;
            }

            Console.WriteLine();
            Console.WriteLine($"Fórmula: {formula}");
            Console.WriteLine($"P = {P}, Q = {Q}, R = {R}");
            Console.WriteLine($"Resultado: {resultado}");
            Console.WriteLine();
        }

        private void GerarTabelaVerdade()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha uma fórmula para gerar tabela-verdade:");
            Console.WriteLine("1. P ∧ Q");
            Console.WriteLine("2. P ∨ Q");
            Console.WriteLine("3. P → Q");
            Console.WriteLine("4. (P ∧ Q) → R");
            Console.Write("Fórmula: ");

            string? escolha = Console.ReadLine();
            
            Console.WriteLine();

            switch (escolha)
            {
                case "1":
                    GerarTabelaConjuncao();
                    break;
                case "2":
                    GerarTabelaDisjuncao();
                    break;
                case "3":
                    GerarTabelaImplicacao();
                    break;
                case "4":
                    GerarTabelaImplicacaoComposta();
                    break;
                default:
                    Console.WriteLine("Fórmula inválida!");
                    return;
            }
            
            Console.WriteLine();
        }

        private void GerarTabelaConjuncao()
        {
            Console.WriteLine("Tabela-verdade para P ∧ Q:");
            Console.WriteLine("P\tQ\tP∧Q");
            Console.WriteLine("T\tT\t" + (true && true ? "T" : "F"));
            Console.WriteLine("T\tF\t" + (true && false ? "T" : "F"));
            Console.WriteLine("F\tT\t" + (false && true ? "T" : "F"));
            Console.WriteLine("F\tF\t" + (false && false ? "T" : "F"));
        }

        private void GerarTabelaDisjuncao()
        {
            Console.WriteLine("Tabela-verdade para P ∨ Q:");
            Console.WriteLine("P\tQ\tP∨Q");
            Console.WriteLine("T\tT\t" + (true || true ? "T" : "F"));
            Console.WriteLine("T\tF\t" + (true || false ? "T" : "F"));
            Console.WriteLine("F\tT\t" + (false || true ? "T" : "F"));
            Console.WriteLine("F\tF\t" + (false || false ? "T" : "F"));
        }

        private void GerarTabelaImplicacao()
        {
            Console.WriteLine("Tabela-verdade para P → Q:");
            Console.WriteLine("P\tQ\tP→Q");
            Console.WriteLine("T\tT\t" + (!true || true ? "T" : "F"));
            Console.WriteLine("T\tF\t" + (!true || false ? "T" : "F"));
            Console.WriteLine("F\tT\t" + (!false || true ? "T" : "F"));
            Console.WriteLine("F\tF\t" + (!false || false ? "T" : "F"));
        }

        private void GerarTabelaImplicacaoComposta()
        {
            Console.WriteLine("Tabela-verdade para (P ∧ Q) → R:");
            Console.WriteLine("P\tQ\tR\tP∧Q\t(P∧Q)→R");
            
            bool[] valores = { true, false };
            
            foreach (bool p in valores)
            {
                foreach (bool q in valores)
                {
                    foreach (bool r in valores)
                    {
                        bool conjuncao = p && q;
                        bool implicacao = !conjuncao || r;
                        Console.WriteLine($"{(p ? "T" : "F")}\t{(q ? "T" : "F")}\t{(r ? "T" : "F")}\t{(conjuncao ? "T" : "F")}\t{(implicacao ? "T" : "F")}");
                    }
                }
            }
        }

        private bool LerBooleano()
        {
            string? input = Console.ReadLine()?.ToLower();
            return input == "true" || input == "t" || input == "1";
        }
    }

    // ITEM 5: Reconhecedor de Linguagens
    public class ReconhecedorLinguagens
    {
        private readonly HashSet<char> alfabeto = new HashSet<char> { 'a', 'b' };

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 5: RECONHECEDOR DE LINGUAGENS ===");
            Console.WriteLine("Alfabeto Σ = {a, b}");
            Console.WriteLine();

            Console.WriteLine("Escolha uma linguagem:");
            Console.WriteLine("1. L_par_a = {w | w tem número par de 'a's}");
            Console.WriteLine("2. L = {w | w = ab*} (inicia com 'a' seguido de zero ou mais 'b's)");
            Console.Write("Opção: ");

            string? opcao = Console.ReadLine();
            
            Console.Write("Digite a cadeia para verificar: ");
            string? cadeia = Console.ReadLine() ?? "";

            if (!ValidarAlfabeto(cadeia))
            {
                Console.WriteLine("REJEITA - Cadeia contém símbolos não pertencentes ao alfabeto Σ");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            string resultado = "";

            switch (opcao)
            {
                case "1":
                    resultado = ReconhecerL_par_a(cadeia);
                    Console.WriteLine($"L_par_a: {resultado}");
                    break;
                case "2":
                    resultado = ReconhecerL_ab_estrela(cadeia);
                    Console.WriteLine($"L = ab*: {resultado}");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool ValidarAlfabeto(string cadeia)
        {
            return cadeia.All(c => alfabeto.Contains(c));
        }

        private string ReconhecerL_par_a(string cadeia)
        {
            int contadorA = cadeia.Count(c => c == 'a');
            return contadorA % 2 == 0 ? "ACEITA" : "REJEITA";
        }

        private string ReconhecerL_ab_estrela(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                return "REJEITA";
            }

            if (cadeia[0] != 'a')
            {
                return "REJEITA";
            }

            for (int i = 1; i < cadeia.Length; i++)
            {
                if (cadeia[i] != 'b')
                {
                    return "REJEITA";
                }
            }

            return "ACEITA";
        }
    }

    // ==================== AV2 ====================

    // ITEM 6 (AV2-1): Problema × Instância por JSON
    public class ProblemaInstancia
    {
        private readonly List<ItemProblemaInstancia> itens;

        public ProblemaInstancia()
        {
            string jsonItens = """
            [
                {
                    "texto": "Encontrar o maior elemento de uma lista",
                    "tipo": "P"
                },
                {
                    "texto": "Encontrar o maior elemento da lista [5, 2, 9, 1]",
                    "tipo": "I"
                },
                {
                    "texto": "Verificar se um número é primo",
                    "tipo": "P"
                },
                {
                    "texto": "Verificar se 17 é primo",
                    "tipo": "I"
                },
                {
                    "texto": "Ordenar uma lista de números",
                    "tipo": "P"
                },
                {
                    "texto": "Ordenar a lista [3, 1, 4, 1, 5, 9, 2, 6]",
                    "tipo": "I"
                },
                {
                    "texto": "Calcular o fatorial de um número",
                    "tipo": "P"
                },
                {
                    "texto": "Calcular o fatorial de 5",
                    "tipo": "I"
                }
            ]
            """;

            itens = JsonSerializer.Deserialize<List<ItemProblemaInstancia>>(jsonItens)
                   ?? new List<ItemProblemaInstancia>();
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 6 (AV2-1): PROBLEMA × INSTÂNCIA POR JSON ===");
            Console.WriteLine("Classifique cada item como:");
            Console.WriteLine("P - Problema (descrição geral) | I - Instância (caso específico)");
            Console.WriteLine();

            int acertos = 0;
            int total = itens.Count;

            foreach (ItemProblemaInstancia item in itens)
            {
                Console.WriteLine($"Texto: {item.Texto}");
                Console.Write("Sua classificação (P/I): ");
                
                string? resposta = Console.ReadLine()?.ToUpper();
                
                if (resposta == item.Tipo)
                {
                    Console.WriteLine("✓ CORRETO!");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"✗ INCORRETO! Resposta correta: {item.Tipo}");
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("=== RESUMO FINAL ===");
            Console.WriteLine($"Acertos: {acertos}/{total}");
            Console.WriteLine($"Percentual: {(double)acertos / total * 100:F1}%");
            
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }

    public class ItemProblemaInstancia
    {
        public string texto { get; set; } = "";
        public string tipo { get; set; } = "";
        
        public string Texto => texto;
        public string Tipo => tipo;
    }

    // ITEM 7 (AV2-2): Decidíveis - L_fim_b e L_mult3_b
    public class DecisoresAdicionais
    {
        private readonly HashSet<char> alfabeto = new HashSet<char> { 'a', 'b' };

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 7 (AV2-2): DECIDÍVEIS - L_FIM_B E L_MULT3_B ===");
            Console.WriteLine("Alfabeto Σ = {a, b}");
            Console.WriteLine();

            Console.WriteLine("Escolha um decisor:");
            Console.WriteLine("1. L_fim_b = {w | w termina com 'b'}");
            Console.WriteLine("2. L_mult3_b = {w | número de 'b's é múltiplo de 3}");
            Console.Write("Opção: ");

            string? opcao = Console.ReadLine();
            
            Console.Write("Digite a cadeia: ");
            string? cadeia = Console.ReadLine() ?? "";

            if (!ValidarAlfabeto(cadeia))
            {
                Console.WriteLine("ERRO: Cadeia contém símbolos fora do alfabeto Σ");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            string resultado = "";

            switch (opcao)
            {
                case "1":
                    resultado = DecidirL_fim_b(cadeia);
                    Console.WriteLine($"\nL_fim_b: {resultado}");
                    break;
                case "2":
                    resultado = DecidirL_mult3_b(cadeia);
                    Console.WriteLine($"\nL_mult3_b: {resultado}");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool ValidarAlfabeto(string cadeia)
        {
            return cadeia.All(c => alfabeto.Contains(c));
        }

        private string DecidirL_fim_b(string cadeia)
        {
            // Sempre termina e decide
            if (string.IsNullOrEmpty(cadeia))
            {
                return "NAO";
            }

            return cadeia[cadeia.Length - 1] == 'b' ? "SIM" : "NAO";
        }

        private string DecidirL_mult3_b(string cadeia)
        {
            // Sempre termina e decide
            int contadorB = cadeia.Count(c => c == 'b');
            return contadorB % 3 == 0 ? "SIM" : "NAO";
        }
    }

    // ITEM 8 (AV2-3): Reconhecível que pode não terminar
    public class ReconhecedorNaoTerminante
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 8 (AV2-3): RECONHECÍVEL QUE PODE NÃO TERMINAR ===");
            Console.WriteLine();
            Console.WriteLine("Linguagem: L_prefixo_infinito = {w | w é prefixo de 'aaaa...' infinito}");
            Console.WriteLine("Descrição: Aceita cadeias que são apenas 'a's, mas pode não terminar");
            Console.WriteLine("             ao tentar verificar se precisa de mais 'a's.");
            Console.WriteLine();

            Console.Write("Digite o limite de passos (ex: 100): ");
            string? limiteStr = Console.ReadLine();
            int limitePassos = 100;
            
            if (int.TryParse(limiteStr, out int limite))
            {
                limitePassos = limite;
            }

            Console.Write("Digite a cadeia: ");
            string? cadeia = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine($"Iniciando reconhecimento com limite de {limitePassos} passos...");
            Console.WriteLine();

            bool aceito = false;
            bool atingiuLimite = false;

            // Simular reconhecimento que pode não terminar
            for (int passo = 1; passo <= limitePassos; passo++)
            {
                Console.WriteLine($"Passo {passo}: Verificando cadeia...");

                // Verifica se todos os caracteres são 'a'
                bool todosA = cadeia.All(c => c == 'a');

                if (!todosA)
                {
                    Console.WriteLine($"Passo {passo}: Encontrado símbolo diferente de 'a' - REJEITA");
                    break;
                }

                // Simula tentativa de verificar se precisa de mais 'a's
                if (passo < limitePassos)
                {
                    Console.WriteLine($"Passo {passo}: Cadeia válida até aqui, mas pode precisar de mais 'a's...");
                }
                else
                {
                    Console.WriteLine($"Passo {passo}: LIMITE ATINGIDO!");
                    atingiuLimite = true;
                    aceito = true;
                    break;
                }

                // Para evitar loop infinito real, aceita após alguns passos
                if (todosA && passo > 5)
                {
                    Console.WriteLine($"Passo {passo}: Cadeia parece ser prefixo válido - ACEITA");
                    aceito = true;
                    break;
                }
            }

            Console.WriteLine();
            if (atingiuLimite)
            {
                Console.WriteLine("⚠ EXECUÇÃO INTERROMPIDA POR LIMITE DE PASSOS");
                Console.WriteLine("(Em um reconhecedor real, isso poderia não terminar)");
            }

            if (aceito)
            {
                Console.WriteLine("Resultado: ACEITA");
            }
            else
            {
                Console.WriteLine("Resultado: REJEITA");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }

    // ITEM 9 (AV2-4): Detector Ingênuo de Loop + Reflexão
    public class DetectorLoop
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 9 (AV2-4): DETECTOR INGÊNUO DE LOOP + REFLEXÃO ===");
            Console.WriteLine();
            Console.WriteLine("Simula um processo discreto que lembra estados anteriores");
            Console.WriteLine("e sinaliza quando um estado se repete (possível loop).");
            Console.WriteLine();

            Console.Write("Digite o limite de passos (ex: 50): ");
            string? limiteStr = Console.ReadLine();
            int limitePassos = 50;
            
            if (int.TryParse(limiteStr, out int limite))
            {
                limitePassos = limite;
            }

            Console.WriteLine();
            Console.WriteLine("Escolha um processo para simular:");
            Console.WriteLine("1. Processo com loop (Collatz: n → n/2 se par, 3n+1 se ímpar)");
            Console.WriteLine("2. Processo sem loop (decremento simples até 0)");
            Console.Write("Opção: ");
            
            string? opcao = Console.ReadLine();

            Console.Write("\nDigite o valor inicial: ");
            string? valorStr = Console.ReadLine();
            int valorInicial = 10;
            
            if (int.TryParse(valorStr, out int valor))
            {
                valorInicial = valor;
            }

            Console.WriteLine();
            Console.WriteLine($"Executando com limite de {limitePassos} passos...");
            Console.WriteLine();

            bool loopDetectado = false;
            bool limiteAtingido = false;

            switch (opcao)
            {
                case "1":
                    loopDetectado = SimularCollatz(valorInicial, limitePassos, out limiteAtingido);
                    break;
                case "2":
                    loopDetectado = SimularDecremento(valorInicial, limitePassos, out limiteAtingido);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine();
            if (loopDetectado)
            {
                Console.WriteLine("⚠ LOOP DETECTADO - Estado repetido encontrado!");
            }
            else if (limiteAtingido)
            {
                Console.WriteLine("⚠ LIMITE DE PASSOS ATINGIDO sem detectar loop");
            }
            else
            {
                Console.WriteLine("✓ Processo terminou sem loops detectados");
            }

            ImprimirReflexao();

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool SimularCollatz(int valorInicial, int limitePassos, out bool limiteAtingido)
        {
            HashSet<int> estadosVisitados = new HashSet<int>();
            int estadoAtual = valorInicial;
            limiteAtingido = false;

            for (int passo = 1; passo <= limitePassos; passo++)
            {
                Console.WriteLine($"Passo {passo}: Estado = {estadoAtual}");

                if (estadosVisitados.Contains(estadoAtual))
                {
                    Console.WriteLine($"         ↳ Estado {estadoAtual} JÁ VISITADO!");
                    return true;
                }

                estadosVisitados.Add(estadoAtual);

                if (estadoAtual == 1)
                {
                    Console.WriteLine($"         ↳ Atingiu o valor 1 (condição de parada)");
                    return false;
                }

                if (estadoAtual % 2 == 0)
                {
                    estadoAtual = estadoAtual / 2;
                }
                else
                {
                    estadoAtual = 3 * estadoAtual + 1;
                }
            }

            limiteAtingido = true;
            return false;
        }

        private bool SimularDecremento(int valorInicial, int limitePassos, out bool limiteAtingido)
        {
            HashSet<int> estadosVisitados = new HashSet<int>();
            int estadoAtual = valorInicial;
            limiteAtingido = false;

            for (int passo = 1; passo <= limitePassos; passo++)
            {
                Console.WriteLine($"Passo {passo}: Estado = {estadoAtual}");

                if (estadosVisitados.Contains(estadoAtual))
                {
                    Console.WriteLine($"         ↳ Estado {estadoAtual} JÁ VISITADO!");
                    return true;
                }

                estadosVisitados.Add(estadoAtual);

                if (estadoAtual <= 0)
                {
                    Console.WriteLine($"         ↳ Atingiu 0 ou menos (condição de parada)");
                    return false;
                }

                estadoAtual--;
            }

            limiteAtingido = true;
            return false;
        }

        private void ImprimirReflexao()
        {
            Console.WriteLine();
            Console.WriteLine("=== REFLEXÃO SOBRE FALSOS POSITIVOS/NEGATIVOS ===");
            Console.WriteLine();
            Console.WriteLine("FALSOS POSITIVOS:");
            Console.WriteLine("- Detectar loop quando não há: raro nesta heurística, mas pode ocorrer");
            Console.WriteLine("  se dois estados diferentes produzirem o mesmo hash ou representação.");
            Console.WriteLine();
            Console.WriteLine("FALSOS NEGATIVOS:");
            Console.WriteLine("- NÃO detectar loop quando há: muito comum! Acontece quando:");
            Console.WriteLine("  1. O loop tem período maior que o limite de passos");
            Console.WriteLine("  2. O loop envolve estados não capturados pela representação");
            Console.WriteLine("  3. O processo tem loop mas ainda não voltou ao estado inicial");
            Console.WriteLine();
            Console.WriteLine("LIMITAÇÕES:");
            Console.WriteLine("- Esta heurística só detecta loops de estados exatos");
            Console.WriteLine("- Não detecta loops em espaços de estado infinitos");
            Console.WriteLine("- O limite de passos é arbitrário e pode ser insuficiente");
            Console.WriteLine("- Não resolve o Problema da Parada (indecidível)");
        }
    }

    // ITEM 10 (AV2-5): Simulador de AFD
    public class SimuladorAFD
    {
        private readonly AFD afd;

        public SimuladorAFD()
        {
            // Define um AFD simples: reconhece cadeias que terminam com "ab"
            afd = new AFD();
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 10 (AV2-5): SIMULADOR DE AFD ===");
            Console.WriteLine();
            Console.WriteLine("AFD definido: Reconhece cadeias que terminam com 'ab'");
            Console.WriteLine("Alfabeto Σ = {a, b}");
            Console.WriteLine();
            Console.WriteLine("Estados: q0 (inicial), q1, q2 (final)");
            Console.WriteLine("Transições:");
            Console.WriteLine("  q0 --a--> q1");
            Console.WriteLine("  q0 --b--> q0");
            Console.WriteLine("  q1 --a--> q1");
            Console.WriteLine("  q1 --b--> q2");
            Console.WriteLine("  q2 --a--> q1");
            Console.WriteLine("  q2 --b--> q0");
            Console.WriteLine();

            Console.Write("Digite a cadeia para processar: ");
            string? cadeia = Console.ReadLine() ?? "";

            if (!ValidarAlfabeto(cadeia))
            {
                Console.WriteLine("ERRO: Cadeia contém símbolos fora do alfabeto Σ = {a, b}");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=== EXECUÇÃO DO AFD ===");
            Console.WriteLine();

            bool aceito = afd.Processar(cadeia);

            Console.WriteLine();
            Console.WriteLine($"Resultado final: {(aceito ? "ACEITA" : "REJEITA")}");
            
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool ValidarAlfabeto(string cadeia)
        {
            HashSet<char> alfabeto = new HashSet<char> { 'a', 'b' };
            return cadeia.All(c => alfabeto.Contains(c));
        }
    }

    public class AFD
    {
        private readonly Dictionary<string, Dictionary<char, string>> transicoes;
        private readonly HashSet<string> estadosFinais;
        private readonly string estadoInicial;

        public AFD()
        {
            // AFD que reconhece cadeias terminando com "ab"
            estadoInicial = "q0";
            estadosFinais = new HashSet<string> { "q2" };

            transicoes = new Dictionary<string, Dictionary<char, string>>
            {
                ["q0"] = new Dictionary<char, string>
                {
                    ['a'] = "q1",
                    ['b'] = "q0"
                },
                ["q1"] = new Dictionary<char, string>
                {
                    ['a'] = "q1",
                    ['b'] = "q2"
                },
                ["q2"] = new Dictionary<char, string>
                {
                    ['a'] = "q1",
                    ['b'] = "q0"
                }
            };
        }

        public bool Processar(string cadeia)
        {
            string estadoAtual = estadoInicial;
            Console.WriteLine($"Estado inicial: {estadoAtual}");

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia");
                bool aceita = estadosFinais.Contains(estadoAtual);
                return aceita;
            }

            for (int i = 0; i < cadeia.Length; i++)
            {
                char simbolo = cadeia[i];
                
                if (transicoes.ContainsKey(estadoAtual) && transicoes[estadoAtual].ContainsKey(simbolo))
                {
                    string proximoEstado = transicoes[estadoAtual][simbolo];
                    Console.WriteLine($"Lendo '{simbolo}': {estadoAtual} → {proximoEstado}");
                    estadoAtual = proximoEstado;
                }
                else
                {
                    Console.WriteLine($"Lendo '{simbolo}': transição indefinida de {estadoAtual}");
                    return false;
                }
            }

            Console.WriteLine($"Estado final: {estadoAtual}");
            bool resultado = estadosFinais.Contains(estadoAtual);
            Console.WriteLine($"Estado final é {(resultado ? "de aceitação" : "não-final")}");

            return resultado;
        }
    }
}