using Microsoft.EntityFrameworkCore;
using TestWebApplication.Domain;
using TestWebApplication.Domain.Repositories.Abstract;
using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain.Repositories.EntityFramework
{
	public class EFRepository : ITextFieldRepository
	{
		private readonly AppDbContext context;
		public EFRepository(AppDbContext context) =>
			this.context = context;

		public IQueryable<Entity> Get() =>
			context.ServiceItems;

		public Entity GetById(Guid id) =>
			context.ServiceItems.FirstOrDefault(x => x.Id == id);

		public TextField GetByCodeWord(string CodeWord) =>
			context.TextFields.FirstOrDefault(x => x.CodeWord == CodeWord);

		public void Save(Entity entity)
		{
			if (entity.Id == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}
		public void Delete(Guid id)
		{
			context.ServiceItems.Remove(new TextField() { Id = id });
			context.SaveChanges();
		}
	}
}
