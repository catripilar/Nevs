using System.Collections.Generic;
namespace T.Series.Interface{
    public interface IRep<T>{
        List<T> Lista();T RPI(int id);void Insere(T entidade);int PI();
    }
}