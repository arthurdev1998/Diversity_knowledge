using System.Diagnostics;
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
            var fontebase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            var fonteparagrafo = new iTextSharp.text.Font(fontebase, 32,
            iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var titulo = new Paragraph("Relatorio de pessoas\n\n", fonteparagrafo);
            titulo.Alignment = Element.ALIGN_LEFT;

            // configuracao do documento pdf
            var pxporMilimetro = 72/25.2f;
            var pdf = new Document(PageSize.A4, 15*pxporMilimetro, 15 *pxporMilimetro, 15*pxporMilimetro, 20*pxporMilimetro );
            var nomeArquivo = $"pessoas.{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.pdf";
            // filestream é a operacao de fornecer para um arquivo leitura e gravacao
            var arquivo = new FileStream(nomeArquivo, FileMode.Create);

            var writer = PdfWriter.GetInstance(pdf,arquivo);
            pdf.Open();
            pdf.Add(titulo);

            var caminhopdf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
            if(File.Exists(caminhopdf))
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = $"/c start {caminhopdf}",
                    FileName = "cmd.exe",
                    CreateNoWindow = true
                });
            }

            //Adicao de imagem
            var caminhoImagem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                                "img\\youtube.png");
            
            if(File.Exists(caminhoImagem))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(caminhoImagem);
                float razaoAlturaLargura = logo.Width/logo.Height;
                float alturaLogo = 32;
                float larguraLogo = alturaLogo * razaoAlturaLargura;
                logo.ScaleToFit(larguraLogo, alturaLogo);
                var margemEsquerda = pdf.PageSize.Width - pdf.RightMargin - larguraLogo;
                var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 54;
                logo.SetAbsolutePosition(margemEsquerda,margemTopo);
                writer.DirectContent.AddImage(logo,false);
            }

            //adicao da tabela de dados 
            
        }
    }
}