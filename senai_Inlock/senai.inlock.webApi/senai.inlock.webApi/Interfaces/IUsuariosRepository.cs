using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuariosRepository
    {
        void Cadastrar(UsuariosDomain novoUsuario);

        //READ
        List<UsuariosDomain> ListarTodos();

        UsuariosDomain BuscarPorId(int id);

        //UPDATE
        void AtualizarIdCorpo(UsuariosDomain usuario);

        void AtualizarIdUrl(int id, UsuariosDomain jogo);

        //DELETE
        void Deletar(int id);
    }
}
