using System;
using CampusSquare;


class TestMain {
	public static void Main() {
		foreach(var x in (new GradeParser()).Parse((new FileCampusSquareClient("test.html")).GetGradePage())){
			Console.WriteLine(x.Name + "\t" + x.Grade + "(" + x.GradeNum + ")*" + x.CreditNum);
		}
	}
}
