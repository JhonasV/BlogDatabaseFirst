CREATE TABLE [dbo].[Users]
(
	[User_Id] INT NOT NULL PRIMARY KEY Identity, 
    [UserName] VARCHAR(25) NOT NULL, 
    [Password] VARCHAR(100) NOT NULL, 
    [Created_At] DATETIME NULL DEFAULT Current_Timestamp, 
    [Updated_At] DATETIME NOT NULL
)


alter table dbo.Users alter column Updated_At datetime null


CREATE TABLE [dbo].[Posts]
(
	[Post_id] INT NOT NULL PRIMARY KEY Identity, 
    [Content] TEXT NOT NULL, 
    [Image_Url] TEXT NULL, 
    [Created_At] DATETIME NULL DEFAULT Current_Timestamp, 
    [Updated_At] DATETIME NULL, 
    [User_id] INT NOT NULL,
	constraint fk_user_id foreign key(User_Id) references Users(User_Id),

)

CREATE TABLE [dbo].[PostComments]
(
	[PostComment_id] int not null PRIMARY KEY Identity,
	[Content] TEXT Not null,
	[Post_id] int not null,
	[User_id] int not null,
	[Created_At] datetime  null default Current_Timestamp,
	[Updated_At] datetime null,
	constraint fk_post_id foreign key(Post_id) references Posts(Post_id),
	constraint fk_user_postcomment_id foreign key(User_id) references Users(User_id)
)

CREATE TABLE [dbo].[PostLikes]
(
	[Postlikes_id] int not null primary key identity,
	[User_id] int not null,
	[Post_id] int not null,
	[Created_At] datetime not null default Current_Timestamp,
	constraint fk_user_postlikes_id foreign key(User_id) references Users(User_id),
	constraint fk_post__postlikes_id foreign key(Post_id) references Posts(Post_id)
)