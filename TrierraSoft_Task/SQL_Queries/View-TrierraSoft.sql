CREATE VIEW GetAll AS
SELECT p.ParentID, p.ParentName, c.ChildID, c.ChildName
FROM [dbo].[Parent] p
LEFT JOIN [dbo].[Child] c ON c.ParentID = p.ParentID
