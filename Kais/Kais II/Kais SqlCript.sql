



Create Database KaisII
go 

USE KaisII
GO
/****** Object:  StoredProcedure [dbo].[UP_LoadField]    Script Date: 10/03/2011 14:55:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create  Proc [dbo].[UP_LoadField](@iformID tinyint)
as
Select * from dbo.CFG_Fields where Fld_FormId =@iformID order by fld_index

go 
Create Proc [dbo].[UP_LoadLookup]
as

Select * from dbo.CFG_Lookups order by Lkp_Index

Go 
Create  Proc [dbo].[UP_LoadSkips](@fieldNo int)
as
SELECT [Skp_No]
,[Skp_FieldNo]
,[Skp_FieldValue]
,[Skp_Operator]
,[Skp_SkipToField]
,[Skp_GUID]
FROM [CFG_Skips] where Skp_FieldNo =@fieldNo

Go
Create Proc [dbo].[Up_SaveData](@Sql Varchar(1000))
as
Exec (@Sql)
go 
Create Table Youth_Kais

(Y_ID int Identity (1,1), q_1_1 int, q_102 char(3), q_102spy
varchar(250), q_103 int, q_104 int, q_105 int,
q_105spy varchar(250), q_106 int,
q_107 char(3),
q_108 varchar(50),
q_109 int,
q_110 char(3),
q_111 char(3),
q_111spy varchar(250),
q_112 char(3),
q_112spy varchar(250),
q_113 char(3),
q_113spy varchar(250),
q_201 char(3),
q_202 char(3),
q_203 char(3),
q_204 char(3),
q_205 char(3),
q_301School char(3),
q_301Parent char(3),
q_301Friends char(3),
q_301Religious char(3),
q_301Internet char(3),
q_301Mobile char(3),
q_301Health char(3),
q_301officers char(3),
q_301Television char(3),
q_301Radio char(3),
q_301Dont char(3),
q_301spy varchar(50),
q_301NORESPONSE char(3),
q_302 char(2),
q_401 char(2),
q_402 char(2),
q_501 char(2),
q_502never_sex char(2),
q_502dont_have_sex char(2),
q_502faithful char(2),
q_502trust_my_partner char(2),
q_502use_condoms char(2),
q_502dont_inject char(2),
q_502healty char(2),
q_502circumcised char(2),
q_502know_Status char(2),
q_502know_partners_Status char(2),
Q_502God_proctectq_502spy varchar(250),
q_502_no_response char(2),
q_503Without_Condom char(2),
q_503Many_Boyfriends_girlFriend char(2),
q_503bloodtransfusion char(2),
q_503injected char(2),
q_503mother_fathe_HIV char(2),
q_503not_circumcised char(2),
q_503dont_trust char(2),
q_503sick char(2),
q_503girl_boyfriend_sick char(2),
q_503died_AIDS char(2),
q_503accident char(2),
q_503spy varchar(250),
q_503no_response char(2),
q_601 char(2),
q_602 char(2),
q_603 char(2),
q_604 char(2),
q_604spy varchar(250),
q_605 char(3),
q_606 char(3),
q_607 char(3),
q_608 char(3),
q_609 char(3),
q_610 char(3),
q_611 char(2),
q_611healthfacility char(2),
q_611pharmacy char(2),
q_611shop char(2),
q_611friends char(2),
q_611parents char(2),
q_611public char(2),
q_611other char(2),
q_611dontknow char(2),
q_611noresponse char(2),
q_611spy varchar(250),
q_612 char(3),
q_701 char(2),
q_702 char(2),
q_703 char(2),
q_704 int,
q_705 int,
q_706 int,
q_707 int,
q_708 char(3),
q_708spy varchar(250),
q_709 int,
q_709spy varchar(250),
q_710 int,
q_711 int,
q_711spy varchar(250),
q_713 char(3),
q_801 char(2),
q_802 char(2),
q_803 char(2),
q_804 char(2),
Created_By int ,
DateCreated Datetime default GetDate(),
DateUpdate Datetime,
Y_Guid uniqueidentifier

)
go
ALTER TABLE Youth_Kais ADD  CONSTRAINT [DF_Y_Guid]  DEFAULT (newsequentialid()) FOR [Y_Guid]

