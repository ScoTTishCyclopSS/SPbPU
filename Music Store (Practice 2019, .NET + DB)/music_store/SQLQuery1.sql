﻿USE [music_store]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[LoginByUsernamePassword]
		@login = N'admin',
		@password = N'admin'

SELECT	@return_value as 'Return Value'

GO
