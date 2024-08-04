namespace LearningDesignPatterns.FactoryPattern
{
    public interface IReportGenerator
    {
        string GenerateReport();
    }

    public class XmlReportGenerator : IReportGenerator
    {
        public string GenerateReport() => "This is an generated Xml Report.";
    }

    public class CsvReportGenerator : IReportGenerator
    {
        public string GenerateReport() => "This is an generated Csv Report.";
    }
}
