create table Budget (
	Id int primary key identity(1,1),
	Name varchar(128),
	[Guid] uniqueidentifier not null default(newid())
)

create unique nonclustered index ix_Budget_Guid on Budget([Guid])