create database LoanManagementSystem

use LoanManagementSystem

-- Customer Table By:Anuj Garg
drop table Customer
create table Customer(
CUSTOMER_ID varchar(20) primary key not null,
FIRST_NAME varchar(20) not null,
LAST_NAME varchar(20) not null,
CUSTOMER_PASSWORD varchar(30) not null,
ADDRESS varchar(20),
PAN_NUMBER varchar(20),
AADHAR_NUMBER numeric(15,0),
CONTACT_NUMBER numeric(15,0),
EMAIL varchar(20),
DOB varchar(20),
CREDIT_LIMIT numeric(15,0) null,
LAST_UPDATED_CREDIT_DATE Date null
)

select * from Customer
-- Employee Table By: Arjoo
drop table BANK_EMPLOYEE
create table BANK_EMPLOYEE(
EmpId varchar(20) primary key not null,
EmpName varchar(20) not null,
EmpPassword varchar(30) not null,
CONTACT_NUMBER numeric(10),
EMAIL varchar(20),
EMP_TYPE varchar(20) check(EMP_TYPE in('Contract Based','Permanent'))
)
insert into BANK_EMPLOYEE values('Akash35','Akash','aka@123',9876543210,'akash@gmail.com','Permanent')
insert into BANK_EMPLOYEE values('Rahul12','Rahul','rah@123',9876543211,'rahul@gmail.com','Contract Based')
insert into BANK_EMPLOYEE values('Aditi50','Aditi','adi@123',9876543212,'aditi@gmail.com','Permanent')
select * from BANK_EMPLOYEE

drop table LOAN_DETAILS
-- Loan Details Table By: Hari
create table LOAN_DETAILS(
LOAN_ACC_NUMBER numeric (12,0) primary key,
LOAN_AMOUNT numeric,
CUSTOMER_ID varchar(20) foreign key references Customer(CUSTOMER_ID),
EmpId varchar(20) foreign key references BANK_EMPLOYEE(EmpId),
LOAN_TYPE varchar(20),
LOAN_APPROVED_DATE date,
LOAN_STATUS varchar(30) default 'Pending' check(LOAN_STATUS in ('Pending','Approved','Rejected')),
DISPERSAL_DATE date,
INTEREST_RATE numeric,
TENURE numeric,
EMI_START_DATE date,
EMI_END_DATE date,
EMI_AMOUNT numeric,
CREDIT_LIMIT numeric,
LAST_UPDATED_CREDIT_DATE date,
CUSTOMER_ASSET_ID numeric
)

insert into LOAN_DETAILS values(1000,20000,'abc123','Akash35','Home loan',null,'Pending',null,7,10,null,null,400,1000,null,3)


