﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoLibreria.Models;

namespace ProyectoLibreria.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly LibreriaContext _context;
        public ServicioLista(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetListaAutores()
        {
            List<SelectListItem> lista = await _context.Autores.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            lista.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un autor...]",
                Value = "0"
            });
            return lista;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaCategorias()
        {
            List<SelectListItem> list = await _context.Categorias.Select(x => new SelectListItem
            {
                Text = x.Nombre, 
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una categoría...]",
                Value = "0"
            });
            return list;
        }
    }
}
