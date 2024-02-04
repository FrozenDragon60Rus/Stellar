using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain.Repositories.Abstract
{
	public interface IRepository
	{
		IQueryable<ServiceItem> GetServiceFields();
		ServiceItem GetServiceFieldById(Guid id);
		void SaveServiceField(ServiceItem entity);
		void DeleteSeriveField(Guid id);
	}
}
