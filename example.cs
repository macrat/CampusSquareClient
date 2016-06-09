using System;
using CampusSquare;


class Example {
	public static void Main() {
		Console.Write("ID: ");
		string id = Console.ReadLine();
		Console.Write("password: ");
		string password = ReadPassword();
		Console.WriteLine();

		ICampusSquare cs = new CampusSquare.CampusSquare(id, password);
		foreach(var x in cs.GetGrades()){
			Console.WriteLine(x.Name + "\t" + x.Grade + "(" + x.GradeNum + ")*" + x.CreditNum);
		}
	}

	private static string ReadPassword() {
		var pwd = "";

		while(true){
			ConsoleKeyInfo k = Console.ReadKey(true);
			if(k.Key == ConsoleKey.Enter){
				break;
			}else if(k.Key == ConsoleKey.Backspace){
				if(pwd.Length > 0){
					Console.Write("\b \b");
					pwd = pwd.Remove(pwd.Length - 1);
				}
			}else{
				pwd += k.KeyChar;
				Console.Write("*");
			}
		}

		return pwd;
	}
}
