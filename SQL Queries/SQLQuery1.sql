CREATE TABLE register (
    id int IDENTITY(1,1) PRIMARY KEY,
    name varchar(255) NOT NULL,
    email varchar(255) NOT NULL,
    usrname varchar(255) NOT NULL,
	password varchar(255) NOT NULL,
	date varchar(255) NOT NULL,
	gender varchar(255) NOT NULL
);

SELECT * FROM register