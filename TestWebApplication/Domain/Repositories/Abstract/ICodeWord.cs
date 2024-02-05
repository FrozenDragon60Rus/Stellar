using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain.Repositories.Abstract
{
	public interface ICodeWord
	{
		TextField GetByCodeWord(string codeWord);
	}
}
