namespace Models
{
	internal class DatabaseContextInitializer :
		System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
	{
		public DatabaseContextInitializer()
		{
		}

		protected override void Seed(DatabaseContext databaseContext)
		{
		}
	}
}
