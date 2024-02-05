using Microsoft.EntityFrameworkCore;
using TestWebApplication.Domain;
using TestWebApplication.Domain.Repositories.Abstract;
using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain.Repositories.EntityFramework
{
	public class EFTextFieldsRepository : IRepository, ICodeWord
	{
		private readonly AppDbContext context;
		public EFTextFieldsRepository(AppDbContext context) =>
			this.context = context;

		public IQueryable<Entity> Get() =>
			context.TextFields;

		public Entity GetById(Guid id) =>
			context.TextFields.FirstOrDefault(x => x.Id == id);

		public TextField GetByCodeWord(string CodeWord) =>
			context.TextFields.FirstOrDefault(x => x.CodeWord == CodeWord);

		public void Save(Entity entity)
		{
			if(entity.Id == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}
		public void Delete(Guid id)
		{
			context.TextFields.Remove(new TextField() { Id = id });
			context.SaveChanges();
		}
	}
}
