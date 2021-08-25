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

go

select * from Pet

go

Create Procedure [dbo].[GetPet]
as
begin
	select * from Pet
End

go

Update Pet
set isAdopted=1
where id_pet=2