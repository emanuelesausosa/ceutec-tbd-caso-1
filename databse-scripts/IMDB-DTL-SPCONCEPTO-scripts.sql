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
-- Author:		Emanuel Sosa
-- Create date: 20-06-2018
-- Description:	Procedimiento que inseta un registro a la tabla Concepto
-- =============================================
CREATE PROCEDURE MERCADEO.INSERTNEWCONCEPTO 
	-- Add the parameters for the stored procedure here
	@ID as INT,
	@TITULO AS NVARCHAR(100),
	@RESENIA AS NVARCHAR(MAX),
	@FECHA_LANZAMIENTO AS DATETIME,
	@PAIS_ORIGEN NVARCHAR(50),
	@URL_WEB NVARCHAR(255),
	@ID_AUTOR AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN TRAN
			INSERT INTO 
				MERCADEO.CONCEPTO(TITULO, RESENIA, FECHA_LANZAMIENTO, PAIS_ORIGEN, URL_WEB, ID_AUTOR)
			VALUES
				(
					@TITULO,
					@RESENIA,
					@FECHA_LANZAMIENTO,
					@PAIS_ORIGEN,
					@URL_WEB,
					@ID_AUTOR
				)
			
			DECLARE @IDCONCEPTO AS INT
			SELECT @IDCONCEPTO = [ID]
			FROM MERCADEO.CONCEPTO
			WHERE @@ROWCOUNT > 0 AND [ID] = SCOPE_IDENTITY()

			SELECT T0.ID
			FROM MERCADEO.CONCEPTO AS T0
			WHERE @@ROWCOUNT > 0 AND T0.[ID] = @IDCONCEPTO

		COMMIT TRAN;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 
			BEGIN
				ROLLBACK TRAN;
			END		
	END CATCH;    
END
GO
