using System;

//using System.Console.dll;

namespace anagramania_metodos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = new string[7] { "hipopotamo", "canguru", "narval", "penguim", "gazela", "veado", "leão" }; //matriz com as palavras a serem embaralhadas
            bool repeticao = false;
            int numeroAcertos = 0;
            do
            {
                Console.WriteLine("Bem vindos ao jogo: ANAGRAMANIA DA TIA <3\r\nPara ganhar o jogo você deve adivinhar quais são as palvras que estam emabalharadas.\r\nBoa sorte ;)!!");
                numeroAcertos =0;
                QuebraPalavras(palavras);

                while (numeroAcertos < palavras.Length)
                {
                    numeroAcertos = UsuarioResposta(palavras, numeroAcertos);
                }
                repeticao = Repetir(repeticao);
                
            } while (repeticao == true);
            if (repeticao == false)
            {
                Environment.Exit(0);
            }

        }

        static bool Repetir(bool repeticao2)
        {
            Console.WriteLine("Parabéns!!! *clap* *clap* *clap* Você acertou todas as palavras. Muito obrigada por ter jogado ANAGRAMANIA DA TIA ");
            Console.WriteLine("Se desejar sair do jogo, aperte: <enter>. Se quiser refazer o quiz, aperte qualquer tecla  ");
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                return true; // volta pro começo do codigo
            }
            else
            {
                return false;
            }
        }
        static int UsuarioResposta(string[] palavras, int numeroAcertos)
        {
            string respostaUsuario;
            Console.WriteLine("Digite uma palavras:");
            respostaUsuario = Console.ReadLine().ToLower();
            for (int l = 0; l < palavras.Length; l++) // loop para verificar se a palavra digitada esta certa
            {
                if (respostaUsuario == palavras[l]) // essa condição é para ver se o usuario acertou algumas das palavras, se nao, é pedido novamente uma palvra e todo o loop acontece novamente
                {
                    numeroAcertos++;
                    Console.WriteLine("Parabens você acertou a palavras: " + respostaUsuario + ".");
                    //Console.WriteLine();
                    if ((palavras.Length - numeroAcertos) > 0)
                    {
                        Console.WriteLine("Ainda falta " + (palavras.Length - numeroAcertos) + " palavras");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
            return numeroAcertos;
        }
        static void QuebraPalavras(string[] palavras)
        {
            Random numero = new Random();
            char[] letras;  // variavel para separar as palavras
            int[] sequenciaNumeros; //array para colocar os numeros gerados em uma sequencia, onde cada numero é uma letras
            int numeroGerado;
            for (int i = 0; i < palavras.Length; i++)
            {
                letras = palavras[i].ToCharArray(); // quebrar a palavra em caracteres
                Console.WriteLine();

                sequenciaNumeros = new int[letras.Length]; // sequencia de numeros vai ser do tamanho da varias letras 
                for (int h = 0; h < letras.Length; h++) //caracter individual do array
                {
                inicio: //referencia
                    numeroGerado = numero.Next(letras.Length); //numeros é gerado aleatoriamente
                    sequenciaNumeros[h] = 10; // é pre definido um numero, para quando for gerado o numero 0 nao de erro no codigo
                    for (int p = 0; p < letras.Length; p++)
                    {
                        if (sequenciaNumeros[p] == numeroGerado) //testa para ver se o numero gerado ja foi repetido
                        {
                            goto inicio; // se o numero já foi gerado ele volta pra linha de referencia e pula todo o resto do for
                        }
                    }
                    sequenciaNumeros[h] = numeroGerado;
                }
                for (int j = 0; j < letras.Length; j++)
                {
                    Console.Write(letras[sequenciaNumeros[j]]);//ele usa a sequencia de numeros aleatorio para pegar uma letra da palavra
                    Console.WriteLine();
                }

            }
        }
    }
}
