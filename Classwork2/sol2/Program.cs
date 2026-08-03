using Classwork2.Migrations;

var migration = new Migration("/Users/sofi/alo123/Classwork2/sol2/CsvFile/csvFile.csv");

migration.Run();

migration.OldRunsForget();
