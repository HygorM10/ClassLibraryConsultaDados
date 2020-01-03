using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDadosAPI
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class AtividadePrincipal
    {
        public string text { get; set; }
        public string code { get; set; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Qsa
    {
        public string qual { get; set; }
        public string nome { get; set; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class AtividadesSecundaria
    {
        public string code { get; set; }
        public string text { get; set; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Extra
    {
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Billing
    {
        public bool free { get; set; }
        public bool database { get; set; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class DadosCNPJ
    {
        public List<AtividadePrincipal> atividade_principal { get; set; }
        public string data_situacao { get; set; }
        public string complemento { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        [ComVisible(true)]
        public List<Qsa> qsa { get; set; }
        public string situacao { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string municipio { get; set; }
        public string porte { get; set; }
        public string abertura { get; set; }
        public string natureza_juridica { get; set; }
        public string fantasia { get; set; }
        public string cnpj { get; set; }
        public DateTime ultima_atualizacao { get; set; }
        public string status { get; set; }
        public string tipo { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string efr { get; set; }
        public string motivo_situacao { get; set; }
        public string situacao_especial { get; set; }
        public string data_situacao_especial { get; set; }
        [ComVisible(true)]
        public List<AtividadesSecundaria> atividades_secundarias { get; set; }
        public string capital_social { get; set; }
        [ComVisible(true)]
        public Extra extra { get; set; }
        [ComVisible(true)]
        public Billing billing { get; set; }
        public string objeto_social
        {
            get
            {
                return string.Join("\n", this.atividade_principal.Where(p => !p.text.ToLower().Contains("não informada"))
                        .Select(s => s.text)) +
                            "\n" +
                        string.Join("\n", this.atividades_secundarias.Where(p => !p.text.ToLower().Contains("não informada"))
                            .Select(s => s.text));
            }
        }
    }
}
