using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain.Repositories.Abstract
{
	public interface ITextFieldRepository
	{
		IQueryable<TextField> Get();
		TextField GetById(Guid id);
		TextField GetByCodeWord(string codeWord);
		void Save(TextField entity);
		void Delete(Guid id);
	}
}
