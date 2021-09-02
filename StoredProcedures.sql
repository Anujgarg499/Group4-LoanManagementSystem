-- Stored Procedure for Add Customer
create procedure AddCustomer(@CUSTOMER_ID varchar(20),@FIRST_NAME varchar(20),@LAST_NAME varchar(20),@ADDRESS varchar(20),@PAN_NUMBER varchar(20),@AADHAR_NUMBER numeric(15,0),@CONTACT_NUMBER numeric(15,0),@EMAIL varchar(20),@DOB varchar(20),
@CREDIT_LIMIT numeric(15,0),@LAST_UPDATED_CREDIT_DATE Date)
as
begin
insert into Customer values(@CUSTOMER_ID, @FIRST_NAME ,@LAST_NAME, @ADDRESS, @PAN_NUMBER, @AADHAR_NUMBER, @CONTACT_NUMBER, @EMAIL ,@DOB, @CREDIT_LIMIT, @LAST_UPDATED_CREDIT_DATE)
end

-- Stored procedure for view customers
create procedure ViewCustomers
as
begin
Select *from Customer 
End

-- Stored procedure for search customer
create procedure SearchCustomerById(@CUSTOMER_ID varchar(20))
as
begin
Select *from Customer where CUSTOMER_ID =@CUSTOMER_ID 
End

-- Stored Procedure Update Customer By Id
create procedure UpdateCustomerById(@CUSTOMER_ID varchar(20),
                @FIRST_NAME varchar(20),
                @LAST_NAME varchar(20),
                @ADDRESS varchar(20),
                @PAN_NUMBER varchar(20),
                @AADHAR_NUMBER numeric(15,0),
                @CONTACT_NUMBER numeric(15,0),
                @EMAIL varchar(20),
                @DOB varchar(20),
                @CREDIT_LIMIT numeric(15,0),
                @LAST_UPDATED_CREDIT_DATE Date)
as
begin
update Customer set FIRST_NAME = @FIRST_NAME, 
						  LAST_NAME = @LAST_NAME, 
						  ADDRESS = @ADDRESS, 
						  PAN_NUMBER = @PAN_NUMBER, 
						  AADHAR_NUMBER =  @AADHAR_NUMBER, 
						  CONTACT_NUMBER =  @CONTACT_NUMBER, 
						  EMAIL =  @EMAIL , 
						  DOB = @DOB, 
						  CREDIT_LIMIT =  @CREDIT_LIMIT, 
						  LAST_UPDATED_CREDIT_DATE = @LAST_UPDATED_CREDIT_DATE where CUSTOMER_ID=@CUSTOMER_ID
end

-- Stored Procedure Delete Customer By Id
create procedure DeleteCustomerById(@CUSTOMER_ID varchar(20))
as
begin
delete from Customer where CUSTOMER_ID=@CUSTOMER_ID
end