using System;
namespace T.Series{public abstract class EBase{public int Id{get;protected set;}}}
namespace T.Series{public enum Genero{Recado = 1,Inportante = 2,Urgente = 3}}
namespace T.Series{
    public class Serie:EBase{
        private Genero Genero{get;set;}
        private string Titulo{get;set;}
        private string Descri{get;set;}
        public Serie(int id,Genero genero, string titulo,string descri){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descri = descri;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero:" + this.Genero + Environment.NewLine;
            retorno += "Titulo:" + this.Titulo + Environment.NewLine;
            retorno += "Descrição:" + this.Descri + Environment.NewLine;
            return retorno;
        }
        public string Rtitulo(){return this.Titulo;}
        public string Rdescri(){return this.Descri;}
        public Genero RGenero(){return this.Genero;}
        public int Rid(){return this.Id;}
    }
}