-- Stored Procedure for Add Customer By: Sonali
create procedure AddCustomer(@CUSTOMER_ID varchar(20),@FIRST_NAME varchar(20),@LAST_NAME varchar(20),@CUSTOMER_PASSWORD varchar(30),@ADDRESS varchar(20),@PAN_NUMBER varchar(20),@AADHAR_NUMBER numeric(15,0),@CONTACT_NUMBER numeric(15,0),@EMAIL varchar(20),@DOB varchar(20),
@CREDIT_LIMIT numeric(15,0),@LAST_UPDATED_CREDIT_DATE Date)
as
begin
insert into Customer values(@CUSTOMER_ID, @FIRST_NAME ,@LAST_NAME,@CUSTOMER_PASSWORD, @ADDRESS, @PAN_NUMBER, @AADHAR_NUMBER, @CONTACT_NUMBER, @EMAIL ,@DOB, @CREDIT_LIMIT, @LAST_UPDATED_CREDIT_DATE)
end

-- Stored procedure for view customers By: Arjoo
create procedure ViewCustomers
as
begin
Select *from Customer 
End

-- Stored procedure for search customer By: Arjoo
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


-- Stored Procedure Delete Customer By Id By: Anuj Garg
create procedure DeleteCustomerById(@CUSTOMER_ID varchar(20),@LOAN_ACC_NUMBER numeric(12,0))
as
begin
delete from LOAN_DETAILS where CUSTOMER_ID=@CUSTOMER_ID and LOAN_ACC_NUMBER=@LOAN_ACC_NUMBER and LOAN_STATUS != 'Approved';
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

-- Stored Procedure For Apply Loan By: Sonali
create procedure ApplyLoan(@LOAN_AMOUNT numeric,@CUSTOMER_ID varchar(20),@LOAN_TYPE varchar(20),@INTEREST_RATE numeric,@TENURE numeric)
as
begin
declare @LOAN_ACC_NUMBER numeric(12,0)
Select @LOAN_ACC_NUMBER=Max(LOAN_ACC_NUMBER) FROM LOAN_DETAILS
set @LOAN_ACC_NUMBER=@LOAN_ACC_NUMBER+1
insert into LOAN_DETAILS values(@LOAN_ACC_NUMBER,@LOAN_AMOUNT,@CUSTOMER_ID,'Akash35',@LOAN_TYPE,getdate(),'Pending',getdate(),@INTEREST_RATE,@TENURE,getdate(),getdate(),1500,200000,getdate(),3)
End

-- Stored Procedure For ViewPendingCustomers By: Hari
create procedure ViewPendingCustomers
as
begin
select C.CUSTOMER_ID,L.LOAN_ACC_NUMBER,C.FIRST_NAME,C.LAST_NAME,L.LOAN_STATUS from Customer C join LOAN_DETAILS L on C.CUSTOMER_ID=L.CUSTOMER_ID where L.LOAN_STATUS='Pending'
end

-- Stored Procedure For Check Criteria By: Sahithi
create procedure CheckCriteria(@CUSTOMER_ID varchar(20))
as
begin
select * from LOAN_DETAILS where CUSTOMER_ID=@CUSTOMER_ID and LOAN_STATUS = 'Approved'
end

-- Stored Procedure For Loan Approval By: Amulya
create procedure LoanApproval(@CUSTOMER_ID varchar(20),@EmpId varchar(20))
as begin
declare @TENURE numeric
select @TENURE = @TENURE from LOAN_DETAILS
update LOAN_DETAILS
set EmpId=@EmpId,LOAN_STATUS='Approved',LOAN_APPROVED_DATE=getdate(),EMI_START_DATE=getdate(),EMI_END_DATE=DATEADD(YYYY,@TENURE,EMI_START_DATE)
where CUSTOMER_ID=@CUSTOMER_ID 
end

-- Stored Procedure For Loan Rejection By: Anuj Garg
create procedure LoanRejection(@CUSTOMER_ID varchar(20),@EmpId varchar(20),@LOAN_ACC_NUMBER numeric(12,0))
as 
begin
update LOAN_DETAILS
set EmpId=@EmpId,LOAN_STATUS='Rejected'
where CUSTOMER_ID=@CUSTOMER_ID and LOAN_ACC_NUMBER=@LOAN_ACC_NUMBER
end

-- Stored Procedure For ViewPendingandRejectedCustomers By: Arjoo
create procedure ViewPendingandRejectedCustomers
as
begin
select C.CUSTOMER_ID,L.LOAN_ACC_NUMBER,C.FIRST_NAME,C.LAST_NAME,L.LOAN_STATUS from Customer C join LOAN_DETAILS L on C.CUSTOMER_ID=L.CUSTOMER_ID where L.LOAN_STATUS='Pending' or L.LOAN_STATUS='Rejected'
end
