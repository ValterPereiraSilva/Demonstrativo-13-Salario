using System;
using System.Globalization;
using System.Collections.Generic;
using _13ºSalario.Entities;

namespace _13ºSalario
{
    class Program
    {
        private static double horaExtra75;
        private static double horaExtra100;
        private static double adicionalNoturno;
        private static int dependente;

        static void Main(string[] args)
        {
            DecimoTerceiroSalario calculo = new DecimoTerceiroSalario();

            Console.Write("Digite o Nome do Funcionário: ");
            string funcionario = Console.ReadLine();
            Console.Write(funcionario + " Qual o Valor da Sua Hora: ");
            double hora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write(funcionario + " Você tem Reflexos Sobre Décimo Terceiro (s/n)?: ");
            char pergunta = char.Parse(Console.ReadLine());
            if (pergunta == 's' || pergunta == 'S')
            {
                Console.Write(funcionario + " Você tem Hora Extra à 75% (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write("Quantas Horas à 75% são: ");
                    horaExtra75 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    calculo = new DecimoTerceiroSalario(funcionario, hora, horaExtra75, horaExtra100, adicionalNoturno, dependente);
                }
                Console.Write(funcionario + " Você tem Hora Extra à 100% (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write("Quantas Horas à 100% são: ");
                    horaExtra100 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    calculo = new DecimoTerceiroSalario(funcionario, hora, horaExtra75, horaExtra100, adicionalNoturno, dependente);
                }
                Console.Write(funcionario + " Você tem Horas de Adicional Noturno (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write("Quantas Horas de Adicional Noturno são: ");
                    adicionalNoturno = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    calculo = new DecimoTerceiroSalario(funcionario, hora, horaExtra75, horaExtra100, adicionalNoturno, dependente);
                }
            }
            Console.Write(funcionario + " Você tem Dependentes para Dedução do IRRF (s/n)?: ");
            pergunta = char.Parse(Console.ReadLine());
            if (pergunta == 's' || pergunta == 'S')
            {
                Console.Write("Quantos Dependentes são: ");
                dependente = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                calculo = new DecimoTerceiroSalario(funcionario, hora, horaExtra75, horaExtra100, adicionalNoturno, dependente);
            }
            Console.WriteLine();
            Console.WriteLine(calculo.ToString());
        }
    }
}
