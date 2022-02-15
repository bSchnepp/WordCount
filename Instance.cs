using System.Collections.Generic;

class Instance
{
	public Instance(string Words)
	{
		this.Words = Words;
		this.Count = new Dictionary<string, ulong>();
	}

	public void Parse()
	{
		/* With no argument, then this splits on whitespace. */
		string NewWords = this.Words.ToLower();

		/* Remove punctuation */
		NewWords.Replace(".", "");
		NewWords.Replace("!", "");
		NewWords.Replace("?", "");
		NewWords.Replace("\'", "");
		NewWords.Replace("\"", "");
		NewWords.Replace(";", "");
		NewWords.Replace(":", "");
		NewWords.Replace(")", "");
		NewWords.Replace("(", "");
		NewWords.Replace("[", "");
		NewWords.Replace("]", "");
		NewWords.Replace("{", "");
		NewWords.Replace("}", "");
		NewWords.Replace("@", "");
		NewWords.Replace("#", "");
		NewWords.Replace("$", "");
		NewWords.Replace("%%", "");
		NewWords.Replace("^", "");
		NewWords.Replace("&", "");
		NewWords.Replace("*", "");
		NewWords.Replace("-", "");
		NewWords.Replace("+", "");
		NewWords.Replace("=", "");
		NewWords.Replace("`", "");
		NewWords.Replace("~", "");
		NewWords.Replace("/", "");
		NewWords.Replace("\\", "");
		NewWords.Replace("<", "");
		NewWords.Replace(">", "");
		NewWords.Replace(",", "");
		NewWords.Replace("·", "");	/* What is this??? */

		string[] Values = this.Words.ToLower().Split();
		foreach (string Value in Values)
		{
			if (Count.ContainsKey(Value))
			{
				Count[Value]++;
			}
			else
			{
				if (Value.Trim().Length >= 1)
				{
					Count.Add(Value, 1);
				}
			}
		}
	}

	public void Print()
	{
		var List = this.Count.ToList();
		List.Sort((p1,p2) => p2.Value.CompareTo(p1.Value));
		foreach (var Pair in List)
		{
			Console.WriteLine("{0},{1}", Pair.Key, Pair.Value);
		}
	}

	public void Remove(string Term)
	{
		this.Count.Remove(Term.ToLower());
	}

	public void Remove(ulong Count)
	{
		foreach (var Pair in this.Count)
		{
			if (Pair.Value <= Count)
			{
				this.Count.Remove(Pair.Key);
			}
		}
	}

	public string Words
	{
		private set;
		get;
	}

	public Dictionary<string, ulong> Count
	{
		private set;
		get;
	}
};