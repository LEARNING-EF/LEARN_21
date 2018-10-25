namespace Dtx
{
	public static class SemiLogHandler
	{
		static SemiLogHandler()
		{
		}

		public static void Log(System.Exception ex)
		{
			string tab = "\t";
			string tabs = tab;
			System.Exception exception = ex;

			string errorMessage =
				System.Environment.NewLine + System.Environment.NewLine + "***** BEGIN *****";

			while (exception != null)
			{
				errorMessage +=
					System.Environment.NewLine + exception.Message;

				System.Data.Entity.Validation.DbEntityValidationException
					dbEntityValidationException = exception as System.Data.Entity.Validation.DbEntityValidationException;

				if (dbEntityValidationException != null)
				{
					errorMessage += System.Environment.NewLine;

					foreach (var varEntityValidationError in dbEntityValidationException.EntityValidationErrors)
					{
						errorMessage +=
							System.Environment.NewLine + tabs +
							string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
							varEntityValidationError.Entry.Entity.GetType().Name, varEntityValidationError.Entry.State);

						foreach (var validationError in varEntityValidationError.ValidationErrors)
						{
							errorMessage +=
								System.Environment.NewLine + tabs + tab +
								string.Format("- Property: \"{0}\", Error: \"{1}\"",
								validationError.PropertyName, validationError.ErrorMessage);
						}
					}
				}

				tabs += tab;
				exception = exception.InnerException;
			}

			errorMessage += System.Environment.NewLine + "***** END *****";

			string pathName = "Application.log";

			System.IO.StreamWriter stream = null;

			try
			{
				stream =
					new System.IO.StreamWriter
						(pathName, true, System.Text.Encoding.UTF8);

				stream.WriteLine(errorMessage);

				stream.Close();
			}
			catch
			{
			}
			finally
			{
				if (stream != null)
				{
					stream.Dispose();
					stream = null;
				}
			}
		}
	}
}
