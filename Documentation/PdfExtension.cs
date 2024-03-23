using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Documentation;

public static class PdfExtension
{
    public static void GerarRelatorioPdf(int qtdPessoas, IEnumerable<Pessoa> pessoas)
    {
        var pessoasSelecionadas = pessoas.Take(qtdPessoas).ToList();
        if(pessoasSelecionadas.Count > 0)
        {
            var fontebase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false)
            
            // configuracao do documento pdf
            var pxporMilimetro = 72/25.2f;
            var pdf = new Document(PageSize.A4, 15*pxporMilimetro, 15 *pxporMilimetro, 15*pxporMilimetro, 20*pxporMilimetro );
            var nomeArquivo = $"pessoas.{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.pdf";
            var arquivo = new FileStream(nomeArquivo, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf,arquivo);
        }
    }
}