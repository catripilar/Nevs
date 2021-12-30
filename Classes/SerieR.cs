using System;
using System.Collections.Generic;
using T.Series.Interface;
namespace T.Series{
    public class SerieR : IRep<Serie>{
        private List<Serie> listaSerie = new List<Serie>();
        public void Insere(Serie obj){listaSerie.Add(obj);}
        public List<Serie> Lista(){return listaSerie;}
        public int PI(){return listaSerie.Count;}
        public Serie RPI(int id){return listaSerie[id];}
    }
}