using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class DepartamentoAcesso
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public int Programa { get; set; }
        public bool Acesso { get; set; }
        public bool Incluir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }

        [NotMapped]
        public string DescricaoPrograma {
            get
            {
                switch(Programa)
                {
                    case 1:
                        return "Chamados";
                    case 2:
                        return "Visitas";
                    case 3:
                        return "Solicitações";
                    case 4:
                        return "Versões";
                    case 6:
                        return "Base Conh.";
                    case 100:
                        return "Revendas";
                    case 101:
                        return "Produtos";
                    case 102:
                        return "Módulos";
                    case 103:
                        return "Clientes";
                    case 104:
                        return "Usuários";
                    case 105:
                        return "Departamentos";
                    case 106:
                        return "Tipos";
                    case 107:
                        return "Status";
                    case 108:
                        return "Especifiações";
                    case 109:
                        return "Parâmetros";
                    case 110:
                        return "Contas Email";
                    case 111:
                        return "Atividades";
                    case 112:
                        return "Agendamentos";
                    case 114:
                        return "Orçamentos";
                    case 115:
                        return "Formas de Pagamentos";
                    case 116:
                        return "Observações";
                    case 117:
                        return "Modelos Relatórios";
                    case 118:
                        return "Ramais";
                    case 119:
                        return "Recados";
                    case 120:
                        return "Escalas";
                    case 121:
                        return "Cidades";
                    case 122:
                        return "Licenças";
                    case 123:
                        return "Feriados";
                    case 124:
                        return "Categorias";
                    case 125:
                        return "Tabela de Preços";
                    default:
                        return "";
                };

                //if (Programa == 1)
                //    return "Chamado";
                //else if (Programa == 2)
                //    return "Visita";
                //else
                //    return "";
            }
        }

        public virtual Departamento Departamento { get; set; }
    }
}
