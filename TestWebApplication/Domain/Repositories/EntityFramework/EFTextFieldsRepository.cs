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

		public IQueryable<TextField> GetTextFields() =>
			context.TextFields;
	}
}
