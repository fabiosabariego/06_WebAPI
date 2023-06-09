﻿using Fiap.Api.AspNet5.Models;

namespace Fiap.Api.AspNet5.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public IList<UsuarioModel> FindAll();
        public UsuarioModel FindById(int id);
        public UsuarioModel FindByName(string name);
        public int Insert(UsuarioModel usuarioModel);
        public void Delete(int id);
        public void Update(UsuarioModel usuarioModel);

    }
}
