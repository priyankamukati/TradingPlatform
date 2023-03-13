Step 1) Setup database

CREATE TABLE IF NOT EXISTS stock (
  id INT NOT NULL,
  name varchar(250) NOT NULL
);

INSERT INTO stock(id, name)
VALUES (1, 'Apple Inc');

Step 2) Update DB connection string in appsettings.json file

Step 3) Run api
dotnet run