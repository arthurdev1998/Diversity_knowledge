namespace BinaryThree;

public class Element<T> where T : IComparable
{
    public Element(T? valor, Element<T>? esquerdaElemento, Element<T>? direitaElement)
    {
        Valor = valor;
        EsquerdaElemento = esquerdaElemento;
        DireitaElemento = direitaElement;
    }

    public Element()
    { }

    public T? Valor { get; set; }
    public Element<T>? EsquerdaElemento { get; set; } = null;
    public Element<T>? DireitaElemento { get; set; } = null;
}