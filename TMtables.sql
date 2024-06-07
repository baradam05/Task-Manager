CREATE TABLE Tasks (
    Id INT PRIMARY KEY,  --AUTO_INCREMENT - protože v programu jsou 2 druhy contextu, má vlastní auto increment
    AssignedBy INT NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Assignment VARCHAR(255) NOT NULL,
    Finished DATETIME NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL
    CONSTRAINT FK_AssignedBy FOREIGN KEY (AssignedBy) REFERENCES [User](Id)
);

CREATE TABLE User (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL
);


CREATE TABLE UserTask (
    UserId INT NOT NULL,
    TaskId INT NOT NULL,
    CONSTRAINT FK_UserTask_User FOREIGN KEY (UserId) REFERENCES [User](Id),
    CONSTRAINT FK_UserTask_Task FOREIGN KEY (TaskId) REFERENCES Tasks(Id)
);

CREATE TABLE Settings (
  Context VARCHAR(255) NOT NULL,
  JsPath VARCHAR(255) NOT NULL,
  DbServer VARCHAR(255) NOT NULL,
  DbDatabase VARCHAR(255) NOT NULL,
  DbUser VARCHAR(255) NOT NULL,
  DbPassword VARCHAR(255) NOT NULL,
  autoIncrement INT DEFAULT 1 NOT NULL
);
GO