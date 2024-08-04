using Microsoft.Extensions.DependencyInjection;

namespace LearningDesignPatterns.FactoryPattern
{
    public interface IReportGeneratorFactory
    {
        IReportGenerator GetReportGenerator(string formatType);
    }

    public class ReportGeneratorFactory: IReportGeneratorFactory 
    { 
        public IReportGenerator GetReportGenerator(string formatType)
        {
            return formatType.ToLower() switch
            {
                "xml" => new XmlReportGenerator(),
                "csv" => new CsvReportGenerator(),
                _ => throw new NotImplementedException(),
            } ;
        }
    }

    public interface IReportGeneratorFactory2
    {
        IReportGenerator GetReportGenerator(string formatType);
    }


    /// <summary>
    /// This below approach always we create instances of all types using DI
    /// for this example, when we request xml type, still it will inject and create the csvreportgenerator instance
    /// it's not best approach
    /// </summary>
    public class ReportGeneratorFactory2 : IReportGeneratorFactory2
    {
        private readonly IReportGenerator _csvReportGenerator;
        private readonly IReportGenerator _xmlReportGenerator;

        public ReportGeneratorFactory2(
        [FromKeyedServices("csv")] IReportGenerator csvReportGenerator,
        [FromKeyedServices("xml")] IReportGenerator xmlReportGenerator)
        {
            _csvReportGenerator = csvReportGenerator;
            _xmlReportGenerator = xmlReportGenerator;
        }
        public IReportGenerator GetReportGenerator(string formatType)
        {
            return formatType.ToLower() switch
            {
                "xml" => _xmlReportGenerator,
                "csv" => _csvReportGenerator,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
