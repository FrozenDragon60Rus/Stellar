using Microsoft.EntityFrameworkCore;
using TestWebApplication.Domain.Entities;
using TestWebApplication.Domain.Repositories.Abstract;

namespace TestWebApplication.Domain.Repositories.EntityFramework
{
	public class EFTextFieldRepository(AppDbContext context) : ITextFieldRepository
	{
		private readonly AppDbContext context = context;

		public IQueryable<TextField> Get() =>
			context.TextFields;

		public TextField GetById(Guid id) =>
			context.TextFields.FirstOrDefault(x => x.Id == id);

		public TextField GetByCodeWord(string CodeWord) =>
			context.TextFields.FirstOrDefault(x => x.CodeWord == CodeWord);

		public void Save(TextField entity)
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
