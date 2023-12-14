CREATE TRIGGER dbo.director_direction
ON dbo.Scientific_director
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = director_id FROM deleted
SELECT @tnew = director_id FROM inserted
UPDATE dbo.Scientific_director_Direction 
		SET Scientific_director_Direction.director_id = @tnew
		WHERE Scientific_director_Direction.director_id = @told

END
GO
CREATE TRIGGER dbo.direction_director
ON dbo.Direction
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = direction_id FROM deleted
SELECT @tnew = direction_id FROM inserted
UPDATE dbo.Scientific_director_Direction 
		SET Scientific_director_Direction.direction_id = @tnew
		WHERE Scientific_director_Direction.direction_id = @told

END
GO
CREATE TRIGGER dbo.council
ON dbo.Science_council
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = council_id FROM deleted
SELECT @tnew = council_id FROM inserted
UPDATE dbo.Science_council_Direction 
		SET Science_council_Direction .council_id = @tnew
		WHERE Science_council_Direction .council_id = @told

END
GO
CREATE TRIGGER dbo.direction_council
ON dbo.Direction
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = direction_id FROM deleted
SELECT @tnew = direction_id FROM inserted
UPDATE dbo.Science_council_Direction  
		SET Science_council_Direction .direction_id = @tnew
		WHERE Science_council_Direction .direction_id = @told

END
GO
CREATE TRIGGER dbo.director_student
ON dbo.Scientific_director
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = director_id FROM deleted
SELECT @tnew = director_id FROM inserted
UPDATE dbo.Graduate_student 
		SET Graduate_student.director_id = @tnew
		WHERE Graduate_student.director_id = @told

END
GO
CREATE TRIGGER dbo.direction_student
ON dbo.Direction
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = direction_id FROM deleted
SELECT @tnew = direction_id FROM inserted
UPDATE dbo.Graduate_student
		SET Graduate_student.direction_id = @tnew
		WHERE Graduate_student.direction_id = @told

END
GO
CREATE TRIGGER dbo.student_publication
ON dbo.Graduate_student
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = student_id FROM deleted
SELECT @tnew = student_id FROM inserted
UPDATE dbo.Publication
		SET Publication.student_id = @tnew
		WHERE Publication.student_id = @told

END
GO
CREATE TRIGGER dbo.council_defending
ON dbo.Science_council
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = council_id FROM deleted
SELECT @tnew = council_id FROM inserted
UPDATE dbo.Defending
		SET Defending.council_id = @tnew
		WHERE Defending.council_id = @told

END
GO
CREATE TRIGGER dbo.student_defending
ON dbo.Graduate_student
FOR UPDATE AS
BEGIN
DECLARE @told int
DECLARE @tnew int
SELECT @told = student_id FROM deleted
SELECT @tnew = student_id FROM inserted
UPDATE dbo.Defending
		SET Defending.student_id = @tnew
		WHERE Defending.student_id = @told

END