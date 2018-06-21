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
-- Description:	Procedimiento que inserta un nuevo registro en la tabla Autor
-- =============================================
CREATE PROCEDURE MERCADEO.SP_INSERTNEWAUTOR 
	-- Add the parameters for the stored procedure here
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
		BEGIN TRAN
			INSERT INTO MERCADEO.AUTOR
			(NOMBRES, APELLIDOS, FECHA_NACIMIENTO, FECHA_DEFUNCION)
			VALUES
			(
				@NOMBRES,
				@APELLIDOS,
				@FECHA_NACIMIENTO,
				@FECHA_DEFUNCION
			);

			DECLARE @IDAUTOR AS INT
			SELECT @IDAUTOR = ID
			FROM MERCADEO.AUTOR
			WHERE @@ROWCOUNT > 0 AND ID = SCOPE_IDENTITY()

			SELECT T0.ID
			FROM MERCADEO.AUTOR AS T0
			WHERE @@ROWCOUNT > 0 AND ID = @IDAUTOR

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRAN;
			END
	END CATCH
END
GO
