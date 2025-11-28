IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [LoginServices] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(50) NOT NULL,
    [Password] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_LoginServices] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250531193824_FirstMigration', N'9.0.5');

CREATE TABLE [RegisterServices] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Password] nvarchar(50) NOT NULL,
    [Phone] nvarchar(50) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_RegisterServices] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250531222823_SecondMigration', N'9.0.5');

CREATE TABLE [CustomerServices] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Phone] nvarchar(50) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_CustomerServices] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250607165846_init', N'9.0.5');

ALTER TABLE [Users] ADD [Address] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Users] ADD [FirstName] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Users] ADD [LastName] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Users] ADD [PhoneNumber] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250608175839_initCreate', N'9.0.5');

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Address');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Users] DROP COLUMN [Address];

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'FirstName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Users] DROP COLUMN [FirstName];

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'LastName');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Users] DROP COLUMN [LastName];

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PhoneNumber');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Users] DROP COLUMN [PhoneNumber];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250608205210_first', N'9.0.5');

ALTER TABLE [Users] ADD [Phonenumber] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250608210505_nice', N'9.0.5');

EXEC sp_rename N'[Users].[Phonenumber]', N'PhoneNumber', 'COLUMN';

ALTER TABLE [Users] ADD [Address] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250615164157_foraddress', N'9.0.5');

ALTER TABLE [Users] ADD [ProfilePicture] varbinary(max) NOT NULL DEFAULT 0x;

CREATE TABLE [Packages] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [ImageUrl] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Packages] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250617144310_AddProfilePictureColumn', N'9.0.5');

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'ProfilePicture');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Users] ALTER COLUMN [ProfilePicture] varbinary(max) NULL;

ALTER TABLE [Users] ADD [Role] nvarchar(max) NOT NULL DEFAULT N'';

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250620115425_usermanagement', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250621074123_another', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250621081633_YourMigrationName', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250622134332_myupdate', N'9.0.5');

CREATE TABLE [Bookings] (
    [Id] int NOT NULL IDENTITY,
    [PackageId] int NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [TravelDate] datetime2 NOT NULL,
    [ArrivalDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250630104054_booking', N'9.0.5');

ALTER TABLE [Bookings] ADD [Nationality] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Bookings] ADD [PaymentStatus] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250704085335_Paymentprocess', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250704103244_updateonbooking', N'9.0.5');

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'PaymentStatus');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Bookings] DROP COLUMN [PaymentStatus];

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'ImageUrl', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Packages]'))
    SET IDENTITY_INSERT [Packages] ON;
INSERT INTO [Packages] ([Id], [Description], [ImageUrl], [Name], [Price])
VALUES (1, N'Package for Tokyo. This is a nice package to fit your journey ', N'/image1/packageimg.jpg', N'Tokyo', 100.0),
(2, N'This is package 2', N'/image1/packageimg1.jpg', N'Package 2', 200.0),
(3, N'This is package 3', N'/image1/packageimg2.jpg', N'Package 3', 300.0),
(4, N'Package for Tokyo', N'/image1/packageimg.jpg', N'Tokyo', 100.0),
(5, N'This is package 2', N'/image1/packageimg1.jpg', N'Package 2', 200.0),
(6, N'This is package 3', N'/image1/packageimg2.jpg', N'Package 3', 300.0),
(7, N'Package for Tokyo', N'/image1/packageimg.jpg', N'Tokyo', 100.0),
(8, N'This is package 2', N'/image1/packageimg1.jpg', N'Package 2', 200.0),
(9, N'This is package 3', N'/image1/packageimg2.jpg', N'Package 3', 300.0),
(10, N'Package for Tokyo', N'/image1/packageimg.jpg', N'Tokyo', 100.0),
(11, N'This is package 2', N'/image1/packageimg1.jpg', N'Package 2', 200.0),
(12, N'This is package 3', N'/image1/packageimg2.jpg', N'Package 3', 300.0),
(13, N'Package for Tokyo', N'/image1/packageimg.jpg', N'Tokyo', 100.0),
(14, N'This is package 2', N'/image1/packageimg1.jpg', N'Package 2', 200.0),
(15, N'This is package 3', N'/image1/packageimg2.jpg', N'Package 3', 300.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'ImageUrl', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Packages]'))
    SET IDENTITY_INSERT [Packages] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250706192311_new', N'9.0.5');

UPDATE [Packages] SET [ImageUrl] = N'/image1/packageimg5.jpg'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [ImageUrl] = N'/image1/packageimg10.jpg'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [ImageUrl] = N'/image1/packageimg4.jpg'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [ImageUrl] = N'/image1/packageimg11.jpg'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [ImageUrl] = N'/image1/packageimg6.jpg'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [ImageUrl] = N'/image1/package.jpg'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [ImageUrl] = N'/image1/packageimg3.jpg'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250706204703_images', N'9.0.5');

UPDATE [Packages] SET [Description] = N'Package for Tokyo. This is a nice package to fit your journey, book and get started with our team', [Price] = 1700.0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Customized Itenaries that you would match your prference', [Name] = N'Personal Trip', [Price] = -1200.0
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Rich blend of historical landmarks, cultural experiences, and scenic landscapes', [ImageUrl] = N'/image1/UK.jpg', [Name] = N'United Kingdom', [Price] = 4100.0
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Inquire in Barbados''s breeze, culture, customs', [Name] = N'Barbados', [Price] = 3000.0
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Habibi come to Dubai, get the best experience in Dubai', [Name] = N'Dubai', [Price] = 1800.0
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Beautiful explotation and extraodinary people to meet and connect vibe', [Name] = N'Bern', [Price] = 1070.0
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Explore Cairo with us', [Name] = N'Egypt', [Price] = 2200.0
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Get a best of Mumbai with Emmasco Team, the coastals, cultures etc path with us to superb adventures', [Name] = N'India', [Price] = 800.0
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Looking for family?? no worries we''re here for you, look our awesome customized itenaries to enjoy lifetime moments with your family', [Name] = N'Family Trip (Customized)', [Price] = 1900.0
WHERE [Id] = 10;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Enjoy our amazing full packages we offer to suit your needs', [Name] = N'Full Package', [Price] = 2000.0
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Get to know more about Finland and get to the history of their customs and values', [ImageUrl] = N'/image1/FINLANDO.jpg', [Name] = N'Finland', [Price] = 500.0
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Unforgettable memories, explore the beauty of Switzerland ', [ImageUrl] = N'/image1/packaGE201.jpg', [Name] = N'Switzerland', [Price] = 6500.0
WHERE [Id] = 13;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Enjoy the breathtaking and the best moments in Melbourne', [ImageUrl] = N'/image1/broaustra.jpg', [Name] = N'Australia', [Price] = 1500.0
WHERE [Id] = 14;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'A trip to explore the coastal and the excitement in Ontario, Canada', [ImageUrl] = N'/image1/canada0000.jpg', [Name] = N'Canada', [Price] = 1000.0
WHERE [Id] = 15;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250706221504_newimag', N'9.0.5');

UPDATE [Packages] SET [Description] = N'China''s diverse landscapes include stunning forests, ranging from ancient tropical rainforests to towering mountain forests.', [Name] = N'China', [Price] = 2300.0
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Enjoy our amazing friendship packages that suit your needs of personalization', [Name] = N'Friendship Travel'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250706222247_friendsupda', N'9.0.5');

UPDATE [Packages] SET [Price] = 2080.0
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Inquire in Barbados''s breeze, culture, customs to see more and feel more.'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Beautiful explotation and extraodinary people to meet and connect, vibe, believe and trust'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Explore Cairo with us and feels life''s beauty'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250706223050_bernupdate', N'9.0.5');

UPDATE [Packages] SET [Description] = N'Inquire in Barbados''s breeze, exceptional cultures, customs to see more, feel more, and know around the world.'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Beautiful explotation and extraodinary people to meet and connect, vibe, believe and trust us with you little step'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Explore Cairo with us to feels life''s beauty, wonderful landscapes and their authentic city vibe they give'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Get to know more about Finland and get to the history of their customs, values and landscapes with our team '
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Unforgettable memories you will get, explore the beauty of Switzerland and hikings etc book with us to see'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250706223815_linecorrect', N'9.0.5');

UPDATE [Packages] SET [Description] = N'Get the best of Mumbai with Emmasco Team, the coastals, cultures, and superb adventures'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Description] = N'Get to know more about Finland and get to the history of their customs, values and landscapes'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250706224117_corrections', N'9.0.5');

UPDATE [Packages] SET [Description] = N'Beautiful exploration and extraodinary people to meet and connect, vibe, believe and trust us with you little step'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250706224752_explore', N'9.0.5');

ALTER TABLE [CustomerServices] ADD [ProfilePicture] varbinary(max) NOT NULL DEFAULT 0x;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250712203503_profile', N'9.0.5');

CREATE TABLE [Feedbacks] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Message] nvarchar(max) NOT NULL,
    [Date] datetime2 NOT NULL,
    CONSTRAINT [PK_Feedbacks] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250712211326_feedback', N'9.0.5');

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'TrackingStatus');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Bookings] DROP COLUMN [TrackingStatus];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250713162018_napacakge', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250713162742_smallupdatebook', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250731224917_admin', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250816194936_updates', N'9.0.5');

CREATE INDEX [IX_Bookings_PackageId] ON [Bookings] ([PackageId]);

ALTER TABLE [Bookings] ADD CONSTRAINT [FK_Bookings_Packages_PackageId] FOREIGN KEY ([PackageId]) REFERENCES [Packages] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250816202526_Updateonpackage', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817140319_updat', N'9.0.5');

ALTER TABLE [Bookings] DROP CONSTRAINT [FK_Bookings_Packages_PackageId];

DROP INDEX [IX_Bookings_PackageId] ON [Bookings];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817182540_adminmigra', N'9.0.5');

ALTER TABLE [Bookings] ADD [BookingDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

ALTER TABLE [Bookings] ADD [Status] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Bookings] ADD [UserId] nvarchar(max) NOT NULL DEFAULT N'';

CREATE INDEX [IX_Bookings_PackageId] ON [Bookings] ([PackageId]);

ALTER TABLE [Bookings] ADD CONSTRAINT [FK_Bookings_Packages_PackageId] FOREIGN KEY ([PackageId]) REFERENCES [Packages] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817185705_UpdateBookingAndPackage', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817191414_AddBookingFields', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817192604_AddUserIdAndRelationsToBooking', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817195840_fast', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817201924_sharpupda', N'9.0.5');

ALTER TABLE [Bookings] DROP CONSTRAINT [FK_Bookings_Packages_PackageId];

DROP INDEX [IX_Bookings_PackageId] ON [Bookings];

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'BookingDate');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Bookings] DROP COLUMN [BookingDate];

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'Status');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Bookings] DROP COLUMN [Status];

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'UserId');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Bookings] DROP COLUMN [UserId];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817203433_FixBookings', N'9.0.5');

ALTER TABLE [Bookings] ADD [BookingDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

CREATE INDEX [IX_Bookings_PackageId] ON [Bookings] ([PackageId]);

ALTER TABLE [Bookings] ADD CONSTRAINT [FK_Bookings_Packages_PackageId] FOREIGN KEY ([PackageId]) REFERENCES [Packages] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250817215402_free', N'9.0.5');

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'Address');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Bookings] DROP COLUMN [Address];

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'ArrivalDate');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Bookings] DROP COLUMN [ArrivalDate];

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'Email');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Bookings] DROP COLUMN [Email];

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'FirstName');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Bookings] DROP COLUMN [FirstName];

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bookings]') AND [c].[name] = N'LastName');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Bookings] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Bookings] DROP COLUMN [LastName];

EXEC sp_rename N'[Bookings].[PhoneNumber]', N'CustomerName', 'COLUMN';

EXEC sp_rename N'[Bookings].[Nationality]', N'CustomerEmail', 'COLUMN';

ALTER TABLE [Bookings] ADD [NumberOfPeople] int NOT NULL DEFAULT 0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250828213652_obook', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250828220224_newobooking', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250828222422_addo', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250828222921_oofor book', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250828223855_or', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250830160019_AddTrackingWithRelation', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250830160522_AddTrackingWithRelation1', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250830162144_FixTrackingsTable', N'9.0.5');

ALTER TABLE [Bookings] ADD [ArrivalDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250831124059_arrivaldate', N'9.0.5');

ALTER TABLE [Bookings] ADD [PaymentOption] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250831152921_AddPaymentOptionToBookings', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250903203429_updateonadmin', N'9.0.5');

ALTER TABLE [Bookings] ADD [Status] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250903224756_AddStatusToBooking', N'9.0.5');

ALTER TABLE [Packages] ADD [Accommodation] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Packages] ADD [Activities] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Packages] ADD [Country] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Packages] ADD [Duration] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Packages] ADD [Meals] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Packages] ADD [Transport] nvarchar(max) NOT NULL DEFAULT N'';

UPDATE [Packages] SET [Accommodation] = N'4-Star Hotel', [Activities] = N'Tokyo Tower, Shibuya Crossing, Mt. Fuji Tour', [Country] = N'Japan', [Duration] = N'7 Days, 6 Nights', [Meals] = N'Breakfast Included', [Transport] = N'Flight + Bullet Train'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'Customizable', [Activities] = N'Custom itinerary, Personalized tours', [Country] = N'Worldwide', [Duration] = N'Flexible', [Meals] = N'Optional', [Transport] = N'Flexible Options'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'3-Star Hotel', [Activities] = N'Great Wall, Forbidden City, Shanghai Tour', [Country] = N'China', [Duration] = N'8 Days, 7 Nights', [Meals] = N'Breakfast + Lunch', [Name] = N'Beijing', [Transport] = N'Flight + High-speed Train'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'4-Star Hotel', [Activities] = N'London Eye, Buckingham Palace, Stonehenge', [Country] = N'United Kingdom', [Duration] = N'10 Days, 9 Nights', [Meals] = N'Breakfast', [Name] = N'London', [Transport] = N'Flight + Train'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'Resort', [Activities] = N'Beaches, Island Tour, Snorkeling', [Country] = N'Barbados', [Duration] = N'6 Days, 5 Nights', [Meals] = N'All Inclusive', [Name] = N'Bridgetown', [Transport] = N'Flight + Local Transport'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'Luxury Hotel', [Activities] = N'Burj Khalifa, Desert Safari, Shopping Tour', [Country] = N'UAE', [Duration] = N'5 Days, 4 Nights', [Meals] = N'Breakfast + Dinner', [Transport] = N'Flight + Private Car'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'3-Star Hotel', [Activities] = N'City Tour, Old Town, Zytglogge Clock Tower', [Country] = N'Switzerland', [Duration] = N'4 Days, 3 Nights', [Meals] = N'Breakfast', [Transport] = N'Flight + Train'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'4-Star Hotel', [Activities] = N'Pyramids of Giza, Nile Cruise, Egyptian Museum', [Country] = N'Egypt', [Duration] = N'7 Days, 6 Nights', [Meals] = N'Breakfast + Dinner', [Name] = N'Cairo', [Transport] = N'Flight + Local Bus'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'3-Star Hotel', [Activities] = N'Gateway of India, Taj Mahal, Bollywood Tour', [Country] = N'India', [Description] = N'Get the best of New Delhi, Mumbai with Emmasco Team, the coastals, cultures, and superb adventures', [Duration] = N'6 Days, 5 Nights', [Meals] = N'Breakfast + Lunch', [Name] = N'New Delhi', [Transport] = N'Flight + Train'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'Family Suites / Villas', [Activities] = N'Theme Parks, Family Adventures, Museums', [Country] = N'Worldwide', [Duration] = N'Flexible', [Meals] = N'Customizable', [Transport] = N'Flight + Private Van'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'Shared Apartments / Hotels', [Activities] = N'Nightlife, Beaches, Hiking', [Country] = N'Various Destinations', [Duration] = N'5 Days, 4 Nights', [Meals] = N'Breakfast + Drinks', [Transport] = N'Flight + Local Bus'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'3-Star Hotel', [Activities] = N'Northern Lights, Helsinki Tour, Snow Activities', [Country] = N'Finland', [Duration] = N'5 Days, 4 Nights', [Meals] = N'Breakfast', [Name] = N'Helsinki', [Transport] = N'Flight + Train'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'Luxury Hotel', [Activities] = N'Alps Hiking, Lake Alpsee, Rhine Valley Tour', [Country] = N'Germany', [Description] = N'Unforgettable memories you will get, explore the beauty of Berlin and hikings etc book with us to see', [Duration] = N'8 Days, 7 Nights', [ImageUrl] = N'/image1/germanyapp.jpg', [Meals] = N'Breakfast + Dinner', [Name] = N'Berlin', [Transport] = N'Flight + Train'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'4-Star Hotel', [Activities] = N'Sydney Opera House, Great Barrier Reef, Melbourne Tour', [Country] = N'Australia', [Duration] = N'7 Days, 6 Nights', [Meals] = N'Breakfast', [Name] = N'Canberra', [Transport] = N'Flight + Car Rental'
WHERE [Id] = 14;
SELECT @@ROWCOUNT;


UPDATE [Packages] SET [Accommodation] = N'3-Star Hotel', [Activities] = N'Niagara Falls, Toronto CN Tower, National Parks', [Country] = N'Canada', [Duration] = N'6 Days, 5 Nights', [Meals] = N'Breakfast', [Name] = N'Toronto', [Transport] = N'Flight + Train'
WHERE [Id] = 15;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250906104141_AddPackageDetails', N'9.0.5');

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CustomerServices]') AND [c].[name] = N'ProfilePicture');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [CustomerServices] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [CustomerServices] ALTER COLUMN [ProfilePicture] varbinary(max) NULL;

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CustomerServices]') AND [c].[name] = N'Phone');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [CustomerServices] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [CustomerServices] ALTER COLUMN [Phone] nvarchar(50) NOT NULL;

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CustomerServices]') AND [c].[name] = N'LastName');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [CustomerServices] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [CustomerServices] ALTER COLUMN [LastName] nvarchar(100) NOT NULL;

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CustomerServices]') AND [c].[name] = N'FirstName');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [CustomerServices] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [CustomerServices] ALTER COLUMN [FirstName] nvarchar(100) NOT NULL;

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CustomerServices]') AND [c].[name] = N'Email');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [CustomerServices] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [CustomerServices] ALTER COLUMN [Email] nvarchar(100) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250906160906_MakeProfilePictureNullable', N'9.0.5');

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CustomerServices]') AND [c].[name] = N'ProfilePicture');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [CustomerServices] DROP CONSTRAINT [' + @var20 + '];');
UPDATE [CustomerServices] SET [ProfilePicture] = 0x WHERE [ProfilePicture] IS NULL;
ALTER TABLE [CustomerServices] ALTER COLUMN [ProfilePicture] varbinary(max) NOT NULL;
ALTER TABLE [CustomerServices] ADD DEFAULT 0x FOR [ProfilePicture];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250906184444_updatoncustomerht', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250906185412_RemoveUserIdFromCustomerServices', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250906185959_NewMigrationName', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250906191143_newprofileissued', N'9.0.5');

DROP TABLE [CustomerServices];

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Username');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [Users] ALTER COLUMN [Username] nvarchar(50) NOT NULL;

DECLARE @var22 sysname;
SELECT @var22 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PhoneNumber');
IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var22 + '];');
ALTER TABLE [Users] ALTER COLUMN [PhoneNumber] nvarchar(50) NOT NULL;

DECLARE @var23 sysname;
SELECT @var23 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var23 + '];');
ALTER TABLE [Users] ALTER COLUMN [Password] nvarchar(50) NOT NULL;

DECLARE @var24 sysname;
SELECT @var24 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Email');
IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var24 + '];');
ALTER TABLE [Users] ALTER COLUMN [Email] nvarchar(100) NOT NULL;

DECLARE @var25 sysname;
SELECT @var25 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Address');
IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var25 + '];');
ALTER TABLE [Users] ALTER COLUMN [Address] nvarchar(50) NOT NULL;

ALTER TABLE [Users] ADD [FirstName] nvarchar(50) NOT NULL DEFAULT N'';

ALTER TABLE [Users] ADD [LastName] nvarchar(50) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250911163047_newupdateuser', N'9.0.5');

DECLARE @var26 sysname;
SELECT @var26 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var26 + '];');
ALTER TABLE [Users] ALTER COLUMN [Password] nvarchar(226) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250911164827_UpdatePasswordLength', N'9.0.5');

DECLARE @var27 sysname;
SELECT @var27 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var27 + '];');
ALTER TABLE [Users] ALTER COLUMN [Password] nvarchar(max) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250911164947_paaswordedited', N'9.0.5');

DECLARE @var28 sysname;
SELECT @var28 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var28 + '];');
ALTER TABLE [Users] ALTER COLUMN [Password] nvarchar(255) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250911165520_UpdatePasswordLengthspa', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250911170042_UpdatePassword', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250914092706_IncreasePasswordLength', N'9.0.5');

DECLARE @var29 sysname;
SELECT @var29 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Username');
IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var29 + '];');
ALTER TABLE [Users] ALTER COLUMN [Username] nvarchar(max) NOT NULL;

DECLARE @var30 sysname;
SELECT @var30 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PhoneNumber');
IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var30 + '];');
ALTER TABLE [Users] ALTER COLUMN [PhoneNumber] nvarchar(max) NOT NULL;

DECLARE @var31 sysname;
SELECT @var31 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var31 + '];');
ALTER TABLE [Users] ALTER COLUMN [Password] nvarchar(510) NOT NULL;

DECLARE @var32 sysname;
SELECT @var32 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'LastName');
IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var32 + '];');
ALTER TABLE [Users] ALTER COLUMN [LastName] nvarchar(max) NULL;

DECLARE @var33 sysname;
SELECT @var33 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'FirstName');
IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var33 + '];');
ALTER TABLE [Users] ALTER COLUMN [FirstName] nvarchar(max) NULL;

DECLARE @var34 sysname;
SELECT @var34 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Email');
IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var34 + '];');
ALTER TABLE [Users] ALTER COLUMN [Email] nvarchar(max) NOT NULL;

DECLARE @var35 sysname;
SELECT @var35 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Address');
IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var35 + '];');
ALTER TABLE [Users] ALTER COLUMN [Address] nvarchar(max) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250914095031_FixUserSchema', N'9.0.5');

COMMIT;
GO

