using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using Sistema.UTIL;
using System.Data.SqlClient;


namespace Sistema.UI
{
    public partial class UI_Visualiza_Relatorio : Form
    {
        public UI_Visualiza_Relatorio()
        {
            InitializeComponent();
        }

        SqlConnection sqlConn = new SqlConnection("Data Source=" + SQL.Servidor + ";Initial Catalog=" + SQL.Banco + ";Persist Security Info=True;User ID=sa;Password=" + SQL.Senha);

        public string Sql_Relatorio = ""; // SQL Para relatorio
        public string  Arquivo_rdlc = ""; // Rpv_Funcionario_Lista.rdlc
        public string Dataset_Relatorio = ""; // DataSet_Funcionario_Lista


        private void relatorio_Fernando()
        {
          
            SqlCommand MeuComando = sqlConn.CreateCommand();
            SqlDataAdapter DataAdapterProduto = new SqlDataAdapter();
            DataSet DataSetProduto = new DataSet();
            SqlDataReader DataReaderEmpr;
            DataTable MinhaDataTable = new DataTable();

          //  rpt_Viewer.LocalReport.ReportPath = @"" + diretorio + Arquivo_rdlc;


            MeuComando.Connection = sqlConn;
            MeuComando.CommandText = Sql_Relatorio;
            MeuComando.CommandType = CommandType.Text;

            sqlConn.Open();

            DataReaderEmpr = MeuComando.ExecuteReader();

            MinhaDataTable.Load(DataReaderEmpr);

            ReportDataSource MyReportDataSoucer = new ReportDataSource(Dataset_Relatorio, MinhaDataTable);

            rpt_Viewer.Clear();

            rpt_Viewer.LocalReport.DataSources.Add(MyReportDataSoucer);

            rpt_Viewer.RefreshReport();

            DataReaderEmpr.Close();

            sqlConn.Close();

            this.rpt_Viewer.RefreshReport();
            this.rpt_Viewer.RefreshReport();

        }
        #region ROTINAS
        private void Inicia_Form()
        {
            this.rpt_Viewer.RefreshReport();
            this.rpt_Viewer.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpt_Viewer.ZoomMode = ZoomMode.PageWidth;
        }

        private void Exporta_Report(string _Extensao)
        {
            RenderingExtension Extensao_Arquivo = null;
            string ext = string.Empty;
            switch (_Extensao)
            {
                case "PDF":
                    Extensao_Arquivo = rpt_Viewer.LocalReport.ListRenderingExtensions()[3];
                    ext = ".pdf";
                    break;
                case "CSV":
                    ext = ".csv";
                    break;
                case "XLSX":
                    Extensao_Arquivo = rpt_Viewer.LocalReport.ListRenderingExtensions()[1];
                    ext = ".xlsx";
                    break;
                case "MHTML":
                    ext = ".mhtml";
                    break;
                case "IMAGE":
                    ext = ".tif";
                    break;
                case "XML":
                    ext = ".xml";
                    break;
                case "DOCX":
                    Extensao_Arquivo = rpt_Viewer.LocalReport.ListRenderingExtensions()[5];
                    ext = ".docx";
                    break;
                case "HTML4.0":
                    ext = ".html";
                    break;
            }

            string _Ext = "*" + _Extensao.ToUpper() + " files (*." + _Extensao.ToLower() + ")|*." + _Extensao.ToLower();

            SaveFileDialog Arquivo = new SaveFileDialog();
            Arquivo.Filter = _Ext;
            Arquivo.FilterIndex = 2;
            Arquivo.RestoreDirectory = true;

            DialogResult msgbox = MessageBox.Show(util_msg.msg_VisualizarArquivo, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
            {
                Arquivo.FileName = Parametro_Sistema.Caminho_Sistema + @"Temp\" + Path.GetFileName(rpt_Viewer.LocalReport.ReportPath).Replace(".rdlc", "") + "_" + DateTime.Now.ToShortDateString().Replace(@"/", "").Replace(":", "") + DateTime.Now.Millisecond.ToString() + "." + _Extensao.ToLower();

                rpt_Viewer.ExportDialog(Extensao_Arquivo, "", Arquivo.FileName);

                System.Diagnostics.Process.Start(Arquivo.FileName);
            }
            else
            {
                Arquivo.FileName = Path.GetFileName(rpt_Viewer.LocalReport.ReportPath).Replace(".rdlc", "");

                if (Arquivo.ShowDialog() == DialogResult.OK)
                    rpt_Viewer.ExportDialog(Extensao_Arquivo, "", Arquivo.FileName);
            }
        }

        private void Envia_Email()
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = rpt_Viewer.LocalReport.Render("Pdf", null, out mimeType, out encoding, out extension, out streamids, out warnings);

            string NomeArquivo = "report";

            //if (NomeArquivo.Length > 20)
            //    NomeArquivo = NomeArquivo.Substring(0, 20);
            //

            // NomeArquivo = CaminhoArquivo + NomeArquivo + ".pdf";

            int aux = 0;

            DirectoryInfo Dir = new DirectoryInfo(Parametro_Sistema.Caminho_Sistema + @"Temp\");
            FileInfo[] Files = Dir.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);
            foreach (FileInfo File in Files)
            {
                // Retira o diretório iformado inicialmente
                string FileName = File.FullName.Replace(Dir.FullName, "");
                if (FileName.IndexOf(NomeArquivo) != -1)
                    aux++;
            }

            if (aux == 0)
                NomeArquivo = Parametro_Sistema.Caminho_Sistema + @"Temp\" + NomeArquivo + ".pdf";
            else
                NomeArquivo = Parametro_Sistema.Caminho_Sistema + @"Temp\" + NomeArquivo + "(" + aux + ").pdf";

            FileStream fs = new FileStream(NomeArquivo, FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();


            UI_Email UI_Email = new UI_Email();
            UI_Email.Endereco = "";
            UI_Email.Anexo = NomeArquivo;
            UI_Email.WindowState = FormWindowState.Normal;
            UI_Email.ShowDialog();

            //util_dados.CarregaForm(UI_Email, this.MdiParent);
        }
        #endregion

        #region FORM
        private void UI_Visualiza_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            try
            {
                relatorio_Fernando();

            }
            catch (Exception)
            {

             
            }
        }

        private void UI_Visualiza_Relatorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void UI_Visualiza_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
                this.rpt_Viewer.PrintDialog();
        }
        #endregion

        #region BUTTON
        private void bt_Imprimir_Click(object sender, EventArgs e)
        {
            rpt_Viewer.PrintDialog();
        }

        private void bt_Exporta_PDF_Click(object sender, EventArgs e)
        {
            Exporta_Report("PDF");
        }

        private void bt_Exporta_DOC_Click(object sender, EventArgs e)
        {
            Exporta_Report("DOCX");
        }

        private void bt_Exporta_XLS_Click(object sender, EventArgs e)
        {
            Exporta_Report("XLSX");
        }

        private void bt_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Email_Click(object sender, EventArgs e)
        {
            Envia_Email();
        }
        #endregion
    }
}
