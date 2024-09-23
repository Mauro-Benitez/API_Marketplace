﻿using API_Marketplace.Domain.Entities;
using API_Marketplace.Infraestructure.DataBase;

namespace API_Marketplace.Infraestructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SQLContext _context;

        public UsuarioRepository(SQLContext context)
        {
            _context = context;
        }

        public Usuario NovoUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();

            return usuario;
           
        }
    }
}
