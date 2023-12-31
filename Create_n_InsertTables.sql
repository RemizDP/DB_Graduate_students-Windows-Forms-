CREATE TABLE Direction
(
	direction_id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	direction_name VARCHAR (50),
	category VARCHAR (50),
	direction_department VARCHAR(50)
)
CREATE TABLE Scientific_director
(
	director_id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	director_name VARCHAR (50),
	director_department VARCHAR(50)
)

CREATE TABLE Scientific_director_Direction
(
	Scientific_director_Direction_id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	director_id INT NOT NULL FOREIGN KEY REFERENCES Scientific_director,
	direction_id INT NOT NULL FOREIGN KEY REFERENCES Direction
)

CREATE TABLE Science_council
(
	council_id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	composition VARCHAR (50),
	number_of_successfull_defendings INT,
	total_number_of_defendings INT
)

CREATE TABLE Science_council_Direction
(
	Direction_Science_council_id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	council_id INT NOT NULL FOREIGN KEY REFERENCES Science_council,
	direction_id INT NOT NULL FOREIGN KEY REFERENCES Direction,
)

CREATE TABLE Graduate_student
(
	student_id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	director_id INT NOT NULL FOREIGN KEY REFERENCES Scientific_director,
	direction_id INT NOT NULL FOREIGN KEY REFERENCES Direction,
	student_name VARCHAR (50),
	date_of_birth DATE,
	awards INT,
	diploms VARCHAR (50)
)

CREATE TABLE Publication
(
	publication_id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	student_id INT NOT NULL FOREIGN KEY REFERENCES Graduate_Student,
	publication_name VARCHAR (50),
	publication_resource VARCHAR (50),
	publication_date DATE
)

CREATE TABLE Defending
(
	defending_id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	council_id INT NOT NULL FOREIGN KEY REFERENCES Science_council,
	student_id INT NOT NULL FOREIGN KEY REFERENCES Graduate_Student,
	defending_date DATE,
	council_decision VARCHAR(50)
)

INSERT INTO KR_DB.dbo.Direction (direction_name, category, direction_department)
VALUES
('����������  ���������� � �����������', '����, ����������', '����'),
('����������  ���������� � �����������', '�����, ����������', '����'),
('�������������� �������������', '����, ������������', '���'),
('�������������� ������������', '������, ������������', '��')
INSERT INTO KR_DB.dbo.Scientific_director (director_name, director_department)
VALUES
('�������� �.�.','����'),
('����� �.�.','����'),
('�������� �.�.','���')
INSERT INTO KR_DB.dbo.Scientific_director_Direction (director_id, direction_id)
VALUES
(1,1),
(1,2),
(2,1),
(2,2),
(2,4),
(3,1),
(3,2),
(3,3)
INSERT INTO KR_DB.dbo.Science_council (composition, number_of_successfull_defendings, total_number_of_defendings)
VALUES
('��������, �������, �����',8,10),
('�������, �����, �����',7,11),
('�������, ��������, ������',5,15)
INSERT INTO KR_DB.dbo.Science_council_Direction (council_id, direction_id)
VALUES
(1,1),
(1,2),
(2,1),
(2,2),
(2,4),
(3,1),
(3,2),
(3,3)
INSERT INTO KR_DB.dbo.Graduate_student (director_id, direction_id, student_name, date_of_birth, awards, diploms)
VALUES
(1,1,'�������� �.�.',CONVERT(DATE,'01.02.2003', 104),7,'���������� ���������� � ����������� 2024'),
(2,1,'������� �.�.',CONVERT(DATE,'31.07.2002', 104),10,'���������� ���������� � ����������� 2024'),
(1,2,'������� �.�.',CONVERT(DATE,'01.07.2002', 104),3,'���������� ���������� � ����������� 2020'),
(3,3,'���������� �.�.',CONVERT(DATE,'31.07.2000', 104),15,'�������������� ������������� 2020, 2022')
INSERT INTO KR_DB.dbo.Publication (student_id, publication_name, publication_resource, publication_date)
VALUES
(1,'��������������','����� � �������',CONVERT(DATE,'05.12.2025', 104)),
(1,'����������','����� � �������',CONVERT(DATE,'04.11.2025', 104)),
(2,'���������������','Discovery',CONVERT(DATE,'05.10.2026', 104)),
(4,'���������� �������������','����� � �������',CONVERT(DATE,'05.08.2022', 104)),
(4,'����������','Discovery',CONVERT(DATE,'05.08.2023', 104))
INSERT INTO KR_DB.dbo.Defending (council_id, student_id, defending_date, council_decision)
VALUES
(1,1,CONVERT(DATE,'06.12.2024', 104),'���������'),
(1,2,CONVERT(DATE,'07.12.2024', 104),'�������'),
(1,3,CONVERT(DATE,'06.12.2026', 104),'�������'),
(3,4,CONVERT(DATE,'06.12.2022', 104),'�������')