namespace BinaryThree;

public class ThreeBinary<T> where T : IComparable
{
    public T? Valor { get; set; }
    public Element<T>? EsquerdaValor { get; set; } = null;
    public Element<T>? DireitaValor { get; set; } = null;

    public void AddElement(T newElement)
    {
        if (Valor == null)
        {
            Valor = newElement;
        }
        else
        {
            Element<T> atual = new Element<T>(Valor, EsquerdaValor, DireitaValor);
            Element<T> element = new Element<T>();
            element.Valor = newElement;

            while (atual.EsquerdaElemento != null || atual.DireitaElemento != null)
            {
                if (element.Valor.CompareTo(atual.Valor) > 0)
                {
                    if (atual.EsquerdaElemento != null)
                    {
                        atual = atual.EsquerdaElemento;
                        continue;
                    }
                    break;

                }
                if(atual.DireitaElemento != null)
                {
                    atual = atual.DireitaElemento;
                    continue;
                }
                break;

            }
            if (element.Valor.CompareTo(atual.Valor) > 0)
            {
                atual.EsquerdaElemento = element;
            }
            else
            {
                atual.DireitaElemento = element;
            }
        }
    }
}