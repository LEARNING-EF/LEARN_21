namespace LEARNING_EF_CODE_FIRST
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			//System.Globalization.CultureInfo
			//	cultureInfo = new System.Globalization.CultureInfo("en-US");

			System.Globalization.CultureInfo
				cultureInfo = new System.Globalization.CultureInfo("fa-IR");

			System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
			System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

			// **************************************************
			createButton.Text = Resources.Buttons.Create;
			// **************************************************

			Models.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Models.DatabaseContext();

				Models.Person person = new Models.Person();

				person.Age = 20;
				person.FullName = "آب";
				person.EmailAddress = "DariushT";

				var errors =
					Models.Utility.CheckEntityValidation(databaseContext, person);

				if (errors.Count == 0)
				{
					databaseContext.People.Add(person);

					databaseContext.SaveChanges();
				}
				else
				{
					foreach (var error in errors)
					{
						System.Windows.Forms.MessageBox.Show(error.ErrorMessage);
					}
				}
			}
			catch (System.Exception ex)
			{
				Dtx.SemiLogHandler.Log(ex);

				System.Windows.Forms.MessageBox.Show("Unexpected Error!");
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}
	}
}
