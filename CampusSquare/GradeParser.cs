using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CampusSquare {

class GradeParser : IGradeParser {
	public List<IGrade> Parse(string gradePage) {
		List<IGrade> result = new List<IGrade>();

		var dat = (new Regex("<tbody>.+?</tbody>", RegexOptions.Singleline)).Matches(gradePage)[1].Value;
		var doc = XDocument.Parse(dat);
		foreach(var x in doc.Descendants("tbody").Elements()){
			var elm = x.Elements();
			result.Add(new CreditGrade(
				elm.ElementAt(4).Value.Trim(),
				GradeToInteger(elm.ElementAt(8).Value.Trim()),
				(int)float.Parse(elm.ElementAt(5).Value.Trim())
			));
		}

		return result;
	}

	private static int GradeToInteger(string grade) {
		var dic = new Dictionary<string, int>(){
			{"S", 4},
			{"A", 3},
			{"B", 2},
			{"C", 1},
			{"D", 0},
			{"X", 0},
		};
		return dic[grade];
	}
}

}
