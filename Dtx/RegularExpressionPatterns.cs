namespace Dtx
{
	public static class RegularExpressionPatterns
	{
		static RegularExpressionPatterns()
		{
		}

		public const string EmailAddress = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
	}
}
