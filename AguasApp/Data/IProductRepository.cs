using AguasApp.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AguasApp.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IQueryable GetAllWithUsers(); // Passo 47: inserir o metodo criado na classe do repositorio ca na interface


        // Metodo para mostrar a combobox e os produtos disponivel numa combox---> CREATE
        IEnumerable<SelectListItem> GetComboProducts();

    }
}
