INSERT INTO Person ( FirstName, LastName, Email ) VALUES ('Pers1', 'TestPerson', 'someemail@sometestcompany.abc');
INSERT INTO Person ( FirstName, LastName, Email ) Values ('Pers2', 'TestPerson2', 'someemail2@sometestcompany.abc');

INSERT INTO [Order] (OrderNumber, PersonID, [Status]) VALUES ('Ord0001', (SELECT Id From Person WHERE LastName = 'TestPerson'), 0);
INSERT INTO [Order] (OrderNumber, PersonID, [Status]) VALUES ('Ord0002', (SELECT Id From Person WHERE LastName = 'TestPerson2'), 0);