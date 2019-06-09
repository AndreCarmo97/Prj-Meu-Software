using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PROJETO_MEU_SOFTWARE
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome, cargo;
            char dependentesOp;
            int dependentes = 0;
            char vtOp = 'S';
            double vt = 0;
            double salarioBruto;

            Console.WriteLine("Digite seu nome:");
            nome = Console.ReadLine();
            Console.Clear(); 

            DateTime dtLocal = DateTime.Now;
            DateTime dtNasc;
            TimeSpan idade;

            Console.WriteLine("Digite sua data de nascimento: (Ex: dd/mm/aaaa)");
            dtNasc = DateTime.Parse(Console.ReadLine());
            idade = dtLocal - dtNasc;
            Console.Clear();

            Console.WriteLine("Digite seu cargo em nossa empresa:");
            cargo = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Digite S ou N para confirmar a próxima etapa!\n");
            Console.WriteLine("Possui dependentes em sua família?");
            dependentesOp = char.Parse(Console.ReadLine());
            Console.Clear();

            if (char.ToUpper(dependentesOp) == 'S')
            {
                Console.WriteLine("Quantidade de dependentes:");
                dependentes = int.Parse(Console.ReadLine());
            }
            double descontoDependentes = dependentes * 189.59;
            Console.Clear(); 

            Console.WriteLine("Digite S ou N para confirmar a próxima etapa!\n");
            Console.WriteLine("Recebe Vale Transporte?");
            vtOp = char.Parse(Console.ReadLine());
            Console.Clear();

            if (char.ToUpper(vtOp) == 'S')
            {
                Console.WriteLine("Digite o valor do seu Vale-Transporte:");
                vt = double.Parse(Console.ReadLine());
            }
            Console.Clear();

            Console.WriteLine("Digite o valor do seu SALÁRIO BRUTO: (Ex: 1550,75) *Sem descontos");
            salarioBruto = double.Parse(Console.ReadLine());

            double inss = 0, irrf = 0, fgts;

            //INSS
            if (salarioBruto <= 175181)
            {
                inss = (salarioBruto * 8) / 100;
            }
            if (salarioBruto <= 291972)
            {
                inss = (salarioBruto * 9) / 100;
            }
            if (salarioBruto > 291973)
            {
                inss = (salarioBruto * 11) / 100;
            }

            //IRRF
            if (salarioBruto >= 190399)
            {
                irrf = 0;
            }
            if (salarioBruto <= 282665)
            {
                irrf = (salarioBruto * 7.5) / 100;
                irrf = irrf - descontoDependentes;
            }
            if (salarioBruto <= 375105)
            {
                irrf = (salarioBruto * 15) / 100;
                irrf = irrf - descontoDependentes;
            }
            if (salarioBruto <= 466468)
            {
                irrf = (salarioBruto * 22.5) / 100;
                irrf = irrf - descontoDependentes;
            }
            if (salarioBruto > 466469)
            {
                irrf = (salarioBruto * 27.5) / 100;
                irrf = irrf - descontoDependentes;
            }
            fgts = (salarioBruto * 8) / 100;
            double salarioReaj = salarioBruto - vt - inss - irrf - fgts;
            Console.Clear();

            int idFuncionario;
            Random rdId = new Random();

            idFuncionario = rdId.Next(0,9999);

            string ficheiro = "Dados.txt";
            StreamWriter sw;
            if (File.Exists(ficheiro))
            {
                sw = File.AppendText(ficheiro);
            }
            else
            {
                sw = File.CreateText(ficheiro);
            }
            sw.WriteLine($"Id do Funcionário: {"2019" + idFuncionario};\nNome: {nome};\nCargo: {cargo};\nData de Nascimento: {dtNasc.ToShortDateString()};\nIdade: {idade.Days/30/12} anos;\nSalário Bruto: {salarioBruto.ToString("0.00")};\nN° de Dependentes: {dependentes};\nDesconto por Dependentes no IR: {descontoDependentes.ToString("0.00")};\nINSS: {inss.ToString("0.00")};\nIRRF: {irrf.ToString("0.00")};\nFGTS: {fgts.ToString("0.00")};\nVale-Transporte: {vt.ToString("0.00")};\nSalário Líquido: {salarioReaj.ToString("0.00")}");
            sw.Close();

            Console.WriteLine($"Dados Fornecidos\n\nId do Funcionário: {"2019" + idFuncionario}\nNome: {nome}\nCargo: {cargo}\nData de Nascimento: {dtNasc.ToShortDateString()}\nIdade: {idade.Days / 30 / 12} anos\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Salário e Descontos Mensais:\n");
            Console.WriteLine($"Salário Bruto: { salarioBruto.ToString("0.00")}\nN° de Dependentes: { dependentes}\nDesconto por Dependentes no IR: {descontoDependentes.ToString("0.00")}\nINSS: { inss.ToString("0.00")}\nIRRF: { irrf.ToString("0.00")}\nFGTS: { fgts.ToString("0.00")}\nVale - Transporte: { vt.ToString("0.00")}\nSalário Líquido: { salarioReaj.ToString("0.00")}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCadastro realizado com sucesso!!!\nDigite Qualquer Tecla Para Sair...");
            Console.ReadKey();
            Environment.Exit(0);

            Console.ReadKey();
        }
    }
}
