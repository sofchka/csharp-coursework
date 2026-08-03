using Classwork2.Migrations;

var migration = new Migration("/Users/sofi/alo123/Classwork2/CSVFILE/csvFile.csv");

migration.Run();

migration.OldRunsForget();
