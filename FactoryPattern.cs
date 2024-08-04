using LearningDesignPatterns.FactoryPattern;
using Microsoft.Extensions.DependencyInjection;

#region FactoryPatterWithoutUsingDI
//ReportGeneratorFactory reportGeneratorFactory = new ReportGeneratorFactory();
//Console.WriteLine(reportGeneratorFactory.GetReportGenerator("csv").GenerateReport());
//Console.ReadLine();
#endregion

#region FactoryPatterUsingDI

#region ReportGeneratorFactoryUsesConcretClasses
//var services = new ServiceCollection();
//services.AddScoped<IReportGeneratorFactory, ReportGeneratorFactory>();
//var serviceProvider = services.BuildServiceProvider();

//var reportGeneratorFactory = serviceProvider.GetRequiredService<IReportGeneratorFactory>();
//Console.WriteLine(reportGeneratorFactory.GetReportGenerator("xml").GenerateReport());
//Console.ReadLine();

#endregion

#region ReportGeneratorFactoryUsingDI
// not best approach
//var services = new ServiceCollection();
//services.AddKeyedScoped<IReportGenerator, XmlReportGenerator>("xml");
//services.AddKeyedScoped<IReportGenerator, CsvReportGenerator>("csv");
//services.AddScoped<ReportGeneratorFactory2, ReportGeneratorFactory2>();
//var serviceProvider = services.BuildServiceProvider();
//var reportGeneratorFactory = serviceProvider.GetRequiredService<ReportGeneratorFactory2>();
//Console.WriteLine(reportGeneratorFactory.GetReportGenerator("xml").GenerateReport());
//Console.ReadLine();
#endregion

#region ReportGeneratorUsingDIButFactoryCreateUsingDI
// best approach
var services = new ServiceCollection();
services.AddScoped<XmlReportGenerator>();
services.AddScoped<CsvReportGenerator>();
// factory pattern
services.AddScoped<Func<string, IReportGenerator>>(svc => format =>
{
    return format.ToLower() switch
    {
        "xml" => svc.GetRequiredService<XmlReportGenerator>(),
        "csv" => svc.GetRequiredService<CsvReportGenerator>(),
        _ => throw new NotImplementedException($"Format:{format} Not supported")
    };
});

var serviceProvider = services.BuildServiceProvider();
var reportGeneratorFactory = serviceProvider.GetRequiredService<Func<string, IReportGenerator>>();
Console.WriteLine(reportGeneratorFactory("csv").GenerateReport());
Console.ReadLine();
#endregion
#endregion