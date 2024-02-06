using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain.Repositories.Abstract
{
	public interface IRepository
	{
		public interface IServiceItemRepository
		{
			IQueryable<Entity> Get();
			Entity GetById(Guid id);
			void Save(Entity entity);
			void Delete(Guid id);
		}
	}
}
