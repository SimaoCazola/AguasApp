using System.Linq;
using System.Threading.Tasks;

namespace AguasApp.Data
{
    public interface IGenericRepository<T> where T : class
    {
        //1.GET: Metodo que Mostra todos os Ts
        IQueryable<T> GetAll();

        //2. GET: Metodo que mostra um T, exemplo os DETALHES que mostra uma unica coisa, tem que ter o ID
        Task<T> GetByIdAsync(int Id);

        //3. POST: "Create" Metodo que adiciona o T, é async porque vai guardar na base de dados
        Task CreateAsync(T entity);

        //4. POST: Metodo que edita ou modifica o T,é async porque vai guardar na base de dados
        Task UpdateAsync(T entity);

        //5. POST: Metodo que apaga o T, é async porque vai guardar na base de dados
        Task DeleteAsync(T entity);

        //6. POST: Metodo que verifica se o T existe, é async porque vai guardar na base de dados
        Task<bool> ExistAsync(int id);

    }
}
