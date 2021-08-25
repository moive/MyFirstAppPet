Create procedure [dbo].[SPAddPet](
	@Name nvarchar (50),
	@Age nvarchar (10),
	@Description nvarchar (100),
	@Email nvarchar (30),
	@IsAdopted bit
)
as
begin
	Insert into Pet values (@Name, @Age, @Description, @Email, @IsAdopted)
End

select * from Pet