namespace ExchangeOffice.DataAccess.Repositories.Abstractions {
	public abstract class BaseRepository {
		protected virtual void SetDefaultValues<T>(T entity) {
			if (typeof(T).GetProperty("Id") != null) {
				typeof(T).GetProperty("Id")?.SetValue(entity, Guid.NewGuid());
			}
			if (typeof(T).GetProperty("CreatedOn") != null) {
				typeof(T).GetProperty("CreatedOn")?.SetValue(entity, DateTime.UtcNow);
			}
			if (typeof(T).GetProperty("IsActive") != null) {
				typeof(T).GetProperty("IsActive")?.SetValue(entity, true);
			}
		}

		protected virtual void SetDeleteDefaultValues<T>(T entity) {
			if (typeof(T).GetProperty("ModifiedOn") != null) {
				typeof(T).GetProperty("ModifiedOn")?.SetValue(entity, DateTime.UtcNow);
			}
			if (typeof(T).GetProperty("IsActive") != null) {
				typeof(T).GetProperty("IsActive")?.SetValue(entity, false);
			}
		}
	}
}
