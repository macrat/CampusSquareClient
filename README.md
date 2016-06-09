CampusSquareClient
==================

大学のCampus Squareで閲覧出来る成績情報をC#から取得するためのライブラリです。

## 使い方
GitHubの[リリースページ](https://github.com/macrat/CampusSquareClient/releases)から最新版の **CampusSquare.dll** をダウンロードしてください。

### VisualStudioの場合
TODO: あとで書く。

### monoの場合
ダウンロードしたDLLファイルをカレントディレクトリに置いて、引数に`/r:CampusSquare.dll`を渡してコンパイルしてください。

実際に実行すると以下のようになると思います。
``` bash
	$ mcs /r:CampusSquare.dll test.cs
```

実行時にDLLファイルが無いとエラーが発生するので注意してください。

## サンプル
### 取得出来た単位の一覧を表示する
``` cs
using System;
using CampusSquare;


class Test {
	public static void Main() {
		ICampusSquare cs = new CampusSquare.CampusSquare("学籍番号", "パスワード");  // サーバーに接続する。
		IEnumerable<IGrade> grades = cs.GetGrades();  // 全ての成績を取得する。

		foreach(IGrade grade in grades){
			if(grade.GradeNum > 0){  // GradeNumが0のときはD判定かX判定なので除外。
				Console.WriteLine(grade.Name);  // 講義の名前を表示する。
			}
		}
	}
}
```

### 2015年の後期の成績判定を表示する
``` cs
using System;
using CampusSquare;


class Test {
	public static void Main() {
		ICampusSquare cs = new CampusSquare.CampusSquare("学籍番号", "パスワード");
		IEnumerable<IGrade> grades = cs.GetGrades(2015, false);  // 2015年後期の成績を取得する。falseの代わりにtrueと書くと前期の成績を取得出来ます。

		foreach(IGrade grade in grades){
			Console.WriteLine(grade.Name + "の判定は" + grade.Grade + "でした。");
		}
	}
}
```

### 成績ページを保存したHTMLファイルからデータを読み込む
``` cs
using System;
using CampusSquare;


class Test {
	public static void Main() {
		ICampusSquare cs = new DummyCampusSquare("ここにファイル名.html");
		IEnumerable<IGrade> grades = cs.GetGrades();

		foreach(IGrade grade in grades){
			Console.WriteLine(grade.Name + ": " + grade.Grade);
		}
	}
}
```
