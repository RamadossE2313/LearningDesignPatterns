using LearningDesignPatterns.FactoryPattern;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
// adding services to the servicecollection using class names
services.AddScoped(typeof(XmlReportGenerator));
// adding services to the servicecollection using class names using strongly typed
services.AddScoped<XmlReportGenerator>();

// adding services to the servicecollection using interface and class names
services.AddScoped(typeof(IReportGenerator), typeof(XmlReportGenerator));
// adding services to the servicecollection using interface and class names using strongly typed
services.AddScoped<IReportGenerator, XmlReportGenerator>();

// registering service using func
services.AddScoped(svc =>
{
    return new XmlReportGenerator();
});

services.AddScoped(typeof(IReportGenerator), svc =>
{
    return new XmlReportGenerator();
});