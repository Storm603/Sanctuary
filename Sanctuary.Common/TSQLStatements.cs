namespace Sanctuary.Common;

public static class TSQLStatements
{
    public const string FileStreamSetUp = @"
        ALTER DATABASE Sanctuary
		ADD FILEGROUP PictureFilegroup CONTAINS FILESTREAM

		ALTER DATABASE Sanctuary
		ADD FILE(NAME = N'PictureFilegroup', FILENAME = N'C:\Filegroups\Sanctuary\Pictures') 
        TO FILEGROUP [PictureFilegroup]
";

    public const string ReadFilestreamDataByPkFromPictureStorage = "SELECT Photo.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT() FROM Images WHERE Id = @PicturePkId";
}

//DROP TABLE PictureStorage

//    CREATE TABLE PictureStorage(

//    [Id] uniqueidentifier ROWGUIDCOL NOT NULL UNIQUE,
//[PhotoName] VARCHAR(70) NULL,
//[Photo] VARBINARY(MAX) FILESTREAM NULL,
//[CreatedOn] DateTime2 NULL,

//[UserId] nvarchar(450) NULL,
//[PetId]
//uniqueidentifier NULL,

//[ClinicId] uniqueidentifier NULL,

//PRIMARY KEY(Id),
//FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id),
//FOREIGN KEY(PetId) REFERENCES Pets(Id),
//FOREIGN KEY(ClinicId) REFERENCES Clinics(Id))