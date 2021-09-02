create database LoanManagementSystem

use LoanManagementSystem

-- Customer Table
create table Customer(
CUSTOMER_ID varchar(20) primary key not null,
FIRST_NAME varchar(20) not null,
LAST_NAME varchar(20) not null,
ADDRESS varchar(20),
PAN_NUMBER varchar(20),
AADHAR_NUMBER numeric(15,0),
CONTACT_NUMBER numeric(15,0),
EMAIL varchar(20),
DOB varchar(20),
CREDIT_LIMIT numeric(15,0),
LAST_UPDATED_CREDIT_DATE Date
)

-- Employee Table
create table BANK_EMPLOYEE(
EmpId varchar(20) primary key,
EmpName varchar(20),
CONTACT_NUMBER numeric(10),
EMAIL varchar(20),
EMP_TYPE varchar(20) check(EMP_TYPE in('Contract Based','Permanent'))
)

drop table LOAN_DETAILS
-- Loan Details Table
create table LOAN_DETAILS(
LOAN_ACC_NUMBER numeric (12,0) primary key,
LOAN_AMOUNT numeric,
CUSTOMER_ID varchar(20) foreign key references Customer(CUSTOMER_ID),
EmpId varchar(20) foreign key references BANK_EMPLOYEE(EmpId),
LOAN_TYPE varchar(20),
LOAN_APPROVED_DATE date,
DISPERSAL_DATE date,
INTEREST_RATE numeric(2,2),
TENURE numeric(2,2),
EMI_START_DATE date,
EMI_END_DATE date,
EMI_AMOUNT numeric(2,2),
CREDIT_LIMIT numeric(2,2),
LAST_UPDATED_CREDIT_DATE date,
CUSTOMER_ASSET_ID numeric
)


