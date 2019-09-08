using System;
using System.Globalization;
using System.Text;

namespace _13ºSalario.Entities
{
    class DecimoTerceiroSalario
    {
        public string Funcionario { get; set; }
        public double Hora { get; set; }
        public double HoraExtra75 { get; set; }
        public double HoraExtra100 { get; set; }
        public double AdicionalNoturno { get; set; }
        public int Dependente { get; set; }

        public DecimoTerceiroSalario(string funcionario, double hora, double horaExtra75, double horaExtra100, double adicionalNoturno, int dependente)
        {
            Funcionario = funcionario;
            Hora = hora;
            HoraExtra75 = horaExtra75;
            HoraExtra100 = horaExtra100;
            AdicionalNoturno = adicionalNoturno;
            Dependente = dependente;
        }

        public DecimoTerceiroSalario()
        {
        }

        public double Salario()
        {
            return Hora * 220.00;
        }

        public double _1ºParcelaDecimo()
        {
            return Salario() * 0.50;
        }

        public double MediaHoraExtra75()
        {
            return (Hora *  HoraExtra75 * 0.75 + Hora * HoraExtra75) / 12.0 ;
        }

        public double MediaHoraExtra100()
        {
            return (Hora * HoraExtra100 * 1 + Hora * HoraExtra100)  / 12.0;
        }

        public double MediaHoraExtra()
        {
            return MediaHoraExtra75() + MediaHoraExtra100();
        }

        public double MediaAdicionalNotruno()
        {
            return (Hora * 0.35 * AdicionalNoturno) / 12.0;
        }

        public double BaseCalculoInss()
        {
            return Salario() + MediaHoraExtra() + MediaAdicionalNotruno();
        }

        public double CalculoInss()
        {
            if (BaseCalculoInss() < 1751.82)
            {
                return BaseCalculoInss() * 0.08;
            }
            else if (BaseCalculoInss() < 2919.73)
            {
                return BaseCalculoInss() * 0.09;
            }
            else if (BaseCalculoInss() < 5839.46)
            {
                return BaseCalculoInss() * 0.11;
            }
            else
            {
                return 641.24;
            }
        }

        public double AliquotaInss()
        {
            if (BaseCalculoInss() < 1751.82)
            {
                return 8;
            }
            else if (BaseCalculoInss() < 2919.73)
            {
                return 9;
            }
            else if (BaseCalculoInss() < 5839.46)
            {
                return 11;
            }
            else
            {
                return 0;
            }
        }

        public double CalculoDependente()
        {
            return Dependente * 189.59;
        }

        public double BaseCalculoIrrf()
        {
            return BaseCalculoInss() - CalculoInss() - CalculoDependente();
        }

        public double CalculoIrrf()
        {
            if(BaseCalculoIrrf() < 1903.99)
            {
                return 0.0;
            }
            else if(BaseCalculoIrrf() < 2826.66)
            {
                return BaseCalculoIrrf() * 0.075 - 142.80;
            }
            else if(BaseCalculoIrrf() < 3751.06)
            {
                return BaseCalculoIrrf() * 0.15 - 354.80;
            }
            else if(BaseCalculoIrrf() < 4664.69)
            {
                return BaseCalculoIrrf() * 0.225 - 636.13;
            }
            else
            {
                return BaseCalculoIrrf() * 0.275 - 869.36;
            }
        }

        public double AliquotaIrrf()
        {
            if (BaseCalculoIrrf() < 1903.99)
            {
                return 0;
            }
            else if (BaseCalculoIrrf() < 2826.66)
            {
                return 7.5;
            }
            else if (BaseCalculoIrrf() < 3751.06)
            {
                return 15;
            }
            else if (BaseCalculoIrrf() < 4664.69)
            {
                return 22.5;
            }
            else
            {
                return 27.5;
            }
        }

        public double Vencimentos()
        {
            return Salario() + MediaHoraExtra() + MediaAdicionalNotruno();
        }

        public double Descontos()
        {
            return _1ºParcelaDecimo() + CalculoInss() + CalculoIrrf();
        }

        public double Fgts()
        {
            return Vencimentos() * 0.08;
        }

        public double LiquidoReceber()
        {
            return Vencimentos() - Descontos();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("O Décimo Terceiro é: R$ " + Salario().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine("A 1º Parcela do Décimo Terceiro é: R$ " +_1ºParcelaDecimo().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine();
            if(MediaHoraExtra() != 0.0)
            { sb.AppendLine("A Média das Horas Extra é: R$ " + MediaHoraExtra().ToString("F2", CultureInfo.InvariantCulture)); }
            if(MediaAdicionalNotruno() != 0.0)
            { sb.AppendLine("A Média do Adicional Noturno é: R$ " + MediaAdicionalNotruno().ToString("F2", CultureInfo.InvariantCulture)); }
            sb.AppendLine();
            sb.AppendLine("Salário Base Para Cálculo do INSS é: R$ " + BaseCalculoInss().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine("Desconto do INSS é R$ " + CalculoInss().ToString("F2", CultureInfo.InvariantCulture));
            if (AliquotaInss() == 0)
            { sb.AppendLine("Alíquota do INSS é: Fixa"); }
            else
            { sb.AppendLine("Alíquota do INSS é: " + AliquotaInss() + "%"); }
            sb.AppendLine();
            sb.AppendLine("Salário Base para Cálculo do IRRF é: R$ " + BaseCalculoIrrf().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine("Desconto do IRRF é R$ " + CalculoIrrf().ToString("F2", CultureInfo.InvariantCulture));
            if (AliquotaIrrf() == 0)
            { sb.AppendLine("Alíquota do IRRF é: Isento"); }
            else
            { sb.AppendLine("Alíquota do IRRF é " + AliquotaIrrf() + "%"); }
            sb.AppendLine();
            sb.AppendLine("Total dos Vencimentos é: R$ " + Vencimentos().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine("Total dos Descontos é: R$ " + Descontos().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine();
            sb.AppendLine("FGTS do Décimo Terceiro é: R$ " + Fgts().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine("Décimo Terceiro Líquido à Receber é: R$ " + LiquidoReceber().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
