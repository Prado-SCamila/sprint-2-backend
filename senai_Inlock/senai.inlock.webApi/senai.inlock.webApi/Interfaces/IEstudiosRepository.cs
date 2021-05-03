using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudiosRepository
    {
        void Cadastrar(EstudiosDomain novoEstudio);

        //READ
        List<EstudiosDomain> ListarTodos();

        EstudiosDomain BuscarPorId(int id);

        //UPDATE
        void AtualizarIdCorpo(EstudiosDomain estudio);

        void AtualizarIdUrl(int id, EstudiosDomain estudio);

        //DELETE
        void Deletar(int id);
    }
}
