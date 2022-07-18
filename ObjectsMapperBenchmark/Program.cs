using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;


var exporter = new CsvExporter(
	CsvSeparator.CurrentCulture,
	new SummaryStyle(
		cultureInfo: System.Globalization.CultureInfo.CurrentCulture,
		printUnitsInHeader: true,
		printUnitsInContent: false,
		timeUnit: Perfolizer.Horology.TimeUnit.Microsecond,
		sizeUnit: SizeUnit.KB
	));

//var config = ManualConfig.CreateMinimumViable().AddExporter(exporter); 
var config = DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator).AddExporter(exporter);

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args,
//	DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator));
