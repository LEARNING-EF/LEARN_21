namespace Models
{
	public class Person : BaseEntity
	{
		public Person() : base()
		{
		}

		// **********
		//[System.ComponentModel.DataAnnotations.Display
		//	(Name = "Age")]

		//[System.ComponentModel.DataAnnotations.Display
		//	(Name = "سن")]

		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.Models.Person),
		//	Name = "Age")]

		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.Models.Person),
		//	Name = nameof(Age))]

		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.Person),
			Name = nameof(Resources.Models.Person.Age))]

		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.Models.Person),
		//	Name = Resources.Models.Strings.PersonKeys.Age)]

		[System.ComponentModel.DataAnnotations.Range
			(typeof(int), "25", "35",
			ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = Resources.Strings.MessagesKeys.RangeErrorMessage)]
		public int Age { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.General),
			Name = Resources.Models.Strings.GeneralKeys.FullName)]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = Resources.Strings.MessagesKeys.RequredErrorMessage)]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 50, MinimumLength = 3,
			ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = Resources.Strings.MessagesKeys.StringLengthErrorMessage)]
		public string FullName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.General),
			Name = Resources.Models.Strings.GeneralKeys.EmailAddress)]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Dtx.RegularExpressionPatterns.EmailAddress,
			ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = Resources.Strings.MessagesKeys.RegularExpressionErrorMessage)]
		public string EmailAddress { get; set; }
		// **********
	}
}
