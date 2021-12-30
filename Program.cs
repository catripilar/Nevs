using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace T.Series
{
    class Program
    {
        static SerieR repositorio = new SerieR();
        static void Main(string[] args){
            string opcusuario = OpcUsuario();
            while (opcusuario.ToUpper() != "X"){
                switch(opcusuario){
                    case "1":InserirS();break;
                    case "2":VisualizaS();break;
                    case "3":ListarS();break;
                    case "C":Console.Clear();break;
                    default:throw new ArgumentOutOfRangeException();
                }
            opcusuario = OpcUsuario();
            }
            Console.WriteLine("Obrigado pela escolha!");
        }
        private static void VisualizaS(){
            Console.WriteLine("Lembretes marcados:");
            var lista = repositorio.Lista();
            if (lista.Count == 0){Console.WriteLine("Nenhum Lembrete ainda.");return;}
            foreach(var serie in lista){
                Console.WriteLine("*-"+serie.RGenero().ToString()+"-*~~"+
                serie.Rtitulo().ToString()+
                " -:"+serie.Rdescri().ToString());
                Console.WriteLine();
            }
        }
        private static void ListarS(){
            var lista = repositorio.Lista();
            List<string> lines = new List<string>();
            string path = "Notas:"+DateTime.Now.ToString("dd-MM-yy as HH:mm")+".txt";
            using (FileStream fs = File.Create(path)){}
            lines = File.ReadAllLines(path).ToList();
            if (lista.Count == 0){Console.WriteLine("Nenhum Lembrete marcado.");return;}
            foreach(var serie in lista){
                lines.Add("*-"+serie.RGenero().ToString()+"-*~~"+
                serie.Rtitulo().ToString()+
                " -:"+serie.Rdescri().ToString());
                lines.Add("");
                File.WriteAllLines(path,lines);
                Console.WriteLine("Salvo em:"+path);
                File.WriteAllLines(path,lines);
            }
        }
        private static void InserirS(){
            Console.WriteLine("Tipo do Recado:");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Prioridade:");
            int entradaG = int.Parse(Console.ReadLine());
            Console.Write("Titulo do Lembrete:");
            string entradaT = Console.ReadLine();
            Console.Write("Mensagem:");
            string entradaD = Console.ReadLine();
            Serie novaSerie = new Serie(
                id:repositorio.PI(),
                genero:(Genero)entradaG,
                titulo:entradaT,
                descri:entradaD
            );
            repositorio.Insere(novaSerie);
        }
        private static string OpcUsuario(){
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao Nevs!");
            Console.WriteLine("O que deseja?");
            Console.WriteLine("1- Novo lembrete");
            Console.WriteLine("2- Visualizar Lembretes");
            Console.WriteLine("3- Salvar");
            Console.WriteLine("C- Limpar Console");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcusuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcusuario;
        }
    }
}
