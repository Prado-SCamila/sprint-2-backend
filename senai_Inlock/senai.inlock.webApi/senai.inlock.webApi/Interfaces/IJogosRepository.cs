using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogosRepository
    {
        // CRUD - método Cadastrar
        //CREATE
       
        void Cadastrar(JogosDomain novoJogo);

        //READ
        List<JogosDomain> ListarTodos();

        JogosDomain BuscarPorId(int id);

        //UPDATE
        void AtualizarIdCorpo(JogosDomain jogo);

        void AtualizarIdUrl(int id, JogosDomain jogo);

        //DELETE
        void Deletar(int id);
    }
}
