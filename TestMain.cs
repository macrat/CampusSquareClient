using System;


class TestMain {
	public static void Main() {
		foreach(var x in (new GradeParser()).parse((new DebugCampusSquareClient("test.html")).getGradePage())){
			Console.WriteLine(x.getName() + "\t" + x.getGrade() + "*" + x.getCreditNum());
		}
	}
}
