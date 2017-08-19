using System;
using System.Data;
using RAR.Framework.Customization.Data;

namespace RAR.Framework.Database.TestingTools.Entities
{
    [DbTable("fat_consu")]
    public class Usuario
    {
        [DbColumn("cns_codconsu", DbType.Int32, IsPK = true, IgnoreZeroValue = true)]
        public Int32 Codigo { get; set; }

        [DbColumn("cns_login", DbType.StringFixedLength, IsPK = true)]
        public String Login { get; set; }

        [DbColumn("cns_nome", DbType.StringFixedLength)]
        public String Nome { get; set; }

        [DbColumn("cns_sobrenome", DbType.StringFixedLength)]
        public String Sobrenome { get; set; }

        [DbColumn("cns_senha", DbType.StringFixedLength)]
        public String Senha { get; set; }

        [DbColumn("cns_cpf", DbType.StringFixedLength, IsPK = true)]
        public String CPF { get; set; }

        [DbColumn("cns_sexo", DbType.StringFixedLength)]
        public String Sexo { get; set; }

        [DbColumn("cns_telefone", DbType.StringFixedLength)]
        public String Telefone { get; set; }

        [DbColumn("cns_celular", DbType.StringFixedLength)]
        public String Celular { get; set; }

        [DbColumn("cns_rg", DbType.StringFixedLength)]
        public String RG { get; set; }
    }
}