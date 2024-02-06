using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain.Repositories.Abstract
{
	public interface ITextFieldRepository : IRepository
	{
		IQueryable<Entity> Get();
		TextField GetByCodeWord(string codeWord);
		Entity GetById(Guid id);
		void Save(Entity entity);
		void Delete(Guid id);
	}
}
