CampusSquareClient
==================

大学のCampus Squareで閲覧出来る成績情報をC#から取得するためのライブラリです。

# 使い方
取得出来た単位の一覧を表示するには以下のようにします。
``` cs
using System;
using CampusSquare;

class Test {
	public static void Main() {
		ICampusSquare cs = new CampusSquare("学籍番号", "パスワード");  // サーバーに接続する。
		IEnumerable<IGrade> grades = cs.GetGrades();  // 全ての成績を取得する。

		foreach(IGrade grade in grades){
			if(grade.Grade > 0){  // Gradeが0のときはD判定かX判定なので除外。
				Console.WriteLine(grade.Name);  // 講義の名前を表示する。
			}
		}
	}
}
```
