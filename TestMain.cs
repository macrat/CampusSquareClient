using System;
using CampusSquare;


class TestMain {
	public static void Main() {
		ICampusSquare cs = new DummyCampusSquare("test.html");
		foreach(var x in cs.GetGrades()){
			Console.WriteLine(x.Name + "\t" + x.Grade + "(" + x.GradeNum + ")*" + x.CreditNum);
		}
	}
}
