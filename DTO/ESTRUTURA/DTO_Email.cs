using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Email
    {
        public int ID { get; set; }

        public DateTime Data { get; set; }

        private string para;
        public string Para
        {
            get
            {
                if (para == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(para);
            }

            set { para = value; }
        }

        private string cc;
        public string CC
        {
            get
            {
                if (cc == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cc);
            }

            set { cc = value; }
        }

        private string cco;
        public string CCO
        {
            get
            {
                if (cco == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cco);
            }

            set { cco = value; }
        }

        private string assunto;
        public string Assunto
        {
            get
            {
                if (assunto == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(assunto);
            }

            set { assunto = value; }
        }

        private string conteudo;
        public string Conteudo
        {
            get
            {
                if (conteudo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(conteudo);
            }

            set { conteudo = value; }
        }

        private string anexo;
        public string Anexo
        {
            get
            {
                if (anexo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(anexo);
            }

            set { anexo = value; }
        }

        private DTO_Data consulta_data;
        public DTO_Data Consulta_Data
        {
            get
            {
                if (consulta_data == null)
                {
                    consulta_data = new DTO_Data();
                    return consulta_data;
                }
                else
                    return consulta_data;
            }
            set
            {
                consulta_data = new DTO_Data();
                consulta_data = value;
            }
        }
    }
}
