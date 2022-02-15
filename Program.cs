using System.IO;
using System.Text;

class Program
{
	static void RunInstance(string Words, ulong TrimCount)
	{
		Instance Inst = new Instance(Words);
		Inst.Parse();

		/* Remove articles */
		Inst.Remove("the");
		Inst.Remove("a");
		Inst.Remove("an");

		/* Remove prepositions */
		Inst.Remove("of");
		Inst.Remove("to");
		Inst.Remove("with");
		Inst.Remove("or");
		Inst.Remove("in");
		Inst.Remove("is");
		Inst.Remove("for");
		Inst.Remove("and");
		Inst.Remove("be");
		Inst.Remove("on");
		Inst.Remove("by");
		Inst.Remove("at");

		/* Also some annoying verbs */
		Inst.Remove("as");
		Inst.Remove("are");
		Inst.Remove("is");

		/* Get rid of pronouns while we're at it. */
		Inst.Remove("we");
		Inst.Remove("were");
		Inst.Remove("our");
		Inst.Remove("your");
		Inst.Remove("us");
		Inst.Remove("you");
		Inst.Remove("i");
		Inst.Remove("it");	/* Will probably conflict with "IT". Oops. */


		Inst.Remove("this");
		Inst.Remove("that");
		Inst.Remove("who");
		Inst.Remove("these");
		Inst.Remove("those");
		Inst.Remove("their");
		Inst.Remove("theyre");
		Inst.Remove("there");
		Inst.Remove("any");
		Inst.Remove("all");
		Inst.Remove("each");
		Inst.Remove("some");
		Inst.Remove("none");

		/* Anything TrimCount and lower we don't care about. */
		Inst.Remove(TrimCount);
		Inst.Print();
	}

	public static void Main(string[] argv)
	{
		string Location = "q";
		ulong TrimCount = 1;
		if (argv.Length >= 1)
		{
			Location = argv[0];
		}

		if (argv.Length >= 2)
		{
			if (ulong.TryParse(argv[1], out TrimCount) == false)
			{
				TrimCount = 1;
			}
		}

		Console.WriteLine("Reading location: {0}, trim results below {1}", Location, TrimCount);

		StringBuilder Builder = new StringBuilder();

		try
		{
			using StreamReader Stream = new StreamReader(Location);
			string? Line = "";
			for (;;)
			{
				Line = Stream.ReadLine();
				if (Line == null)
				{
					break;
				}

				Builder.AppendLine(Line);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		RunInstance(Builder.ToString(), TrimCount);
	}	
}