using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Management;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Sistema.UTIL
{
    public class util_Impressao
    {
        private LocalReport report;
        private IList<Stream> listaStreams;
        private PrintDocument documento;
        private int paginaAtual;

        #region CONSTRUTORES
        public util_Impressao()
        {
            listaStreams = new List<Stream>();
        }

        public util_Impressao(LocalReport report)
        {
            this.report = report;
            listaStreams = new List<Stream>();
        }
        #endregion

        public static util_Impressao Novo(LocalReport report)
        {
            return new util_Impressao(report);
        }

        public void Imprimir(PrintDocument documento, Tipo_Impressao _Tipo)
        {
            if (_Tipo == Tipo_Impressao.Paisagem)
                documento.DefaultPageSettings.Landscape = true;

            this.documento = documento;
            ExportarParaImagem(_Tipo);

            if (_Tipo == Tipo_Impressao.Termica)
                Imprimir_Termica();
            else
                Imprimir();
        }

        public void Imprime_lst_Relatorio(PrintDocument documento)
        {
            this.documento = documento;
            Imprimir();
        }

        public void Cria_lst_Relatorio(LocalReport report)
        {
            string informacao =
          @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>21cm</PageWidth>
                <PageHeight>29,7cm</PageHeight>
                <MarginTop>0,5cm</MarginTop>
                <MarginLeft>0,5cm</MarginLeft>
                <MarginRight>0cm</MarginRight>
                <MarginBottom>0cm</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            report.Render("Image", informacao, CriarStream, out warnings);
            foreach (Stream stream in listaStreams)
                stream.Position = 0;
        }

        private void ExportarParaImagem(Tipo_Impressao _Tipo)
        {
            string informacao = string.Empty;

            if (_Tipo == Tipo_Impressao.Retrato)
                informacao =
                    @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>21cm</PageWidth>
                <PageHeight>29,7cm</PageHeight>
                <MarginTop>0,5cm</MarginTop>
                <MarginLeft>0,5cm</MarginLeft>
                <MarginRight>0cm</MarginRight>
                <MarginBottom>0cm</MarginBottom>
            </DeviceInfo>";

            if (_Tipo == Tipo_Impressao.Paisagem)
                informacao =
                   @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>29,7cm</PageWidth>
                <PageHeight>21cm</PageHeight>
                <MarginTop>0,5cm</MarginTop>
                <MarginLeft>0,5cm</MarginLeft>
                <MarginRight>0cm</MarginRight>
                <MarginBottom>0cm</MarginBottom>
            </DeviceInfo>";

            if (_Tipo == Tipo_Impressao.Termica)
                informacao = @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8cm</PageWidth>
                <PageHeight>0cm</PageHeight>
                <MarginTop>0cm</MarginTop>
                <MarginLeft>0cm</MarginLeft>
                <MarginRight>0cm</MarginRight>
                <MarginBottom>0cm</MarginBottom>
            </DeviceInfo>";

            Warning[] warnings;


            report.Render("Image", informacao, CriarStream, out warnings);
            foreach (Stream stream in listaStreams)
                stream.Position = 0;
        }

        private Stream CriarStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            var stream = new MemoryStream();
            listaStreams.Add(stream);
            return stream;
        }

        private void Imprimir_Termica()
        {
            if (listaStreams.Count == 0)
                throw new Exception("Erro ao imprimir: nenhuma 'Stream' foi carregada para a impressão");
            if (!documento.PrinterSettings.IsValid)
                throw new Exception(string.Format("Erro ao imprimir: não foi possivel encontrar a impressora '{0}'", documento.PrinterSettings.PrinterName));

            // documento.PrinterSettings.PaperSizes = documento.DefaultPageSettings.PaperSize();
            documento.PrintPage += Imprimindo_Termica;
            paginaAtual = 0;
            documento.Print();
        }

        private void Imprimir()
        {
            if (listaStreams.Count == 0)
                throw new Exception("Erro ao imprimir: nenhuma 'Stream' foi carregada para a impressão");
            if (!documento.PrinterSettings.IsValid)
                throw new Exception(string.Format("Erro ao imprimir: não foi possivel encontrar a impressora '{0}'", documento.PrinterSettings.PrinterName));

            // documento.PrinterSettings.PaperSizes = documento.DefaultPageSettings.PaperSize();
            documento.PrintPage += Imprimindo;
            paginaAtual = 0;
            documento.Print();
        }

        private void Imprimindo_Termica(object sender, PrintPageEventArgs ev)
        {
            var imagemAtual = new Metafile(listaStreams[paginaAtual]);

            // Adjust rectangular area with printer margins.
            var retanguloAjustado = new Rectangle(-2, -2, 300, 1100);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, retanguloAjustado);

            // Draw the report content
            ev.Graphics.DrawImage(imagemAtual, retanguloAjustado);

            // Prepare for the next page. Make sure we haven't hit the end.
            paginaAtual++;
            ev.HasMorePages = (paginaAtual < listaStreams.Count);
        }

        private void Imprimindo(object sender, PrintPageEventArgs ev)
        {
            var imagemAtual = new Metafile(listaStreams[paginaAtual]);

            // Adjust rectangular area with printer margins.

            var retanguloAjustado = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, retanguloAjustado);

            // Draw the report content
            ev.Graphics.DrawImage(imagemAtual, retanguloAjustado);

            // Prepare for the next page. Make sure we haven't hit the end.
            paginaAtual++;
            ev.HasMorePages = (paginaAtual < listaStreams.Count);
        }
    }

    public class AutoPrintCls : PrintDocument
    {
        private PageSettings m_pageSettings;
        private int m_currentPage;
        private List<Stream> m_pages = new List<Stream>();

        public AutoPrintCls(ServerReport serverReport)
            : this((Report)serverReport)
        {
            RenderAllServerReportPages(serverReport);
        }

        public AutoPrintCls(LocalReport localReport)
            : this((Report)localReport)
        {
            RenderAllLocalReportPages(localReport);
        }

        private AutoPrintCls(Report report)
        {
            // Set the page settings to the default defined in the report
            ReportPageSettings reportPageSettings = report.GetDefaultPageSettings();

            // The page settings object will use the default printer unless
            // PageSettings.PrinterSettings is changed.  This assumes there
            // is a default printer.
            m_pageSettings = new PageSettings();
            m_pageSettings.PaperSize = reportPageSettings.PaperSize;
            m_pageSettings.Margins = reportPageSettings.Margins;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                foreach (Stream s in m_pages)
                {
                    s.Dispose();
                }

                m_pages.Clear();
            }
        }

        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);

            m_currentPage = 0;
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            Stream pageToPrint = m_pages[m_currentPage];
            pageToPrint.Position = 0;

            // Load each page into a Metafile to draw it.
            using (Metafile pageMetaFile = new Metafile(pageToPrint))
            {
                Rectangle adjustedRect = new Rectangle(
                        e.PageBounds.Left - (int)e.PageSettings.HardMarginX,
                        e.PageBounds.Top - (int)e.PageSettings.HardMarginY,
                        e.PageBounds.Width,
                        e.PageBounds.Height);

                // Draw a white background for the report
                e.Graphics.FillRectangle(Brushes.White, adjustedRect);

                // Draw the report content
                e.Graphics.DrawImage(pageMetaFile, adjustedRect);

                // Prepare for next page.  Make sure we haven't hit the end.
                m_currentPage++;
                e.HasMorePages = m_currentPage < m_pages.Count;
            }
        }

        protected override void OnQueryPageSettings(QueryPageSettingsEventArgs e)
        {
            e.PageSettings = (PageSettings)m_pageSettings.Clone();
        }

        private void RenderAllServerReportPages(ServerReport serverReport)
        {
            try
            {
                string deviceInfo = CreateEMFDeviceInfo();

                // Generating Image renderer pages one at a time can be expensive.  In order
                // to generate page 2, the server would need to recalculate page 1 and throw it
                // away.  Using PersistStreams causes the server to generate all the pages in
                // the background but return as soon as page 1 is complete.
                NameValueCollection firstPageParameters = new NameValueCollection();
                firstPageParameters.Add("rs:PersistStreams", "True");

                // GetNextStream returns the next page in the sequence from the background process
                // started by PersistStreams.
                NameValueCollection nonFirstPageParameters = new NameValueCollection();
                nonFirstPageParameters.Add("rs:GetNextStream", "True");

                string mimeType;
                string fileExtension;


                Stream pageStream = serverReport.Render("IMAGE", deviceInfo, firstPageParameters, out mimeType, out fileExtension);



                // The server returns an empty stream when moving beyond the last page.
                while (pageStream.Length > 0)
                {
                    m_pages.Add(pageStream);

                    pageStream = serverReport.Render("IMAGE", deviceInfo, nonFirstPageParameters, out mimeType, out fileExtension);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("possible missing information ::  " + e);
            }
        }

        private void RenderAllLocalReportPages(LocalReport localReport)
        {
            try
            {
                string deviceInfo = CreateEMFDeviceInfo();

                Warning[] warnings;

                localReport.Render("IMAGE", deviceInfo, LocalReportCreateStreamCallback, out warnings);
            }
            catch (Exception e)
            {
                MessageBox.Show("error :: " + e);
            }
        }

        private Stream LocalReportCreateStreamCallback(
            string name,
            string extension,
            Encoding encoding,
            string mimeType,
            bool willSeek)
        {
            MemoryStream stream = new MemoryStream();
            m_pages.Add(stream);

            return stream;
        }

        private string CreateEMFDeviceInfo()
        {
            PaperSize paperSize = m_pageSettings.PaperSize;
            Margins margins = m_pageSettings.Margins;

            // The device info string defines the page range to print as well as the size of the page.
            // A start and end page of 0 means generate all pages.
            return string.Format(
                CultureInfo.InvariantCulture,
                "emf00{0}{1}{2}{3}{4}{5}",
                ToInches(margins.Top),
                ToInches(margins.Left),
                ToInches(margins.Right),
                ToInches(margins.Bottom),
                ToInches(paperSize.Height),
                ToInches(paperSize.Width));
        }

        private static string ToInches(int hundrethsOfInch)
        {
            double inches = hundrethsOfInch / 100.0;
            return inches.ToString(CultureInfo.InvariantCulture) + "in";
        }
    }
}


