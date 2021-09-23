create table "Entry"(
"Id" serial not null,
"Name" varchar(100) not null,
"PhoneNumber" varchar(50) not null,
constraint "Entry_PK" primary key("Id"),
constraint "Entry_PhoneNumber_UX" unique("PhoneNumber")
);

create table "PhoneBook"(
"Id" serial not null,
"Name" varchar(100) not null,
constraint "PhoneBook_PK" primary key("Id")
)

create table "PhoneBookEntry" (
"Id" serial not null,
"PhoneBookId" int not null,
"EntryId" int not null,
constraint "PhoneBookEntry_PK" primary key("Id"),
constraint "PhoneBookEntry_PhoneBook_FK" foreign key("PhoneBookId") references "PhoneBook"("Id"),
constraint "PhoneBookEntry_Entry_PK" foreign key("EntryId") references "Entry"("Id")
);