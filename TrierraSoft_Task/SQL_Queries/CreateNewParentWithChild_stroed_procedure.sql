CREATE PROCEDURE CreateNewParentWithChild @parentName varchar(50), @childName varchar(50)
AS
IF (@parentName IS NOT NULL)
INSERT INTO [dbo].[Parent] (ParentName)
VALUES (@parentName)

DECLARE @newParentID INT
SET @newParentID = @@IDENTITY

IF (@childName IS NOT NULL)
INSERT INTO [dbo].[Child] (ParentID, ChildName)
VALUES (@newParentID, @childName)
GO