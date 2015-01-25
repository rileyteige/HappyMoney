create table Envelope (
	Id int primary key identity(1,1),
	BudgetId int not null foreign key references Budget(Id) on delete cascade,
	Name varchar(256) not null,
	Capacity float not null,
	Balance float not null default(0.0),
	[Guid] uniqueidentifier not null default(newid())
)

create unique nonclustered index ix_Envelope_Guid on Envelope([Guid])