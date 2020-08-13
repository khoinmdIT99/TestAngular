//James Trevithick          jtrevithick2@cnm.edu                TrevithickP4

using System.Collections.Generic;
using System.IO;


namespace TrevithickP4.Models
{
    class CsvReader
    {
        private List<string> lines;
        private string[] headers;
        public char Delimiter { get; set; }
        public CsvReader(TextReader textReader) {
            lines = new List<string>();
            Delimiter = '\t';
            headers = ((StreamReader)textReader).ReadLine().Split(Delimiter);
            while(!((StreamReader)textReader).EndOfStream)
            {
                lines.Add(((StreamReader)textReader).ReadLine());
            }
        }

        public List<Campaign> GetRecords()
        {
            List<Campaign> outPut = new List<Campaign>();
            foreach(string line in lines)
            {
                string[] columns = line.Split(Delimiter);
                outPut.Add(new Campaign { Vendor = columns[0],Candidate = columns[1],
                    Contributor = columns[2], Relationship = columns[3], Datetime = columns[4], Contribution = columns[5]
                });
            }
            return outPut;
        }
    }
}
