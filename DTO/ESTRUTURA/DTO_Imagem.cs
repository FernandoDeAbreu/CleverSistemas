using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sistema.DTO
{
   public class DTO_Imagem
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int Tipo { get; set; }
        public FileStream Imagem { get; set; }
        public object ArqByteArray { get; set; }
    }
}
