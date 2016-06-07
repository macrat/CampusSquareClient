using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CampusSquare {

class GradeParser : IGradeParser {
	public IEnumerable<IGrade> Parse(string gradePage) {
		var tbody = (new Regex("<tbody>.+?</tbody>", RegexOptions.Singleline)).Matches(gradePage)[1].Value;
		return XDocument.Parse(tbody).Descendants("tr").Select(TableLineToGrade);
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

	private static IGrade TableLineToGrade(XElement tr) {
		var elms = tr.Elements();
		return new CreditGrade(
			elms.ElementAt(4).Value.Trim(),
			GradeToInteger(elms.ElementAt(8).Value.Trim()),
			(int)float.Parse(elms.ElementAt(5).Value.Trim())
		);
	}
}

}
