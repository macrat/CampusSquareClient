CampusSquareClient
==================

大学のCampus Squareで閲覧出来る成績情報をC#から取得するためのライブラリです。

## 使い方
### プログラムを書く
CampusSquareライブラリを使うために、ソースコードの一番上に以下のような記述を追加してください。
``` cs
using System;
using System.Collections.Generic;
using CampusSquare;
```

`CampusSquare.CampusSquare`というクラスで、CampusSquareのサーバーに接続することが出来ます。
サーバーへの接続は以下のように行ないます。
``` cs
ICampusSquare cs = new CampusSquare.CampusSquare("ID", "パスワード");
```
IDとパスワードは自分のものに置き換えてください。

ローカルにあるHTMLファイルから情報を読みたい場合は、`CampusSquare.DummyCampusSquare`を使うことが出来ます。
こちらは以下のようにして読み込みます。
``` cs
ICampusSquare cs = new CampusSquare.DummyCampusSquare("ファイル名.html");
```

成績の取得は以下のようにして行ないます。
``` cs
IEnumerable<IGrade> grades = cs.GetGrades();
```
この場合、今までの全ての成績の情報が含まれます。

成績データを見るには、以下のようにします。
``` cs
foreach(IGrade grade in grades){
	Console.PrintLine(grade.Name);  // 講義の名前
	Console.PrintLine(grade.Grade);  // 成績
	Console.PrintLine(grade.GradeNum);  // 成績を数字で表したもの
	Console.PrintLine(grade.CreditNum);  // 取得出来る単位数
}
```

### コンパイルする
GitHubの[リリースページ](https://github.com/macrat/CampusSquareClient/releases)から最新版の **CampusSquare.dll** をダウンロードしてください。

#### VisualStudioの場合
ソリューションエクスプローラにてプロジェクトを選択します。
次に「プロジェクト」の「参照の追加」をクリックします。
すると「参照の追加」ダイアログが開かれるので参照タブを開き、CampusSquare.dllを追加しチェックされていること確認してからOKを押します。
参照の追加に成功するとソリューションエクスプローラーの参照のツリーにCampusSquare.dllが追加されています。

#### monoの場合
ダウンロードしたDLLファイルをカレントディレクトリに置いて、引数に`/r:CampusSquare.dll`を渡してコンパイルしてください。

実際に実行すると以下のようになると思います。
``` bash
$ mcs /r:CampusSquare.dll test.cs
```

プログラムの実行は以下のようになります。
実行時にカレントディレクトリにDLLファイルが無いとエラーが発生するので注意してください。
``` bash
$ mono test.exe
```

## サンプル
### 取得出来た単位の一覧を表示する
``` cs
using System;
using System.Collections.Generic;
using CampusSquare;


class Test {
	public static void Main() {
		ICampusSquare cs = new CampusSquare.CampusSquare("ID", "パスワード");  // サーバーに接続する。
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
using System.Collections.Generic;
using CampusSquare;


class Test {
	public static void Main() {
		ICampusSquare cs = new CampusSquare.CampusSquare("ID", "パスワード");
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
using System.Collections.Generic;
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
