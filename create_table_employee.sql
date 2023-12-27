CREATE TABLE IF NOT EXISTS employee (
	employee_id INT GENERATED ALWAYS AS IDENTITY,
	name VARCHAR NOT NULL,
	age INT NOT NULL,
	address VARCHAR NOT NULL,
	mobile_number VARCHAR(25) NOT NULL,
	mobile_number_emergency_contact VARCHAR(25) NULL,
	PRIMARY KEY (employee_id)
);