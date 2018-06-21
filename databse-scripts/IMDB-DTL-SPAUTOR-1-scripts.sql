-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Emanuel S
-- Create date: 2018-06-20
-- Description:	Procedimiiento que actualiza un registro en la tabla autor
-- =============================================
CREATE PROCEDURE MERCADEO.SP_UPDATEAUTOR 
	-- Add the parameters for the stored procedure here
	@ID AS INT,
	@NOMBRES AS NVARCHAR(50),
	@APELLIDOS AS NVARCHAR(50),
	@FECHA_NACIMIENTO AS DATETIME,
	@FECHA_DEFUNCION AS DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
		DECLARE @RESULT AS INT
		BEGIN TRAN
			SET @RESULT = 1;
			UPDATE MERCADEO.AUTOR
			SET 
				NOMBRES = @NOMBRES,
				APELLIDOS = @APELLIDOS,
				FECHA_NACIMIENTO = @FECHA_NACIMIENTO,
				FECHA_DEFUNCION = @FECHA_DEFUNCION	
			WHERE 
				ID = @ID;			
				RETURN @RESULT;
		COMMIT TRAN;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRAN;
				SET @RESULT = -1;
				RETURN @RESULT;
			END
	END CATCH
END
GO
