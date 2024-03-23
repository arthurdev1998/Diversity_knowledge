using System.Text.Json;

namespace Documentation;

public class DesserializarPessoas
{
    public void Dessesrializar()
    {
        List<Pessoa> pessoas = [];

        //streamreader 
        if (File.Exists("pessoas.json"))
        {
            using (var sr = new StreamReader("pessoas.json"))
            {
                var dados = sr.ReadToEnd();
                pessoas = JsonSerializer.Deserialize(dados, typeof(List<Pessoa>)) as List<Pessoa>;
            }

            foreach(var pessoa in pessoas)
            {
                Console.WriteLine(pessoa.Nome);
            }
        }

        PdfExtension.GerarRelatorioPdf(10, pessoas);
    }
}