using NuGet.Protocol;
using TestWebApplication.Domain.Repositories.Abstract;

namespace TestWebApplication.Domain
{
	public class DataManager
	{
		IRepository Repository {  get; set; }
		ITextFieldRepository TextFieldRepository { get; set; }

		public DataManager(IRepository repository, ITextFieldRepository textFieldRepository)
		{
			Repository = repository;
			TextFieldRepository = textFieldRepository;
		}
	}
}
