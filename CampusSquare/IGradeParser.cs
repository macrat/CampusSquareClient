using System.Collections.Generic;


namespace CampusSquare {

interface IGradeParser {
   List<IGrade> Parse(string gradePage);
}

}
