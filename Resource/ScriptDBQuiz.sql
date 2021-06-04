CREATE DATABASE QuizOnline

USE QuizOnline

go
Create Table CountConnect(dateConnect date  primary key not null, countView bigint not null )

Create Table Users

(UserID bigint primary key identity(1,1) not null,LockStatus bit,LockNote nvarchar(100),

FullName nvarchar(100), UserName varchar(20) not null, Password varchar(100) not null, Department nvarchar(100),

Email varchar(50), PhoneNumber varchar(10), Address nvarchar(200),IsValidEmail bit not null default 0,

Activatecode nvarchar(100),ResetPassCode nvarchar(100), CreateAt date default getdate(), UpdateAt date, DeleteAt date, [Online] bit default 0)

insert into Users(LockStatus,FullName,UserName,Password,Email,Address,IsValidEmail,PhoneNumber)
values(0,N'Admin','admin','0192023a7bbd73250516f069df18b500','abc@gmail.com','Huong An,Que Son,Quang Nam',1,'0984739219'),
(0,N'Lê Tấn Vỹ','letanvy','e10adc3949ba59abbe56e057f20f883e','abc@gmail.com','Huong An,Que Son,Quang Nam',1,'0984739219'),
(0,N'Tran Quoc Viet','Anhvietday','e10adc3949ba59abbe56e057f20f883e','abc@gmail.com','Huong An,Que Son,Quang Nam',1,'0984739219'),
(0,N'Nguyen Van Vinh Quang','quangnvv','e10adc3949ba59abbe56e057f20f883e','abc@gmail.com','Huong An,Que Son,Quang Nam',1,'0984739219'),
(0,N'Tran Van Long','longtv16','e10adc3949ba59abbe56e057f20f883e','abc@gmail.com','Huong An,Que Son,Quang Nam',1,'0984739219'),
(0,N'Le Van Dat','datlv3','e10adc3949ba59abbe56e057f20f883e','abc@gmail.com','Huong An,Que Son,Quang Nam',1,'0984739219')

go

CREATE TABLE RoleMaster
(
 ID INT PRIMARY KEY IDENTITY(1,1),
 RollName VARCHAR(50)
)
go
insert into RoleMaster(RollName) values ('Admin'), ('User')

CREATE TABLE UserRolesMapping
(
 ID INT Identity(1,1)  PRIMARY KEY,
 UserID bigint NOT NULL,
 RoleID INT NOT NULL,

)
go
insert into UserRolesMapping(UserID,RoleID) values (1,1) ,(1,2) ,(2,2),(3,2),(4,2),(5,2), (6,2)
go

Create Table Classes

(ClassID bigint primary key identity(1,1) not null, ClassName nvarchar(100), Description nvarchar(250), CreateAt date,

UpdateAt date, DeleteAt date ,CreateBy bigint, UpdateBy bigint, Enrollmentkey varchar(10))

go
Create table User_Class(UserClassID bigint primary key identity(1,1) not null,UserID bigint not null, ClassID bigint not null )

go

Create table Categories

(CategoryID bigint primary key identity(1,1) not null, ParentID bigint default(Null),Typename nvarchar(100), CreateAt date,

UpdateAt date, DeleteAt date ,CreateBy bigint, UpdateBy bigint )

Create table Questions

(QuestionID bigint primary key identity(1,1) not null, CategoryID bigint not null, UserID bigint not null, LevelQuestion int,

QuestionContent nvarchar(max), CreateAt date, UpdateAt date, DeleteAt date ,CreateBy bigint, UpdateBy bigint,

QuestionTime int, Image varchar(max), Media varchar(max), QuestionType int)

go

Create table Answers

(AnswerID bigint primary key identity(1,1) not null, QuestionID bigint not null, AnswerContent nvarchar(max), IsTrue bit not null, OrderAnswer int,

CreateAt date, UpdateAt date, DeleteAt date ,CreateBy bigint, UpdateBy bigint, )

go

Create table Exams

(ExamID bigint primary key identity(1,1) not null, ExamName nvarchar(250), ExamTime int not null, IsShowResult bit,

ExamCategoryID bigint not null, QuantityQuestion int, QuantityTest int,EasyQuestion int,NormalQuestion int,HardQuestion int,

AcceptCode varchar(10),StartDay datetime, EndDay datetime, TypeRandom bit ,CreateAt date, UpdateAt date, DeleteAt date ,CreateBy bigint, 

UpdateBy bigint)

go

Create table Class_Exams

(ClassExamID bigint primary key identity(1,1) not null, ClassID bigint not null, ExamID bigint not null, CreateAt date,

DeleteAt date)


Create table Exam_Questions

(ExamQuestionsID bigint primary key identity(1,1) not null,ExamID bigint not null, QuestionID bigint not null)

go

Create table User_Categories

(UserCategoriesID bigint primary key identity(1,1) not null,CategoryID bigint not null, UserID bigint not null)

go

Create table User_Class_Exams

(UserClassExamID bigint primary key identity(1,1) not null, UserID bigint not null, ClassExamID bigint not null,

CreateAt date, TimeComplete int , MaxPoint decimal(4,2) , QuantityTested int,startExam dateTime not null)

go

Create table User_Question

(UserQuestionID bigint PRIMARY KEY  identity(1,1) not null,UserClassExamID bigint not null, QuestionID bigint not null)

Create table User_Answers

(UserAnswersID bigint PRIMARY KEY  identity(1,1) not null,UserQuestionID bigint not null,AnswerID bigint not null , IsRight bit not null)

go


--

-- add FK table User_Class

Alter table User_Class add constraint FK_UserID Foreign key (UserID) references Users (UserID)

Alter table User_Class add constraint FK_ClassID Foreign key (ClassID) references Classes (ClassID)

-- add FK table Questions

Alter table Questions add constraint FK_CategoryID Foreign key (CategoryID) references Categories (CategoryID)

-- add FK table Answers

Alter table Answers add constraint FK_QuestionID Foreign key (QuestionID) references Questions (QuestionID)

-- add FK table Exams

Alter table Exams add constraint FK_ExamCategoryID Foreign key (ExamCategoryID) references Categories (CategoryID)

-- add FK table Class_Exams

Alter table Class_Exams add constraint FK_ExamClassID Foreign key (ClassID) references Classes (ClassID)

Alter table Class_Exams add constraint FK_ExamExamID Foreign key (ExamID) references Exams (ExamID)

-- add FK table Exam_Questions

Alter table Exam_Questions add constraint FK_ExamID Foreign key (ExamID) references Exams (ExamID)

Alter table Exam_Questions add constraint FK_ExamQuestionID Foreign key (QuestionID)references Questions(QuestionID)

--add FK table User_Categories

Alter table User_Categories add constraint FK_UserCategories Foreign key (CategoryID) references Categories (CategoryID)

Alter table User_Categories add constraint FK_UserIDCategories Foreign key (UserID) references Users (UserID)

-- add FK table User_Class_Exams

Alter table User_Class_Exams add constraint FK_UserID_Class_Exams Foreign key (UserID) references Users (UserID)

Alter table User_Class_Exams add constraint FK_User_ClassExamsID Foreign key (ClassExamID) references Class_Exams (ClassExamID)

-- add FK tabke User_Question_Answers

Alter table User_Question add constraint FK_User_Question_1 Foreign key (UserClassExamID) references User_Class_Exams (UserClassExamID)

Alter table User_Question add constraint FK_User_Question_2 Foreign key (QuestionID) references Questions (QuestionID)

-- add FK tabke User_Answers

Alter table User_Answers add constraint FK_User_Answers_1 Foreign key (UserQuestionID) references User_Question (UserQuestionID)


-- add FK table 

ALTER TABLE UserRolesMapping ADD constraint FK_User_Role FOREIGN KEY (UserID) REFERENCES Users(UserID)
ALTER TABLE UserRolesMapping ADD constraint FK_Role_User FOREIGN KEY (RoleID) REFERENCES RoleMaster(ID)




use [QuizOnline]

Alter table UserRolesMapping DROP CONSTRAINT FK_User_Role

Alter table UserRolesMapping DROP CONSTRAINT FK_Role_User

-- remove FK table User_Class

ALTER TABLE User_Class DROP CONSTRAINT FK_UserID

ALTER TABLE User_Class DROP CONSTRAINT FK_ClassID

-- remove FK table Categories

ALTER TABLE Questions DROP CONSTRAINT FK_CategoryID

-- remove FK table Answers

ALTER TABLE Answers DROP CONSTRAINT FK_QuestionID

-- reomve FK table Exams

ALTER TABLE Exams DROP CONSTRAINT FK_ExamCategoryID

-- remove FK table Class_Exams

ALTER TABLE Class_Exams DROP CONSTRAINT FK_ExamClassID

ALTER TABLE Class_Exams DROP CONSTRAINT FK_ExamExamID

-- remove FK table Exam_Questions

ALTER TABLE Exam_Questions DROP CONSTRAINT FK_ExamID

ALTER TABLE Exam_Questions DROP CONSTRAINT FK_ExamQuestionID

-- remove FK table User_Categories

ALTER TABLE User_Categories DROP CONSTRAINT FK_UserCategories

ALTER TABLE User_Categories DROP CONSTRAINT FK_UserIDCategories

-- remove FK table User_Class_Exams

ALTER TABLE User_Class_Exams DROP CONSTRAINT FK_UserID_Class_Exams

ALTER TABLE User_Class_Exams DROP CONSTRAINT FK_User_ClassExamsID

-- remove FK tabke User_Question_Answers

ALTER TABLE User_Question DROP CONSTRAINT FK_User_Question_1

ALTER TABLE User_Question DROP CONSTRAINT FK_User_Question_2

-- remove FK tabke User_Answers

ALTER TABLE User_Answers DROP CONSTRAINT FK_User_Answers_1

--DROP TABLE

drop table Users

drop table Classes

drop table User_Class

drop table Categories

drop table Questions

drop table Answers

drop table Exam_Questions

drop table User_Categories

drop table User_Class_Exams

drop table User_Question

drop table User_Answers

drop table Exams

drop table Class_Exams

drop table RoleMaster

drop table UserRolesMapping

drop table CountConnect




