CREATE TABLE [dbo].[Position_Qualifications] (
    [qID] INT NOT NULL,
    CONSTRAINT [pk_j_q] PRIMARY KEY CLUSTERED ([qID] ASC),
    CONSTRAINT [FK_Q] FOREIGN KEY ([qID]) REFERENCES [dbo].[Qualification] ([ID])
);

drop table Qualification

drop table Position_Qualifications

CREATE TABLE [dbo].[Qualification] (
    [ID]                    INT   IDENTITY (1, 1) primary key,
    [Desc]                  VARCHAR (300) NULL,
    [Qualification_Type_ID] INT           NOT NULL,
    CONSTRAINT [FK_Qualifications_Type] FOREIGN KEY ([Qualification_Type_ID]) REFERENCES [dbo].[Qualification_Type] ([Qualification_Type_ID])
);
