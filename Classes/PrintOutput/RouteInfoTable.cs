var table = new Table();
table.Title("Route Info");
table.Width(150);

table.AddColumn(new TableColumn("Start Location").Centered());
table.AddColumn(new TableColumn("CheckPoints").Centered());
table.AddColumn(new TableColumn("Stop Location").Centered());
table.AddColumn(new TableColumn("Distance").Centered());

table.AddRow(
    new Text(startLocation.Name),
    new Text(string.Join(" - ", checkPointLocation.Select(c => c.Name))),
    new Text(stopLocation.Name)
);

AnsiConsole.Write(table);
Console.ReadKey();
