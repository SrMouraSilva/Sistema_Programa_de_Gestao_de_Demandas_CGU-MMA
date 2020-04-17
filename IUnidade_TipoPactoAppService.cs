using PGD.Application.ViewModels;
using PGD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Application.Interfaces
{
    public interface IUnidade_TipoPactoAppService
    {
        Unidade_TipoPactoViewModel Adicionar(Unidade_TipoPactoViewModel unidade_tipoPactoViewModel, UsuarioViewModel user);
        IEnumerable<Unidade_TipoPactoViewModel> ObterTodos();
        Unidade_TipoPactoViewModel BuscarPorIdUnidadeTipoPacto(int idUnidade, int idTipoPacto);        
        Unidade_TipoPactoViewModel Atualizar(Unidade_TipoPactoViewModel unidade_tipoPactoViewModel, UsuarioViewModel user);
        void Remover(int id, UsuarioViewModel user);        
    }
}
