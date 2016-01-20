using Emppa.Common.Domain.Table;
using Emppa.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Data
{
    public class WechatDAL
    {
        readonly IDbHelper dbHelper;

        public WechatDAL()
        {
            this.dbHelper = new DbHelper("Default");
        }

        public IEnumerable<DtWechatBasicData> SelectBasicData(string appId)
        {
            string commandText = @"SELECT 
                    [PK_ID],
                    [SYSTEM_INSERT_DATETIME],
                    [SYSTEM_UPDATE_DATETIME],
                    [SYSTEM_STATUS],
                    [CREATE_USER],
                    [CREATE_DATETIME],
                    [MODIFY_USER],
                    [MODIFY_DATETIME],
                    [APP_ID],
                    [APP_SECRET],
                    [TOKEN],
                    [ENCODING_AES_KEY],
                    [ENCODING_TYPE]
                FROM 
                    [dbo].[WECHAT_BASIC_DATA]
                WHERE
                    [APP_ID] = @APP_ID";

            return this.dbHelper.ExecuteQuery<DtWechatBasicData>(commandText, new { APP_ID = appId });
        }

        public IEnumerable<DtWechatAccessToken> SelectAccessToken(string appId)
        {
            string commandText = @"SELECT 
                    [PK_ID],
                    [SYSTEM_INSERT_DATETIME],
                    [SYSTEM_UPDATE_DATETIME],
                    [SYSTEM_STATUS],
                    [CREATE_USER],
                    [CREATE_DATETIME],
                    [MODIFY_USER],
                    [MODIFY_DATETIME],
                    [ACCESS_TOKEN],
                    [EXPIRES_IN],
                    [FK_WECHAT_BASIC_DATA_PK_ID]
                FROM 
                    [dbo].[WECHAT_ACCESS_TOKEN]
                WHERE
                    [FK_WECHAT_BASIC_DATA_PK_ID] IN (SELECT [PK_ID] FROM [dbo].[WECHAT_BASIC_DATA] WHERE [APP_ID] = @APP_ID)";

            return this.dbHelper.ExecuteQuery<DtWechatAccessToken>(commandText, new { APP_ID = appId });
        }

        public int InsertAccessToken(DtWechatAccessToken dtWechatAccessToken)
        {
            string commandText = @"INSERT INTO [dbo].[WECHAT_ACCESS_TOKEN]
                (                    
                    [SYSTEM_INSERT_DATETIME],
                    [SYSTEM_STATUS],
                    [ACCESS_TOKEN],
                    [EXPIRES_IN],
                    [FK_WECHAT_BASIC_DATA_PK_ID]
                )
                VALUES
                (
                    GETDATE(),
                    0,
                    @ACCESS_TOKEN,
                    @EXPIRES_IN,
                    @FK_WECHAT_BASIC_DATA_PK_ID
                )";

            return this.dbHelper.ExecuteNonQuery
                (
                    commandText,
                    new
                    {
                        ACCESS_TOKEN = dtWechatAccessToken.AccessToken,
                        EXPIRES_IN = dtWechatAccessToken.ExpiresIn,
                        FK_WECHAT_BASIC_DATA_PK_ID = dtWechatAccessToken.BasicDataId,
                    }
                );
        }

        public int UpdateAccessToken(DtWechatAccessToken dtWechatAccessToken)
        {
            string commandText = @"UPDATE [dbo].[WECHAT_ACCESS_TOKEN] 
                SET
                    [SYSTEM_UPDATE_DATETIME] = GETDATE(),
                    [ACCESS_TOKEN] = @ACCESS_TOKEN,
                    [EXPIRES_IN] = @EXPIRES_IN
                WHERE [PK_ID] = @PK_ID";

            return this.dbHelper.ExecuteNonQuery
                (
                    commandText,
                    new
                    {
                        ACCESS_TOKEN = dtWechatAccessToken.AccessToken,
                        EXPIRES_IN = dtWechatAccessToken.ExpiresIn,
                        PK_ID = dtWechatAccessToken.Id,
                    }
                );
        }

        public IEnumerable<DtWechatJsapiTicket> SelectJsapiTicket(string appId)
        {
            string commandText = @"SELECT 
                    [PK_ID],
                    [SYSTEM_INSERT_DATETIME],
                    [SYSTEM_UPDATE_DATETIME],
                    [SYSTEM_STATUS],
                    [CREATE_USER],
                    [CREATE_DATETIME],
                    [MODIFY_USER],
                    [MODIFY_DATETIME],
                    [JSAPI_TICKET],
                    [EXPIRES_IN],
                    [FK_WECHAT_ACCESS_TOKEN_PK_ID]
                FROM 
                    [dbo].[WECHAT_JSAPI_TICKET]
                WHERE
                    [FK_WECHAT_ACCESS_TOKEN_PK_ID] IN (SELECT [PK_ID] FROM [dbo].[WECHAT_ACCESS_TOKEN] WHERE [FK_WECHAT_BASIC_DATA_PK_ID] IN (SELECT [PK_ID] FROM [dbo].[WECHAT_BASIC_DATA] WHERE [APP_ID] = @APP_ID))";

            return this.dbHelper.ExecuteQuery<DtWechatJsapiTicket>(commandText, new { APP_ID = appId });
        }

        public int InsertJsapiTicket(DtWechatJsapiTicket dtWechatJsapiTicket)
        {
            string commandText = @"INSERT INTO [dbo].[WECHAT_JSAPI_TICKET]
                (                    
                    [SYSTEM_INSERT_DATETIME],
                    [SYSTEM_STATUS],
                    [JSAPI_TICKET],
                    [EXPIRES_IN],
                    [FK_WECHAT_ACCESS_TOKEN_PK_ID]
                )
                VALUES
                (
                    GETDATE(),
                    0,
                    @JSAPI_TICKET,
                    @EXPIRES_IN,
                    @FK_WECHAT_ACCESS_TOKEN_PK_ID
                )";

            return this.dbHelper.ExecuteNonQuery
                (
                    commandText,
                    new
                    {
                        JSAPI_TICKET = dtWechatJsapiTicket.JsapiTicket,
                        EXPIRES_IN = dtWechatJsapiTicket.ExpiresIn,
                        FK_WECHAT_ACCESS_TOKEN_PK_ID = dtWechatJsapiTicket.AccessTokenId,
                    }
                );
        }

        public int UpdateJsapiTicket(DtWechatJsapiTicket dtWechatJsapiTicket)
        {
            string commandText = @"UPDATE [dbo].[WECHAT_JSAPI_TICKET] 
                SET
                    [SYSTEM_UPDATE_DATETIME] = GETDATE(),
                    [JSAPI_TICKET] = @JSAPI_TICKET,
                    [EXPIRES_IN] = @EXPIRES_IN
                WHERE [PK_ID] = @PK_ID";

            return this.dbHelper.ExecuteNonQuery
                (
                    commandText,
                    new
                    {
                        JSAPI_TICKET = dtWechatJsapiTicket.JsapiTicket,
                        EXPIRES_IN = dtWechatJsapiTicket.ExpiresIn,
                        PK_ID = dtWechatJsapiTicket.Id,
                    }
                );
        }
    }
}
