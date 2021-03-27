using senai_Peoples_WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Peoples_WebApi.Interface
{
    public interface IFuncionariosRepository 
    {
        ///<summary>
        ///Estou declarando os métodos que serão usados mencionando o tipo deles e o parametro que serao usados
        /// </summary>
        /// 
        //Listar
        List<FuncionariosDomain> ListarTodos();

        FuncionariosDomain BuscarPorId(int id);

        void Cadastrar(FuncionariosDomain funcionario);

        void AtualizarIdCorpo(FuncionariosDomain funcionario);

        void AtualizarIdUrl(int id, FuncionariosDomain funcionario);

        void Delete(int id);
    }
}
