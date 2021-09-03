-- Stored Procedure for Add Customer By: Sonali
create procedure AddCustomer(@CUSTOMER_ID varchar(20),@FIRST_NAME varchar(20),@LAST_NAME varchar(20),@CUSTOMER_PASSWORD varchar(30),@ADDRESS varchar(20),@PAN_NUMBER varchar(20),@AADHAR_NUMBER numeric(15,0),@CONTACT_NUMBER numeric(15,0),@EMAIL varchar(20),@DOB varchar(20),
@CREDIT_LIMIT numeric(15,0),@LAST_UPDATED_CREDIT_DATE Date)
as
begin
insert into Customer values(@CUSTOMER_ID, @FIRST_NAME ,@LAST_NAME,@CUSTOMER_PASSWORD, @ADDRESS, @PAN_NUMBER, @AADHAR_NUMBER, @CONTACT_NUMBER, @EMAIL ,@DOB, @CREDIT_LIMIT, @LAST_UPDATED_CREDIT_DATE)
end

-- Stored procedure for view customers By:
create procedure ViewCustomers
as
begin
Select *from Customer 
End

-- Stored procedure for search customer By:
create procedure SearchCustomerById(@CUSTOMER_ID varchar(20))
as
begin
Select *from Customer where CUSTOMER_ID =@CUSTOMER_ID 
End

-- Stored Procedure Update Customer By Id By: Sahithi
create procedure UpdateCustomerById(@CUSTOMER_ID varchar(20),
                @FIRST_NAME varchar(20),
                @LAST_NAME varchar(20),
                @ADDRESS varchar(20),
                @PAN_NUMBER varchar(20),
                @AADHAR_NUMBER numeric(15,0),
                @CONTACT_NUMBER numeric(15,0),
                @EMAIL varchar(20),
                @DOB varchar(20))
               
as
begin
update Customer set FIRST_NAME = @FIRST_NAME, 
						  LAST_NAME = @LAST_NAME, 
						  ADDRESS = @ADDRESS, 
						  PAN_NUMBER = @PAN_NUMBER, 
						  AADHAR_NUMBER =  @AADHAR_NUMBER, 
						  CONTACT_NUMBER =  @CONTACT_NUMBER, 
						  EMAIL =  @EMAIL , 
						  DOB = @DOB
						  where CUSTOMER_ID=@CUSTOMER_ID
end
-- drop procedure UpdateCustomerById
-- Stored Procedure Delete Customer By Id By: Anuj Garg
create procedure DeleteCustomerById(@CUSTOMER_ID varchar(20))
as
begin
delete from Customer where CUSTOMER_ID=@CUSTOMER_ID
end

-- Stored Procedure to check customer login part By: Sonali
create procedure IsLoginCustomer(@CUSTOMER_ID varchar(20),@CUSTOMER_PASSWORD varchar(30))
as
begin
select * from Customer where CUSTOMER_ID=@CUSTOMER_ID and CUSTOMER_PASSWORD=@CUSTOMER_PASSWORD
end

--Stored Procedure for IsLoginEmployee By:Amulya
CREATE PROCEDURE IsLoginEmployee
      @EmpId VARCHAR(20),
      @EmpPassword VARCHAR(30)
AS
BEGIN
      SELECT * from BANK_EMPLOYEE where EmpId=@EmpId and EmpPassword=@EmpPassword
end

--Stored Procedure Check Status By: Sahithi
create procedure CheckStatus(@CUSTOMER_ID varchar(20))
as
begin
select LOAN_STATUS from LOAN_DETAILS where CUSTOMER_ID=@CUSTOMER_ID
end

create procedure ApplyLoan(@LOAN_AMOUNT numeric,@CUSTOMER_ID varchar(20),@EmpId varchar(20),
@LOAN_TYPE varchar(20),@LOAN_APPROVED_DATE date,@LOAN_STATUS varchar(30),
@DISPERSAL_DATE date,@INTEREST_RATE numeric,@TENURE numeric,
@EMI_START_DATE date,@EMI_END_DATE date,@EMI_AMOUNT numeric,@CREDIT_LIMIT numeric,
@LAST_UPDATED_CREDIT_DATE date,@CUSTOMER_ASSET_ID numeric)
as
begin
declare @LOAN_ACC_NUMBER numeric(12,0)
Select @LOAN_ACC_NUMBER=Max(LOAN_ACC_NUMBER) FROM LOAN_DETAILS
set @LOAN_ACC_NUMBER=@LOAN_ACC_NUMBER+1
insert into LOAN_DETAILS values(@LOAN_ACC_NUMBER,@LOAN_AMOUNT,@CUSTOMER_ID,@EmpId,@LOAN_TYPE,@LOAN_APPROVED_DATE,@LOAN_STATUS,@DISPERSAL_DATE,
@INTEREST_RATE,@TENURE,@EMI_START_DATE,@EMI_END_DATE,
@EMI_AMOUNT,@CREDIT_LIMIT,@LAST_UPDATED_CREDIT_DATE,
@CUSTOMER_ASSET_ID)
End

drop procedure ApplyLoan