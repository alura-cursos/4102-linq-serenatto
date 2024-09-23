using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenattoEnsaio.Dados;
public class DadosFormaDePagamento
{
    public static List<string> FormasDePagamento = new List<string>
    {
        "crédito", "débito", "pix","dinheiro"
    };
}
