using System.Collections.Generic;


namespace CampusSquare {

interface IGradeParser {
	IEnumerable<IGrade> Parse(string gradePage);
}

}
