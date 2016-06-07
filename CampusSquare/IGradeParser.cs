using System.Collections.Generic;


interface IGradeParser {
   List<IGrade> parse(string gradePage);
}
