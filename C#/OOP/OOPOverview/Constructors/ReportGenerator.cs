namespace Constructors {
    public class ReportGenerator {
        public String ReportFormat { get; set; }
        public String SavedPath { get; set; }
        public String ReadingDataPath { get; set; }

        //public ReportGenerator() {
        //    ReportFormat = "Pdf";
        //}

        //public ReportGenerator(String reportFormat) {
        //    ReportFormat = reportFormat;
        //}

        public ReportGenerator(String readingPath) {
            ReadingDataPath = readingPath;
        }
    }
}